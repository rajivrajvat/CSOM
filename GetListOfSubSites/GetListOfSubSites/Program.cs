using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetListOfSubSites
{
    class Program
    {
        static string ParentSitePath = "http://localhost:25000";
        static void Main(string[] args)
        {

            GetListOfSubSites(ParentSitePath);
            Console.ReadKey();
        }

        public static void GetListOfSubSites(string url)
        {
            try
            {
                ClientContext ctx = new ClientContext(url);
                Web web = ctx.Web;
                ctx.Load(web, ws => ws.Webs, ws => ws.Title);
                ctx.ExecuteQuery();

                foreach (Web ChildWeb in web.Webs)
                {
                    string ChildWebSitePath = ParentSitePath + ChildWeb.ServerRelativeUrl;
                    GetListOfSubSites(ChildWebSitePath);
                    Console.WriteLine(ChildWebSitePath + "\n" + ChildWeb.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error is {0}", ex.Message);
            }
        }
    }
}
