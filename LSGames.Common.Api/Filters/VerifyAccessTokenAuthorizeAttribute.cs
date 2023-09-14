using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using LSGames.Common.Api.HttpClients;
using LSGames.Common.Api.Models.ServiceModels;

namespace LSGames.Common.Api.Filters
{
    public class VerifyAccessTokenAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private SingleSignOnClient _singleSignOnClient;

        public VerifyAccessTokenAuthorizeAttribute(SingleSignOnClient httpClient)
        {
            _singleSignOnClient = httpClient;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var accessToken = context.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(accessToken))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            UserServiceModel? authorized = await _verifyAccessToken(accessToken);

            if (authorized == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            context.HttpContext.Items["User"] = authorized;
        }

        private async Task<UserServiceModel?> _verifyAccessToken(string? accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                return null;
            }

            _singleSignOnClient.AddHeaders("Authorization", accessToken);

            var result = await _singleSignOnClient.VerifyAuthorization();

            if (!result.IsSuccessStatusCode)
            {
                return null;
            };

            HttpClientBaseResponseServiceModel<UserServiceModel>? response =
                await result.Content.ReadFromJsonAsync<HttpClientBaseResponseServiceModel<UserServiceModel>>();

            return response == null ? null : response.Data;
        }
    }
}
