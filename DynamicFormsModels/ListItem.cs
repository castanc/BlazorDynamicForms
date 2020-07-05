using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicFormsModels
{
    public class ListItem
    {
        public string Key { set; get; }
        public string Value { set; get; }


        public static List<ListItem>CreateList(string values, char lineSeparator = ';', char colSeparator = ',')
        {
            List<ListItem> list = new List<ListItem>();
            if ( values.Contains(lineSeparator.ToString()))
            {
                var lines = values.Split(lineSeparator);
                foreach(var l in lines)
                {
                    var cols = l.Split(colSeparator);
                    list.Add(new ListItem() { Key = cols[0], Value = cols[1] });
                }

            }
            else if (values.Contains(colSeparator.ToString()))
            {
                int id = 0;
                var cols = values.Split(colSeparator);
                foreach(string c in cols)
                {
                    list.Add(new ListItem() { Key = id.ToString(), Value = cols[0] });
                    id++;
                }
            }
            return list;
        }
        public static List<ListItem> CreateList(string values, string keys="", char separator = ',')
        {
            List<ListItem> list = new List<ListItem>();
            var kys = keys.Split(separator);
            var vals = values.Split(separator);

            if ( kys.Length>0)
            {
                for (int i = 0; i < kys.Length; i++)
                    list.Add(new ListItem() { Key = kys[i], Value = vals[i] });
            }
            else
            {
                for (int i = 0; i < vals.Length; i++)
                    list.Add(new ListItem() { Key = i.ToString(), Value = vals[i] });

            }
            return list;
        }
    }
}
