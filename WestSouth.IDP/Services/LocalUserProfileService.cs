using System.Security.Claims;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;

namespace WestSouth.IDP.Services;

public class LocalUserProfileService : IProfileService
{
    private readonly ILocalUserService _localUserService;

    public LocalUserProfileService(ILocalUserService localUserService)
    {
        _localUserService = localUserService ?? throw new ArgumentNullException(nameof(localUserService));
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var subject = context.Subject.GetSubjectId();
        var claims = await _localUserService.GetUserClaimsBySubjectAsync(subject);

        context.AddRequestedClaims(claims.Select(c => new Claim(c.Type, c.Value)));
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var subjectId = context.Subject.GetSubjectId();
        context.IsActive = await _localUserService.IsUserActiveAsync(subjectId);
    }
}