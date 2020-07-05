using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicFormsModels
{
    public class Tab
    {
        public string Key { set; get; }
        public int Id { set; get; }
        public List<UIField> Fields { set; get; }
        public bool Touched { set; get; }
        public bool Valid { set; get; }
        public string Title { set; get; }
        public string Label { set; get; }

        public Tab()
        {
            Fields = new List<UIField>();
        }

        public void AddField(UIField field )
        {
            field.Id = Fields.Count;
            Fields.Add(field);
        }
    }
}
