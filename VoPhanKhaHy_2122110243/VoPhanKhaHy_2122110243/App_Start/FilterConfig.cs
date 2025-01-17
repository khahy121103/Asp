using System.Web;
using System.Web.Mvc;

namespace VoPhanKhaHy_2122110243
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
