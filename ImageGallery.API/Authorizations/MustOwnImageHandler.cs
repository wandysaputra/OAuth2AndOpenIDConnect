using IdentityModel;
using ImageGallery.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace ImageGallery.API.Authorizations;

public class MustOwnImageHandler : AuthorizationHandler<MustOwnImageRequirement>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IGalleryRepository _galleryRepository;

    public MustOwnImageHandler(IHttpContextAccessor contextAccessor, IGalleryRepository galleryRepository)
    {
        _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
        _galleryRepository = galleryRepository;
    }
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MustOwnImageRequirement requirement)
    {
        
        var imageId = _contextAccessor?.HttpContext?.GetRouteValue("id")?.ToString();
        if (!Guid.TryParse(imageId, out var imageGuid))
        {
            context.Fail(new AuthorizationFailureReason(this, "Invalid image!"));
            return;
        }

        // get the sub claim
        var ownerId = context.User?.Claims?.FirstOrDefault(f => f.Type == JwtClaimTypes.Subject)?.Value;

        if (ownerId == null)
        {
            context.Fail(new AuthorizationFailureReason(this, "Invalid owner!"));
            return;
        }

        if (!await _galleryRepository.IsImageOwnerAsync(imageGuid, ownerId))
        {
            context.Fail(new AuthorizationFailureReason(this, "Invalid image owner!"));
            return;
        }

        context.Succeed(requirement);
    }
}