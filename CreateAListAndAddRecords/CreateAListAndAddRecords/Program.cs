using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAListAndAddRecords
{
    class Program
    {
        static void Main(string[] args)
        {
            string Url = "http://localhost:25000";
            ClientContext ctx = new ClientContext(Url);
            Web web = ctx.Web;


            ListCreationInformation lci = new ListCreationInformation();
            lci.Title = "ITAcademyCourses";
            lci.TemplateType = (int)ListTemplateType.GenericList;
            lci.Description = "ITAcademy Courses";

            List list = web.Lists.Add(lci);

            Field CourseName = list.Fields.AddFieldAsXml("<Field Type='Text' DisplayName='CourseName' />", true, AddFieldOptions.DefaultValue);
            Field TrainerName = list.Fields.AddFieldAsXml("<Field Type='Text' DisplayName='TrainerName' />", true, AddFieldOptions.DefaultValue);
            Field Duration = list.Fields.AddFieldAsXml("<Field Type='Number' DisplayName='Duration' />", true, AddFieldOptions.DefaultValue);

            string CategoryChoices = "<Field  Type='Choice'  DisplayName='Category' Name='Category'  Format = 'Dropdown' > "
  + "<Default>Web Development</Default>"
  + "<CHOICES>"
  + "    <CHOICE>Web Development</CHOICE>"
  + "    <CHOICE>Web Designing</CHOICE>"
  + "</CHOICES>"
  + "</Field>";

            Field choiceField = list.Fields.AddFieldAsXml(CategoryChoices, true, AddFieldOptions.DefaultValue);

            ListItemCreationInformation lic = new ListItemCreationInformation();
            ListItem listItem = list.AddItem(lic);
            listItem["CourseName"] = "SharePoint 2013";
            listItem["TrainerName"] = "Kameswara Sarma Uppuluri";
            listItem["Duration"] = 24;
            listItem["Category"] = "Web Development";
            listItem["Title"] = "SPS 2013";
            listItem.Update();

            listItem = list.AddItem(lic);
            listItem["CourseName"] = "SharePoint 2010";
            listItem["TrainerName"] = "Kameswara Sarma Uppuluri";
            listItem["Duration"] = 24;
            listItem["Category"] = "Web Development";
            listItem["Title"] = "SPS 2010";
            listItem.Update();

            ctx.ExecuteQuery();

            Console.WriteLine("List has been created and records have been added..");

            Console.ReadKey();
        }
    }
}
