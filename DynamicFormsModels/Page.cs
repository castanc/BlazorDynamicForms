using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicFormsModels
{
    public class Page
    {
        public List<Tab> Tabs { set; get; }
        public string Title { set; get; }
        public bool Visible { set; get; }
        public bool Valid { set; get; }
        public string Key { set; get; }
        public int Id { set; get; }
        public string Label { set; get; }

        public Page()
        {
            Tabs = new List<Tab>();
        }

        public void AddTab(Tab tab)
        {
            tab.Id = Tabs.Count;
            Tabs.Add(tab);
        }

    }
}
