using MicroGroup.Business.Session;
using MicroGroup.Business.Utilities.AuthorizeHelpers;
using MicroGroup.Core.Constant;
using MicroGroup.Core.Exceptions;
using MicroGroup.Core.Utilities.AppSettings;
using MicroGroup.Core.Utilities.Attributes;
using MicroGroup.Model.Authorize;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace MicroGroup.Api.Middlewares
{
    public class CustomAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<MicroGroupSettings> _microGroupSetting;


        public CustomAuthMiddleware(RequestDelegate next, IOptions<MicroGroupSettings> microGroupSetting)
        {
            _next = next;
            _microGroupSetting = microGroupSetting;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var endpoint = httpContext.GetEndpoint();

            if (endpoint is not null)
            {
                var hasPerm = endpoint.Metadata.OfType<HasPermissionAttribute>().ToList();

                if (hasPerm is not null && hasPerm.Count != 0)
                {
                    var token = httpContext.Request.Headers["Authorization"].ToString();

                    if (token.IsNullOrEmpty())
                        throw new CustomException(TokenConstant.NOT_FOUND_TOKEN, HttpStatusCode.Unauthorized);

                    try
                    {
                        var tokenHelper = new TokenHelper(_microGroupSetting);
                        var loginUser = tokenHelper.ValidateToken(token);

                        if (loginUser is null)
                            throw new CustomException(TokenConstant.INVALID_TOKEN, HttpStatusCode.Unauthorized);

                        new SessionManager(httpContext)
                        {
                            User = new UserSessionModel
                            {
                                Username = loginUser.Username,
                                PersonnelId = loginUser.PersonnelId,
                                Roles = loginUser.Roles
                            }
                        };

                    }
                    catch (CustomException customException)
                    {
                        throw customException;
                    }
                    catch (Exception)
                    {
                        throw new CustomException(TokenConstant.NOT_FOUND_TOKEN, HttpStatusCode.Unauthorized);
                    }
                }

            }

            await _next(httpContext);
        }
    }
    public static class CustomAuthMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomAuthMiddleware>();
        }
    }
}
