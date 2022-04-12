using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace GCEApi.Filters
{
    public class ValidaEntidadeAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var c = actionContext.RequestContext.RouteData;
            base.OnActionExecuting(actionContext);
        }
    }
}
