using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace GetListOfLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientContext ctx = new ClientContext("http://localhost:25000");

            Web web = ctx.Web;

            ctx.Load(web);

             ctx.Load(web.Lists);

            //ctx.Load(web, wc => wc.Lists.Where(lic => lic.ItemCount >= 1));

            // ctx.Load(web, wc => wc.Lists.Where(list => list.BaseTemplate == 105));

            ctx.Load(web, wc => wc.Lists.Where(list => list.BaseType == BaseType.GenericList));



            ctx.ExecuteQuery();

            foreach(var list in web.Lists)
            {

                Console.WriteLine("List Title is : {0}",list.Title);
            }

            Console.WriteLine("Lists Count is : {0}",web.Lists.Count);
            Console.ReadKey();
        }
    }
}
