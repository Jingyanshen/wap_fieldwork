using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SH3H.WAP.WebApi.Filters
{
    /// <summary>
    /// 定义平台Action过滤器
    /// </summary>
    public class WapActionFillterAttribute : ActionFilterAttribute
    {
        public override void  OnActionExecuting(HttpActionContext actionContext)
        {

        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {

        }
    }
}