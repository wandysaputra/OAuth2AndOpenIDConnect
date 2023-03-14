using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WestSouth.IDP.Pages.User.ActivationCodeSent;

[SecurityHeaders]
[AllowAnonymous]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}