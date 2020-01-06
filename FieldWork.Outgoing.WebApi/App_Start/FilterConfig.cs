using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FieldWork.Outgoing.WebApi.Filters;

namespace FieldWork.Outgoing.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            GlobalConfiguration.Configuration.Filters.Add(new WapExceptionFilterAttribute());
            GlobalConfiguration.Configuration.Filters.Add(new WapActionFillterAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
