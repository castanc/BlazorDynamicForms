using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicFormsModels
{
    public class UIField:FieldBase
    {
        public string HTMLTag { set; get; }
        public string InputType { set; get; }
        public string GroupName { set; get; }
        public int MaxLength { set; get; }
        public int MinLenght { set; get; }
        public bool Required { set; get; }
        public bool Hidden { set; get; }
        public bool Disabled { set; get; }
        public bool Protected { set; get; }
        public int Cols { set; get; }
        public int Rows { set; get; }
        public string Label { set; get; }
        public int LabelPosition { set; get; }
        public string PlaceHolder { set; get; }
        public string LookUp { set; get; }
        public object MaxValue { set; get; }
        public object MinValue { set; get; }
        public bool Visible { set; get; }

        public UIField()
        {
            Visible = true;
            PlaceHolder = "";
        }
    }
}
