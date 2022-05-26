using Microsoft.AspNetCore.Authorization;
using Sab.Authentication.Features.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sab.Authentication.Features
{
    public class SeniorEmployeeRequirementHandler : AuthorizationHandler<SeniorEmployeeRequirementCommand>
    {
        private readonly IUserInfoProvider _userInfoProvider;

        public SeniorEmployeeRequirementHandler(IUserInfoProvider userInfoProvider)
        {
            this._userInfoProvider = userInfoProvider;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            SeniorEmployeeRequirementCommand requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                return Task.CompletedTask;
            }

            var name = context.User.FindFirst(c => c.Type == ClaimTypes.Name);

            if(this._userInfoProvider.IsSeniorUser(name.Value))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
