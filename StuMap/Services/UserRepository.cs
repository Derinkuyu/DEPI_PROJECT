using Microsoft.AspNetCore.Identity;
using StuMap.Context;
using StuMap.Models;
using StuMap.Managers;
using StuMap.DTO.Admin;

namespace StuMap.Services
{
    public class UserRepository : IUserManager
    {
        /*------------------------------------------------------------------------------------*/
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        /*------------------------------------------------------------------------------------*/
        public UserRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        /*------------------------------------------------------------------------------------*/
        public List<UserDto> GetAll()
        {
            var users = _context.Users.ToList();
            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault() ?? "User",
                IsBlocked = user.IsBlocked,
                CreatedAt = user.CreatedAt
            }).ToList();
            return userDtos;
        }
        /*------------------------------------------------------------------------------------*/

        public UserDetailsDto GetById(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return null;
            var userDto = new UserDetailsDto
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault() ?? "User",
                IsBlocked = user.IsBlocked,
                CreatedAt = user.CreatedAt
            };
            return userDto;
        }
        /*------------------------------------------------------------------------------------*/
        public void Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                var materials = _context.Materials.Where(m => m.ContributorId == id).ToList();
                foreach (var m in materials)
                {
                    m.ContributorId = null;
                }
                _context.SaveChanges();
                _context.Remove(user);
                _context.SaveChanges();
            }
        }
        /*------------------------------------------------------------------------------------*/
        public void Block(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.IsBlocked = true;
                _context.SaveChanges();
            }
        }
        /*------------------------------------------------------------------------------------*/
        public void Unblock(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.IsBlocked = false;
                _context.SaveChanges();
            }
        }
        /*------------------------------------------------------------------------------------*/
    }
}
