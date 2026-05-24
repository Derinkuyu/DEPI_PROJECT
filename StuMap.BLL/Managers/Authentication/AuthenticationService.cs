using Microsoft.AspNetCore.Identity;
using StuMap.BLL.DTO.Authentication;
using StuMap.BLL.Models;
using StuMap.BLL.Services.Authentication;
using StuMap.DAL.Context;
using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;

namespace StuMap.BLL.Managers.Authentication
{
    public class AuthenticationService(
        AppDbContext dbContext,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager) : IAuthenticationService
    {
        public async Task<ApiResponse> Logout()
        {
            await signInManager.SignOutAsync();

            return ApiResponse.SuccessResult();
        }


        public async Task<ApiResponse> Login(LoginDto loginDto)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(
                      userName: loginDto.Email,
                      password: loginDto.Password,
                      isPersistent: true,
                      lockoutOnFailure: false
                      );

                if (result.Succeeded)
                {
                    return ApiResponse.SuccessResult("Logged In Successfuly");
                }
                return ApiResponse.FailureResult("Login Failed.\nPlease check your email or password.");
            }
            catch (Exception)
            {
                return ApiResponse.FailureResult("Internal Error.");
            }
        }

        public async Task<ApiResponse> Signup(SignupDto signupDto)
        {
            // todo: create a contributor model to hold his data
            ApplicationUser newUser = new()
            {
                UserName = signupDto.Email,
                PhoneNumber = signupDto.Phone,
                Email = signupDto.Email,
                FirstName = signupDto.FName,
                LastName = signupDto.LName,
                Country = signupDto.Country,
                DateOfBirth = DateTime.SpecifyKind(signupDto.DateOfBirth, DateTimeKind.Utc),
                CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                IsContributorRequest = signupDto is ContributorSignUpDto,
                RequestDate = signupDto is ContributorSignUpDto ? DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc) : null,
                ContributorStatus = StatusEnum.Pending
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
                            return ApiResponse.FailureResult("Sign up failed.", errors: "An error occured during sign up, please try again later.");
                        }
                        break;
                }

                return ApiResponse.SuccessResult("Success.");
            }
            Console.WriteLine($"Failed to Create User with Id: {newUser.Id}");
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"[IDENTITY ERROR] Code: {error.Code} | Description: {error.Description}");
            }

            return ApiResponse.FailureResult("Sign up failed.", errors: [.. result.Errors.Select(x => x.Description)]);
        }

    }
}
