using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal
{
    internal class JournalManager
    {
        private Dictionary<DateOnly, Entry> entries;

        private static JournalManager instance = new JournalManager();

        private JournalManager()
        {
            entries = new Dictionary<DateOnly, Entry>();
        }

        public static JournalManager GetInstance()
        {
            return instance;
        }


        public void AddEntry(Entry entry)
        {
            try { 
                entries.Add(DateOnly.FromDateTime(entry.GetDate()), entry); }
            catch(ArgumentException e)
            {
                
            }
            
        }


        public void Clear()
        {
            entries.Clear();
        }
        
        public Entry GetEntry(DateTime date)
        {
            return entries[DateOnly.FromDateTime(date)];
        }

        public Entry GetEntry(DateOnly date)
        {
            return entries[date];
        }

    }
}
