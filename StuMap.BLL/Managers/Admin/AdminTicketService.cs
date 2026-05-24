using Microsoft.EntityFrameworkCore;
using StuMap.BLL.DTO.Admin;
using StuMap.BLL.Models;
using StuMap.BLL.Services.Admin;
using StuMap.DAL.Models;
using StuMap.DAL.Models.Enums;
using StuMap.DAL.Repositories.Interfaces;
using System.Net;

namespace StuMap.BLL.Managers.Admin
{
    public class AdminTicketService(
        IGenericRepository<Contact> contactRepository) : IAdminTicketService
    {
        public async Task<ApiResponse> AcceptTicket(int id, string reply)
        {
            try
            {
                var contact = await contactRepository.GetByIdAsync(id);
                if (contact != null)
                {
                    contact.Status = TicketStatusEnum.Considered;
                    contact.AdminReply = reply;
                    await contactRepository.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse.FailureResult("Error");
            }
        }

        public async Task<ApiResponse> DeleteTicket(int id)
        {
            try
            {
                var contact = await contactRepository.GetByIdAsync(id);
                if (contact != null)
                {
                    contactRepository.Remove(contact);
                    await contactRepository.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<List<Contact>>> GetAllTickets()
        {
            try
            {
                var result = await contactRepository.Query()
               .Include(c => c.User)
               .ToListAsync();

                return ApiResponse<List<Contact>>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<Contact>>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<Contact>> GetTicketById(int id)
        {
            try
            {
                var result = await contactRepository.Query()
               .Include(c => c.User)
               .Where(c => c.Id == id)
               .FirstOrDefaultAsync();

                if (result == null)
                    return ApiResponse<Contact>.FailureResult("Ticket Not Found", HttpStatusCode.NotFound);

                result.IsRead = true;
                await contactRepository.SaveChangesAsync();

                return ApiResponse<Contact>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<Contact>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse<List<Contact>>> GetTicketsByUser(string userId)
        {
            try
            {
                var result = await contactRepository.Query()
               .Include(c => c.User)
               .Where(c => c.User!.Id == userId)
               .ToListAsync();

                return ApiResponse<List<Contact>>.SuccessResult(result);
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse<List<Contact>>.FailureResult("Error");
            }
        }

        public async Task<ApiResponse> RejectTicket(int id, string reason)
        {
            try
            {
                var contact = await contactRepository.GetByIdAsync(id);
                if (contact != null)
                {
                    contact.Status = TicketStatusEnum.Denied;
                    contact.RejectionReason = reason;
                    await contactRepository.SaveChangesAsync();
                }

                return ApiResponse.SuccessResult();
            }
            catch (Exception)
            {
                // todo: implement
                return ApiResponse.FailureResult("Error");
            }
        }
    }
}
