using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicFormsService;
using DynamicFormsModels;
using UtilsSTD;

namespace DynamicFormsBZSRVR.Pages
{
    public class GenericFormComponentBase : ComponentBase
    {

        [Inject]
        public Service Service { set; get; }

        [Parameter]
        public Document Document { set; get; }

        protected Section Section;
        protected Page Page;
        protected Tab Tab;
        protected int currentSectionId = 0;
        protected Dictionary<string, List<ListItem>> lookUps = new Dictionary<string, List<ListItem>>();

        protected override Task OnInitializedAsync()
        {
            lookUps.Add("countries", ListItem.CreateList("Canada,USA", "US,CA"));
            lookUps.Add("usastates", ListItem.CreateList("Alabama,Alaska,Arizona,Arkansas,California,Colorado", "AL,AK,AZ,AR,CA,CO"));
            lookUps.Add("canadastates", ListItem.CreateList("Alberta,British Columbia,Manitoba,New Brunswick", "AB,BC,MB,NB"));
            Document = Service.GetMockDocument();
            FieldBase.OnValueChanged += FieldBase_OnValueChanged;
            if (Document.Sections.Count > 0)
            {
                Section = Document.Sections[0];
                Page = Section.Pages[0];
                Tab = Page.Tabs[0];
            }

            return base.OnInitializedAsync();
        }

        ~GenericFormComponentBase()
        {
            FieldBase.OnValueChanged -= FieldBase_OnValueChanged;
        }

        private void FieldBase_OnValueChanged(FieldBase field, string value)
        {
            if (field.Key == "country")
            {
                var fld = Tab.Fields.Where(x => x.Key == "state").FirstOrDefault();
                if (fld != null)
                {
                    if (value == "CA")
                        fld.LookUp = "canadastates";
                    else
                        fld.LookUp = "usastates";
                }
            }
        }

        protected void selectPage(int pageId)
        {
            Page = Section.Pages[pageId];
            Tab = Page.Tabs[0];
        }

        protected void selectTab(int tabId)
        {
            if (Page != null)
                Tab = Page.Tabs[tabId];
        }


    }
}
