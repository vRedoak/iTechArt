using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FromCsvToDatabase.ReadCsv
{
    class CsvEnumerable<T> : IEnumerable<T>, IEnumerator<T> where T : ICanReadCsvFiles, new()
    {
        private int _index = -1;
        private List<T> _csvRecords = new List<T>();
        private bool _disposedValue;

        T IEnumerator<T>.Current => _csvRecords[_index];

        object IEnumerator.Current => _csvRecords[_index];

        public CsvEnumerable(string path, params char[] separator)
        {
            try
            {
                using var fileReader = File.OpenText(path);
                using var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                if (separator == null)
                    separator = new char[] { ';' };
                while (csvReader.Read())
                {
                    for (var i = 0; csvReader.TryGetField<string>(i, out var value); i++)
                    {
                        var csvRecord = new T();
                        csvRecord.FieldsInitialization(value.Split(separator));
                        _csvRecords.Add(csvRecord);
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    this._csvRecords = null;
                }
                _disposedValue = true;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        bool IEnumerator.MoveNext()
        {
            _index++;
            return _index < _csvRecords.Count;
        }

        void IEnumerator.Reset()
        {
            _index = -1;
        }
    }
}
