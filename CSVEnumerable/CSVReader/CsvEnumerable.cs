using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CSVReader
{
    class CsvEnumerable<T> : IEnumerable<T>, IEnumerator<T>
    {
        private int index = -1;
        List<T> data = new List<T>();

        T IEnumerator<T>.Current
        {
            get
            {
                return data[index];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return data[index];
            }
        }

        public CsvEnumerable(string path)
        {
            T value;
            using (TextReader fileReader = File.OpenText(path))
            {
                using (var csv = new CsvReader(fileReader, CultureInfo.InvariantCulture))
                {
                   while (csv.Read())
                    {
                        for (int i=0; csv.TryGetField<T>(i, out value); i++)
                        {
                            data.Add(value);
                        }
                    }
                }
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
            return index < data.Count;
        }

        void IEnumerator.Reset()
        {
            index = -1;
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~CsvEnumerable() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        void IDisposable.Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
