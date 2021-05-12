using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EnumerableCsv
{
    class CsvEnumerable<T> : IEnumerable<T>, IEnumerator<T>, IDisposable
    {
        private int index = -1;
        readonly List<T> _csvRecords = new List<T>();

        T IEnumerator<T>.Current
        {
            get
            {
                return _csvRecords[index];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return _csvRecords[index];
            }
        }

        public CsvEnumerable(string path)
        {
            try
            {
                using (var fileReader = File.OpenText(path))
                {
                    using (var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture))
                    {
                        while (csvReader.Read())
                        {
                            for (int i = 0; csvReader.TryGetField<T>(i, out T value); i++)
                            {
                                _csvRecords.Add(value);
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine($"File not found with exception: {exception.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception: {exception.Message}");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        bool IEnumerator.MoveNext()
        {
            index++;
            return index < _csvRecords.Count;
        }

        void IEnumerator.Reset()
        {
            index = -1;
        }

        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _csvRecords.Clear();
                }

                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
    }
}
