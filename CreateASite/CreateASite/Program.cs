using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateASite
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:25000";
            string Description = "Created this site through CSOM Approach.";
            int Language = 1033;
            string Title = "NewSite";
            string SiteUrl = "NewSite";
            bool SitePermissions = true;
            string SiteTemplate = "STS#0";

            ClientContext ctx = new ClientContext(url);
            Web web = ctx.Web;

            WebCreationInformation wci = new WebCreationInformation();
            wci.Description = Description;
            wci.Language = Language;
            wci.Title = Title;
            wci.Url = SiteUrl;
            wci.UseSamePermissionsAsParentSite = SitePermissions;
            wci.WebTemplate = SiteTemplate;

            Web NewWeb = web.Webs.Add(wci);

            ctx.Load(
                NewWeb,
                w => w.Title,
                w => w.Description);

            ctx.ExecuteQuery();

            Console.WriteLine("Title: {0} Description: {1}", NewWeb.Title, NewWeb.Description);
            Console.ReadKey();
        }
    }
}
