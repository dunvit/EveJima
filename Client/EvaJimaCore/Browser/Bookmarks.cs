using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using log4net;

namespace EveJimaCore.Browser
{
    public class Bookmarks
    {
        public readonly Dictionary<int, Address> List = new Dictionary<int, Address>();

        private static readonly ILog Log = LogManager.GetLogger(typeof(Bookmarks));

        public int CurrentIndex { get; set; }

        public Bookmarks()
        {
            try
            {
                if (!File.Exists("Data/bookmarks.csv")) return;

                using (var sr = new StreamReader(@"Data/bookmarks.csv"))
                {
                    var records = new CsvReader(sr).GetRecords<Address>();

                    foreach (var record in records)
                    {
                        List.Add(record.Id, record);

                        CurrentIndex = record.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("[Browser.Bookmarks.Bookmarks] Critical error in load bookmarks. Exception = " + ex);
            }
        }

        public void Add(Address address)
        {
            if (address.Url == "http://") return;

            if (List.ContainsKey(CurrentIndex))
            {
                if (List[CurrentIndex].Url == address.Url) return;
            }

            var index = GetIndex();

            CurrentIndex = index + 1;

            List.Add(CurrentIndex, new Address { Id = CurrentIndex, Title = address.Title, Url = address.Url });

            WriteToFile();
        }

        public void Remove(string url)
        {
            if (url == "http://") return;

            Address elementForRemove = null;

            foreach (var value in List.Values)
            {
                if (value.Url.Trim() == url.Trim())
                {
                    elementForRemove = value;
                }
            }

            if (elementForRemove != null)
            {
                List.Remove(elementForRemove.Id);
            }
        }

        

        public bool IsExist(string url)
        {
            foreach (var address in List.Values)
            {
                if (address.Url.Trim() == url.Trim()) return true;

                if (address.Url.Trim() + @"/" == url.Trim()) return true;

                if (address.Url.Trim() == url.Trim() + @"/") return true;
            }

            return false;
        }

        private int GetIndex()
        {
            return List.Values.Select(address => address.Id).Concat(new[] { 0 }).Max();
        }

        private void WriteToFile()
        {
            using (var sw = new StreamWriter(@"Data/bookmarks.csv"))
            {
                var writer = new CsvWriter(sw);

                IEnumerable records = List.ToList();

                writer.WriteRecords(records);
            }
        }
    }

}
