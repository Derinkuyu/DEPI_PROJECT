namespace StuMap.Managers
{
    using DTO.Admin;

    public interface IUserManager
    {
        List<UserDto> GetAll();

        UserDetailsDto GetById(string id);

        void Delete(string id);

        void Block(string id);
        void Unblock(string id);
    }
}
