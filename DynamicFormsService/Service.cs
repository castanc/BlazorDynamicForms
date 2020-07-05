using System;
using DynamicFormsModels;
using UtilsSTD;
using System.IO;


namespace DynamicFormsService
{
    public class Service
    {
        public string JSONFileName = "dynamicForm.json";
        public string fileName = $"{System.Environment.CurrentDirectory}\\wwwroot\\dynamicForm.json";
        public Document GetMockDocument()
        {
            var doc = new Document();

            doc.AddSection(new Section() { Title = "Section 1" });
            doc.Sections[0].AddPage(new Page() { Label = "Basic Info" });
            doc.Sections[0].AddPage(new Page() { Label = "Case Management" });
            doc.Sections[0].AddPage(new Page() { Label = "Budget" });

            doc.Sections[0].Pages[0].AddTab(new Tab() { Title = "Personal Data" });
            doc.Sections[0].Pages[0].AddTab(new Tab() { Title = "Date Period" });
            doc.Sections[0].Pages[1].AddTab(new Tab() { Title = "Case Data" });
            doc.Sections[0].Pages[2].AddTab(new Tab() { Title = "Planning" });
            doc.Sections[0].Pages[2].AddTab(new Tab() { Title = "Execution" });

            doc.AddField(0, 0, 0, new UIField() { Key = "name", Label="Full Name",PlaceHolder="Full Name", InputType="text", Type = typeof(string), MaxLength = 40  });
            doc.AddField(0, 0, 0, new UIField() { Key = "address", Label = "Address", InputType = "text", Type = typeof(string), MaxLength = 40 });
            doc.AddField(0, 0, 0, new UIField() { Key = "country", Label = "Country", Type = typeof(string), LookUp = "countries", HTMLTag = "select" });
            doc.AddField(0, 0, 0, new UIField() { Key = "state", Label = "State", Type =  typeof(string), LookUp="usastates", HTMLTag="select"});
            //doc.AddField(0, 0, 0, new UIField() { Key = "city", Label = "City", Type = typeof(string), LookUp = "cities", HTMLTag = "select" });
            doc.AddField(0, 0, 0, new UIField() { Key = "date", Label = "Date", InputType = "date", Type = typeof(DateTime),  });
            //doc.AddField(0, 0, 0, new UIField() { Key = "firsttime", Label = "First Time", InputType = "checkbox", Type = typeof(string), MaxLength = 40 });

            doc.AddField(0, 0, 1, new UIField() { Key = "datestart", Label = "Start Date", InputType = "date", Type = typeof(DateTime), });
            doc.AddField(0, 0, 1, new UIField() { Key = "dateend", Label = "End Date", InputType = "date", Type = typeof(DateTime), });


            doc.AddField(0, 1, 0, new UIField() { Key = "casedescription", Label = "Case Description", PlaceHolder = "Full Name", InputType = "text", Type = typeof(string), MaxLength = 40 });
            doc.AddField(0, 1, 0, new UIField() { Key = "phone", Label = "Phone", InputType = "text", Type = typeof(string), MaxLength = 40 });
            doc.AddField(0, 1, 0, new UIField() { Key = "allday", Label = "All Day", InputType = "checkbox", Type = typeof(string), MaxLength = 40 });
            doc.AddField(0, 1, 0, new UIField() { Key = "date", Label = "Date", InputType = "date", Type = typeof(DateTime), });
            doc.AddField(0, 1, 0, new UIField() { Key = "state", Label = "State", Type = typeof(string), LookUp = "usastates", HTMLTag = "select" });


            doc.AddField(0, 2, 0, new UIField() { Key = "date", Label = "Date", InputType = "date", Type = typeof(DateTime), });
            doc.AddField(0, 2, 0, new UIField() { Key = "state", Label = "State", Type = typeof(string), LookUp = "usastates", HTMLTag = "select" });
            doc.AddField(0, 2, 0, new UIField() { Key = "fullperiod", Label = "Full period", InputType = "checkbox", Type = typeof(string), MaxLength = 40 });
            doc.AddField(0, 2, 0, new UIField() { Key = "allday", Label = "All Day", InputType = "checkbox", Type = typeof(string), MaxLength = 40 });
            doc.AddField(0, 2, 1, new UIField() { Key = "date", Label = "Future Start Date", InputType = "date", Type = typeof(DateTime), });
            doc.AddField(0, 2, 1, new UIField() { Key = "state", Label = "State", Type = typeof(string), LookUp = "usastates", HTMLTag = "select" });


            /*
            doc.AddSection(new Section() { Title = "Section 2" });
            doc.Sections[1].AddPage(new Page() { Label = "Page 1" });
            doc.Sections[1].AddPage(new Page() { Label = "Page 2" });
            doc.Sections[1].Pages[0].AddTab(new Tab() { Title = "Tab 1" });
            doc.Sections[1].Pages[0].AddTab(new Tab() { Title = "Tab 2" });
            */

            string jsonText = doc.NewtonSoftJSONSerialize<Document>();
            File.WriteAllText(fileName, jsonText);
            return doc;
        }
    }
}
