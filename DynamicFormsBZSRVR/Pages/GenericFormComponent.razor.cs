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
            //@onchange="@(e=>valueChanged(e,fld))"
            lookUps.Add("countries", ListItem.CreateList("Select Country,Canada,USA,Uruguay", ",CA,US,UY"));
            lookUps.Add("usastates", ListItem.CreateList("Select State,Alabama,Alaska,Arizona,Arkansas,California,Colorado", ",AL,AK,AZ,AR,CA,CO"));
            lookUps.Add("canadastates", ListItem.CreateList("Select State,Alberta,British Columbia,Manitoba,New Brunswick", ",AB,BC,MB,NB"));
            lookUps.Add("uruguaystates", ListItem.CreateList("Select State,Montevideo,Punta del Este,Colonia", ",MVD,PE,CO"));
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
                    else if (value == "US")
                        fld.LookUp = "usastates";
                    else if (value == "UY")
                        fld.LookUp = "uruguaystates";
                    else
                        fld.LookUp = "";
                    //this.StateHasChanged();
                }
            }
            else if ( field.Key == "address")
            {
                var fld = Tab.Fields.Where(x => x.Key == "address2").FirstOrDefault();
                if (fld != null)
                    fld.Visible = !string.IsNullOrEmpty(field.Value);
            }
        }


        protected void valueChanged(ChangeEventArgs e, FieldBase  field)
        {
            if (field.Key == "country")
            {
                var fld = Tab.Fields.Where(x => x.Key == "state").FirstOrDefault();
                if (fld != null)
                {
                    if (e.Value.ToString() == "CA")
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

        protected void Submit()
        {

        }

    }
}
