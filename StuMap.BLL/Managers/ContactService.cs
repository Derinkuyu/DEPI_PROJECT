using StuMap.BLL.Models;
using StuMap.BLL.Services;
using StuMap.DAL.Models;
using StuMap.DAL.Repositories.Interfaces;

namespace StuMap.BLL.Managers
{
    public class ContactService(
        IGenericRepository<Contact> repo) : IContactService
    {
        public async Task<ApiResponse> CreateNewTicket(string? userId, string subject, string body)
        {
            try
            {
                if (userId == null)
                    throw new Exception();

                await repo.AddAsync(new Contact
                {
                    UserId = userId,
                    Subject = subject,
                    Body = body,
                    DateSent = DateTime.UtcNow
                });
                await repo.SaveChangesAsync();

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<List<Contact>>> GetAll(string? userId)
        {
            try
            {
                var result = await repo.FindAsync(x => x.UserId == userId);

                return ApiResponse<List<Contact>>.SuccessResult([.. result]);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<Contact>>.FailureResult("Error");
            }
        }
    }
}
