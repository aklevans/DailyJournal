using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Background;

namespace Journal
{
    public class Entry
    {

        public DateTime Date { get; set; }
        public string Text { get; set; }


        public Entry()
        {

        }

        public Entry(string text, DateTime date)
        {
            Text = text;
            Date = date;
        }



    }
}
