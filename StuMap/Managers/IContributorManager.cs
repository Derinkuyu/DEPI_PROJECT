namespace StuMap.Managers
{
    using DTO.Admin;

    public interface IContributorManager
    {
        List<ContributorRequestDto> GetPendingRequests();

        List<ContributorRequestDto> GetAllContributors();

        ContributorDetailsDto GetContributorById(string id);

        void ApproveContributor(string id);

        void RejectContributor(string id, string reason);
    }
}
