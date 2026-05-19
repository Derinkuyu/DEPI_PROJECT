using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StuMap.Context;
using StuMap.DTO.Admin;
using StuMap.Managers;
using StuMap.Models;
using StuMap.Models.Enums;

namespace StuMap.Services
{
    public class ContributorRepository : IContributorManager
    {
        /*---------------------------------------------------------------------------------*/
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        /*---------------------------------------------------------------------------------*/
        public ContributorRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void ApproveContributor(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                user.ContributorStatus = ContributorStatus.Approved;

                _context.SaveChanges();

                _userManager.AddToRoleAsync(user, "Contributor").Wait();
            }
        }

        public List<ContributorRequestDto> GetAllContributors()
        {
            return _context.Users
                    .Where(u => (bool)u.IsContributorRequest)
                    .Select(u => new ContributorRequestDto
                    {
                        Id = u.Id,
                        FullName = $"{u.FirstName} {u.LastName}",
                        Email = u.Email,
                        Specialization = u.Specialization,
                        CertificatePath = u.CertificatePath,
                        Status = (ContributorStatus)u.ContributorStatus,
                        RequestDate = u.RequestDate
                    })
                    .ToList();
        }

        public ContributorDetailsDto GetContributorById(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return null;

            return new ContributorDetailsDto
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Specialization = user.Specialization,
                CertificatePath = user.CertificatePath,
                Status = (ContributorStatus)user.ContributorStatus,
                RejectionReason = user.RejectionReason,
                RequestDate = user.RequestDate
            };
        }

        public List<ContributorRequestDto> GetPendingRequests()
        {
            var users = _context.Users.Where(u => u.ContributorStatus == ContributorStatus.Pending)
                .Select(u => new ContributorRequestDto
                {
                    Id = u.Id,
                    FullName = $"{u.FirstName} {u.LastName}",
                    Email = u.Email,
                    Specialization = u.Specialization,
                    CertificatePath = u.CertificatePath,
                    Status = (ContributorStatus)u.ContributorStatus,
                    RequestDate = u.RequestDate
                })
                .ToList();
            return users;
        }

        public void RejectContributor(string id, string reason)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                user.ContributorStatus = ContributorStatus.Rejected;

                user.RejectionReason = reason;

                _context.SaveChanges();
            }
        }
        /*---------------------------------------------------------------------------------*/

    }
}
