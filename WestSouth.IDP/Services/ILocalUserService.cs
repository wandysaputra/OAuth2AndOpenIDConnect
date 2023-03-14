using Marvin.IDP.Entities;
using WestSouth.IDP.Entities;

namespace WestSouth.IDP.Services;

public interface ILocalUserService
{
    Task<bool> ValidateCredentialsAsync(
        string userName,
        string password);

    Task<IEnumerable<UserClaim>> GetUserClaimsBySubjectAsync(
        string subject);

    Task<User> GetUserByUserNameAsync(
        string userName);

    Task<User> GetUserBySubjectAsync(
        string subject);

    void AddUser
        (User userToAdd);

    Task<bool> IsUserActiveAsync(string subject);

    Task<bool> SaveChangesAsync();
}