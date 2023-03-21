using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Background;

namespace Journal
{
    internal class Entry
    {
        DateTime date;

        string text;

        public Entry(string text, DateTime date)
        {
            this.text = text;
            this.date = date;
        }

        public String GetText() { return this.text; }

        public void SetText(string text) { this.text = text;}

        public DateTime GetDate() { return this.date; }
        public void SetDate(DateTime date) { this.date = date; }


    }
}
