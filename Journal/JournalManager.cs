using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Media.Devices;
using Windows.Services.TargetedContent;

namespace Journal
{
    internal class JournalManager
    {
        public static string FILENAME = @"C:\Users\Guest1\source\repos\Journal\Journal\data.xml";

        /// <summary>
        /// 
        /// Sorted Dictionary mapping DateTime (which will always be converted to a date only) and an Entry
        /// </summary>
        private SortedDictionary<DateTime, Entry> entries;

        /// <summary>
        /// Singleton instance
        /// </summary>
        private static JournalManager instance = new JournalManager();

        private JournalManager()
        {
            try
            {
                LoadXml();
            }
            catch(Exception ex)
            {
                entries = new SortedDictionary<DateTime, Entry>(Comparer<DateTime>.Create(
                delegate (DateTime x, DateTime y)
                {
                    return y.CompareTo(x);
                }
                ));
            }
        }
          
        public static JournalManager GetInstance()
        {
            return instance;
        }


        public void AddEntry(Entry entry)
        {
            try {
                entries.Add(entry.Date.Date, entry);
                
                SaveToXml();
            }
            
            catch(ArgumentException e)
            {
                //todo
            }
            
        }


        public void Clear()
        {
            entries.Clear();
        }
        
        public Entry GetEntry(DateTime date)
        {
            return entries[date.Date];
        }

        public SortedDictionary<DateTime, Entry> Entries()
        {
            return entries;
        }

        public void SaveToXml()
        {
            entries.SaveToXml(FILENAME);
        }

        public void LoadXml()
        {
            entries = new SortedDictionary<DateTime, Entry>(   MySerializer.LoadFromXml<DateTime, Entry>(FILENAME), Comparer<DateTime>.Create(delegate (DateTime x, DateTime y)
            {
                return y.CompareTo(x);
            }
            ));
        }
 
    }

    public class KeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }



    /// <summary>
    ///  from https://stackoverflow.com/questions/27441077/how-to-save-an-entire-dictionary-locally-and-load-it-when-needed
    /// </summary>
    static class MySerializer
    {
        public static void SaveToXml<TKey, TValue>(this SortedDictionary<TKey, TValue> dictionary, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<KeyValue<TKey, TValue>>));
            //Debug.WriteLine(Path.GetFullPath(fileName));
            using (var s = new StreamWriter(fileName))
            {
                serializer.Serialize(s, dictionary.Select(x => new KeyValue<TKey, TValue>() { Key = x.Key, Value = x.Value }).ToList());
            }
        }

        public static Dictionary<TKey, TValue> LoadFromXml<TKey, TValue>(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<KeyValue<TKey, TValue>>));

            using (var s = new StreamReader(fileName))
            {
                var list = serializer.Deserialize(s) as List<KeyValue<TKey, TValue>>;
                return list.ToDictionary(x => x.Key, x => x.Value);
            }
        }

    }
}
