using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire.Dashboard;

namespace Webnovel.Filters
{
    public class HangDashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
          
            var httpContext = context.GetHttpContext();
            return  httpContext.User.IsInRole("Admin");
        }
    }
}
