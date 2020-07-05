using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicFormsService;
using DynamicFormsModels;
using UtilsSTD;

namespace DynamicForms.Pages
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
        protected string JSONText = "";
        protected int currentSectionId = 0;
        protected Dictionary<string, List<ListItem>> lookUps = new Dictionary<string, List<ListItem>>();

        protected override Task OnInitializedAsync()
        {
            lookUps.Add("usastates", ListItem.CreateList("Alabama,Alaska,Arizona,Arkansas,California,Colorado", "AL,AK,AZ,AR,CA,CO"));
            lookUps.Add("canadastates", ListItem.CreateList("Albertam,British Columbia,Manitoba,New Brunswick", "AB,BC,MB,NB"));
            Document = Service.GetMockDocument();
            JSONText = Document.JSONSerialize<Document>();
            if (Document.Sections.Count > 0)
            {
                Section = Document.Sections[0];
                Page = Section.Pages[0];
                Tab = Page.Tabs[0];
            }

            return base.OnInitializedAsync();
        }

        protected void selectPage(int pageId)
        {
            Page = Section.Pages[pageId];
        }

        protected void selectTab(int tabId)
        {
            if ( Page != null )
                Tab = Page.Tabs[tabId];
        }


    }
}
