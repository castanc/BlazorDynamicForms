using System;
using System.Collections.Generic;

namespace DynamicFormsModels
{
    public class Section
    {
        public List<Page> Pages { set; get; }
        public string Title { set; get; }
        public bool Complete { set; get; }
        public string Key { set; get; }
        public bool Selected;
        public int Id { set; get; }


        public Section()
        {
            Pages = new List<Page>();
        }

        public void AddPage(Page page)
        {
            page.Id = Pages.Count;
            Pages.Add(page);
        }

        public void AddField(int pageId, int tabId, UIField field)
        {
            Pages[pageId].Tabs[tabId].AddField(field);
        }

    }
}
