using System.Security.Claims;

namespace datingapp1.Domain.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static int GetUserId(this ClaimsPrincipal user)
        {            
            var a = ClaimTypes.Name;
            var b = user.FindFirst(a);
            if(b == null) {
                return 0;
            }
            var c = int.Parse(b?.Value);
            
            return c;
        }
    }
}