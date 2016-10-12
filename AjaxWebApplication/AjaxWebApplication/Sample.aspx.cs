using System;
using System.Web.Services;

namespace AjaxWebApplication
{
    public partial class Sample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        [WebMethod]
        public static string GetEmployees()
        {
            return "{ 'records':[ {'Name':'Alfreds Futterkiste','City':'Berlin','Country':'Germany'}] }";
        }
    }  
}