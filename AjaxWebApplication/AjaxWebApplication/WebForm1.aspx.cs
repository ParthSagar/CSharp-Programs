using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Web.Script.Serialization;
using System.Web.Services;
using Data;
using Newtonsoft.Json;

namespace AjaxWebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
              
            }
        }

        [WebMethod]
        public static ItemMasterList GetData()
        {
            /*Dictionary<string, string> name = new Dictionary<string, string>();
            name.Add("1", "Sourav Kayal");
            name.Add("2", "Ram mishra");
            // my complicated logic goes here
            // json dataArray = obj.ComplicatedMethod(params);
            // return jsonStr;
            string myJsonString = (new JavaScriptSerializer()).Serialize(name);
            return myJsonString;*/
            string myJsonString;

            var select = MyObj.GetData();
            var serializer = new JavaScriptSerializer();
            
            myJsonString = serializer.Serialize(select);
           
            return select;
            

        }

        [WebMethod]
        public static bool SaveData(string item,int qty,DateTime date,string phone)
        {
            var select = MyObj.InsertData(item, qty, date, phone);

         /*   return new JavaScriptSerializer().Serialize(
                "Hello, " + item + ", " + qty + " " + date+ " "+ phone+"!");*/

            return select;
            //return "Hello i am parth";


        }

        [WebMethod]
        public static bool DeleteData(int id)
        {
            var select = MyObj.DeleteData(id);
            return select;
            
        }


       
    }


}
