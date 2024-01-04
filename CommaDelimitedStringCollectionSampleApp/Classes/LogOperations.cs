using System.Configuration;
using System.Text;

namespace CommaDelimitedStringCollectionSampleApp.Classes;
    internal class LogOperations
    {
        private static CommaDelimitedStringCollection _collection;

        public static void Initialize() { _collection = []; }
        public static void Add(string item) { _collection.Add(item); }

        public static string Finish()
        {
            StringBuilder builder = new();
            const string progress = "[Status] Downloading in progress";
            const string replacement = "[Status]: Download Cancelled";

            if (_collection.IndexOf(progress) > -1)
            {
                for (int index = 0; index < _collection.Count; index++)
                {

                    if (_collection[index] == progress)
                    {
                        _collection[index] = replacement;
                    }

                    builder.AppendLine(_collection[index]);
                }
            }
            else
            {
                foreach (var item in _collection)
                {
                    builder.AppendLine(item);
                }
            }

            _collection.Clear();
            return builder.ToString();
        }
    }
