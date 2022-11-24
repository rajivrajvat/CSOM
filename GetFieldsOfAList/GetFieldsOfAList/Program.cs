using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFieldsOfAList
{
    class Program
    {
        static void Main(string[] args)
        {
            string siteUrl = "http://localhost:25000";

            ClientContext clientContext = new ClientContext(siteUrl);

            Web site = clientContext.Web;
            List taskList = site.Lists.GetByTitle("Trainers");

            FieldCollection collField = taskList.Fields;

            Field oneField = collField.GetByInternalNameOrTitle("WorkPhone");
            oneField.Required = true;
            oneField.Update();

            clientContext.Load(collField);
            clientContext.Load(oneField);
            clientContext.ExecuteQuery();

            foreach (var f in collField)
            {
                Console.WriteLine("Field Internal Name is : {0} TItle is : {1}", f.InternalName, f.Title);
            }
            Console.ReadKey();
        }
    }
}
