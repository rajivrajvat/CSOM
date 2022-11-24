using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteRecordsOfAList
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientContext ctx = new ClientContext("http://localhost:25000");

            Web web = ctx.Web;

            List lst = web.Lists.GetByTitle("CourseCategories");

            CamlQuery query = new CamlQuery();

            ListItemCollection lic = lst.GetItems(query);

            ctx.Load(lic);

            ctx.ExecuteQuery();

            foreach (ListItem li in lic.ToList())
            {
                li.DeleteObject();
            }

            ctx.ExecuteQuery();
            Console.WriteLine("All records have been deleted..");
            Console.ReadKey();
        }
    }
}
