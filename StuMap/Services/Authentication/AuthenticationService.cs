using Microsoft.AspNetCore.Identity;
using StuMap.Context;
using StuMap.DTO.Authentication;
using StuMap.Models;

namespace StuMap.Services.Authentication
{
    public class AuthenticationService(
        AppDbContext dbContext,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager) : IAuthenticationService
    {

        public async Task Test()
        {
            var relations = dbContext.UserRoles
                                        .Join(dbContext.Users,
                                        t3 => t3.UserId,
                                        t1 => t1.Id,
                                        (UserRole, User) => new { UserRole, User })
                                        .Join(dbContext.Roles,
                                        combined => combined.UserRole.RoleId,
                                        Role => Role.Id,
                                        (combined, Role) => new
                                        {
                                            combined.User,
                                            Role
                                        });

            foreach (var item in relations)
            {
                Console.WriteLine($"{item.User.Email} - {item.Role.Name}");
            }
        }
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }


        public async Task<(bool success, string message)> Login(LoginDto loginDto)
        {
            var result = await signInManager.PasswordSignInAsync(
            userName: loginDto.Email,
            password: loginDto.Password,
            isPersistent: true,
            lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                return (true, "Logged In Successfuly");
            }

            return (false, "Logged In Failed!\nPlease check your email or password.");
        }

        public async Task<bool> Signup(SignupDto signupDto)
        {
            ApplicationUser newUser = new()
            {
                UserName = signupDto.Email,
                PhoneNumber = signupDto.Phone,
                Email = signupDto.Email,
                FirstName = signupDto.FName,
                LastName = signupDto.LName,
                Country = signupDto.Country,
                DateOfBirth = DateTime.SpecifyKind(signupDto.DateOfBirth, DateTimeKind.Utc),
            };

            Console.WriteLine($"Creating User with Id: {newUser.Id}");

            var result = await userManager.CreateAsync(newUser, signupDto.Password!);


            if (result.Succeeded)
            {
                Console.WriteLine($"Created User with Id: {newUser.Id}");

                switch (signupDto)
                {
                    case StudentSignUpDto:
                        if (!await roleManager.RoleExistsAsync("Student"))
                        {
                            await roleManager.CreateAsync(new IdentityRole("Student"));
                        }

                        await userManager.AddToRoleAsync(newUser, "Student");
                        break;
                    case ContributorSignUpDto contributor:
                        if (!await roleManager.RoleExistsAsync("Contributor"))
                        {
                            await roleManager.CreateAsync(new IdentityRole("Contributor"));
                        }

                        await userManager.AddToRoleAsync(newUser, "Contributor");

                        try
                        {
                            foreach (var cert in contributor.Certificates)
                            {
                                Certificate c = new()
                                {
                                    Title = cert.Title,
                                    Url = cert.Url,
                                    ContributorId = newUser.Id
                                };
                                dbContext.Certificates.Add(c);
                            }
                            await dbContext.SaveChangesAsync();
                        }
                        catch (Exception)
                        {
                            await userManager.DeleteAsync(newUser);
                            return false;
                        }
                        break;
                }

                return true;
            }
            Console.WriteLine($"Failed to Create User with Id: {newUser.Id}");
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"[IDENTITY ERROR] Code: {error.Code} | Description: {error.Description}");
            }

            return false;
        }

    }
}
