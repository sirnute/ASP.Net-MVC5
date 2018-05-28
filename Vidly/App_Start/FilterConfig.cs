using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Redirects the user to an error page
            filters.Add(new HandleErrorAttribute());
            //Ensures only authorized logins can access functions of the app
            filters.Add(new AuthorizeAttribute());
        }
    }
}
