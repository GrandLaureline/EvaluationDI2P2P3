using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class ApiKeyFilter : IAuthorizationFilter
    {
        private readonly string _apiKey;

        public ApiKeyFilter(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (!filterContext.HttpContext.Request.Headers.ContainsKey("ApiKey")
                || filterContext.HttpContext.Request.Headers["ApiKey"] != _apiKey)
            {
                filterContext.Result = new UnauthorizedResult();
            }
        }
    }
}
