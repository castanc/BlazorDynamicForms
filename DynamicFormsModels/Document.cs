using System;
using System.Collections.Generic;
using System.Text;
using UtilsSTD;


namespace DynamicFormsModels
{
    public class Document
    {
        public string Id { set; get; }
        public List<Section> Sections { set; get; }
        public bool Valid { set; get; }

        public Document()
        {
            Sections = new List<Section>();
            Valid = false;
        }

        public void AddSection(Section section)
        {
            section.Id = Sections.Count;
            Sections.Add(section);
        }

        public void AddField(int sectionId, int pageId, int tabId, UIField field)
        {
            Sections[sectionId].AddField(pageId, tabId, field);
        } 
    }
}
