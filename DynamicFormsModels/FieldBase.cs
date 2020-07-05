using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace DynamicFormsModels
{
    public delegate void delegateValueChanged(FieldBase field, string value);
    public class FieldBase
    {
        public static event delegateValueChanged OnValueChanged;
        public int Id { set; get; }
        public string Key { set; get; }
        public string Name { set; get; }
        public Type Type { set; get; }
        public string StringValue { set; get; }

        private string JSONvalue = "";

        private string val = "";
        public string Value 
        {
            set
            {
                string oldValue = val;
                val = value;
                if (OnValueChanged != null) 
                    OnValueChanged.Invoke(this, value);            }
            get
            {
                return val;
            }
        }

        public bool Selected(string val)
        {
            return val == Value;
        }

        /*
        public DateTime DateTimeValue;
        public double DoubleValue;
        public decimal DecimalVale;
        public int IntValue;
        public bool BoolValue;
        */


    }
}
