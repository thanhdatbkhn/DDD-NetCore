using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using iStorage.Business.Services;

namespace IStorage.Filters
{
    public class AuthorizeFilter : IAsyncAuthorizationFilter
    {
        private readonly ITokensService _tokenService;
        private readonly IUsersService _userService;
        public AuthorizeFilter(ITokensService tokensService, IUsersService usersService)
        {
            _tokenService = tokensService;
            _userService = usersService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!IsProtectedAction(context))
                return;

            if (!IsUserAuthenticated(context))
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }


            //var userSignIn = this.SignInManager.UserManager.GetUserAsync(context.HttpContext.User).Result;
            //var userSystems = UserSystemService.GetUserSystemsByUserId(userSignIn.Id);
            //if (userSystems != null)
            //{
            //    var userSystemTMS = userSystems.FirstOrDefault(x => x.SystemType == SystemTypes.TMS);
            //    var userSystemAdmin = userSystems.FirstOrDefault(x => x.SystemType == SystemTypes.ADMIN);
            //    if (userSystemAdmin != null)
            //        return;
            //    string controller, action;
            //    GetControllerAction(context, out controller, out action);
            //    if (userSystemTMS != null && !userSystemTMS.Enable)
            //    {
            //        context.Result = UserBannedContextResult(context);
            //    }
            //    else if (userSystemTMS == null || !RolePermissionService.CheckRolePermissionForUser(userSystemTMS.UserId, controller, action, SystemTypes.TMS))
            //    {
            //        context.Result = PermissionDenyContextResult(context);
            //    }
            //}
            //else
            //{
            //    context.Result = UserBannedContextResult(context);
            //}
        }

        private IActionResult UserBannedContextResult(AuthorizationFilterContext context)
        {
            if (IsAjaxRequest(context.HttpContext.Request))
            {
                return new StatusCodeResult(-999);
            }
            else
            {
                return new RedirectToActionResult("Logout", "Account", null);
            }
        }

        private IActionResult PermissionDenyContextResult(AuthorizationFilterContext context)
        {
            if (IsAjaxRequest(context.HttpContext.Request))
            {
                return new JsonResult("Unauthorized") { StatusCode = 401 };
            }
            else
            {
                return context.Result = new ViewResult { ViewName = "~/Views/Error/ErrorRole.cshtml" };
                //return context.Result = new RedirectToRouteResult((new RouteValueDictionary(new { controller = "Error", action = "ErrorRole" })));
            }
        }

        private bool IsProtectedAction(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
                return false;

            var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var controllerTypeInfo = controllerActionDescriptor.ControllerTypeInfo;
            var actionMethodInfo = controllerActionDescriptor.MethodInfo;

            var authorizeAttribute = controllerTypeInfo.GetCustomAttribute<AuthorizeAttribute>();
            if (authorizeAttribute != null)
                return true;

            authorizeAttribute = actionMethodInfo.GetCustomAttribute<AuthorizeAttribute>();
            if (authorizeAttribute != null)
                return true;

            return false;
        }

        private bool IsUserAuthenticated(AuthorizationFilterContext context)
        {
            return context.HttpContext.User.Identity.IsAuthenticated;
        }

        private void GetControllerAction(AuthorizationFilterContext context, out string controller, out string action)
        {
            var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var area = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttribute<AreaAttribute>()?.RouteValue;
            controller = controllerActionDescriptor.ControllerName;
            action = controllerActionDescriptor.ActionName;
        }

        private bool IsAjaxRequest(HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            //if (request["X-Requested-With"] == "XMLHttpRequest")
            //return true;
            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }
    }
}
