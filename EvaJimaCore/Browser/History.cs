using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using log4net;

namespace EveJimaCore.Browser
{
    public class History
    {
        public readonly Dictionary<int, Address>  List = new Dictionary<int, Address>();
        private static readonly ILog Log = LogManager.GetLogger(typeof(History));

        public int CurrentIndex { get; set; }

        public void Add(string url)
        {
            if (url == "http://") return;

            if (List.ContainsKey(CurrentIndex))
            {
                if (List[CurrentIndex].Url == url) return;
            }

            var index = GetIndex();

            if (index > CurrentIndex)
            {
                Remove(CurrentIndex + 1, index);

                index = CurrentIndex;
            }

            CurrentIndex = index + 1;

            List.Add(CurrentIndex, new Address { Id = CurrentIndex, Title = "", Url = url });

            WriteToFile();
        }

        public void UpdateTitle(string title)
        {
            try
            {
                if (List.Count <= 0) return;

                var currentAddress = List[CurrentIndex];

                currentAddress.Title = title;

                WriteToFile();
            }
            catch (Exception ex)
            {
                Log.Error("[Browser.History.UpdateTitle] Critical error in load bookmarks. Exception = " + ex);
            }
        }

        public Address GetCurrentAddress()
        {
            if (List.Count == 0) return null;

            return List[CurrentIndex];
        }

        private void Remove(int fromIndex, int index)
        {
            for (var i = fromIndex; i <= index; i++)
            {
                if(List.ContainsKey(i))
                {
                    List.Remove(List[i].Id);
                }
            }
        }

        public string Previous()
        {
            var address = Get(CurrentIndex - 1);

            if (address == null)
            {
                return string.Empty;
            }

            CurrentIndex = address.Id;

            return address.Url;
        }

        private Address Get(int id)
        {
            Address address = null;

            foreach (var value in List.Values.Where(value => value.Id == id)) { return value; }

            return address;
        }

        public string Next()
        {
            var address = Get(CurrentIndex + 1);

            if (address == null)
            {
                return string.Empty;
            }

            CurrentIndex = address.Id;

            return address.Url;
        }

        private int GetIndex()
        {
            int index = 0;

            foreach (var address in List.Values)
            {
                if (address.Id > index) index = address.Id;
            }

            return index;
        }

        private void WriteToFile()
        {
            using (var sw = new StreamWriter(@"Data/browserhistory.csv"))
            {
                var writer = new CsvWriter(sw);

                IEnumerable records = List.ToList();

                writer.WriteRecords(records);
            }
        }
    }
}
