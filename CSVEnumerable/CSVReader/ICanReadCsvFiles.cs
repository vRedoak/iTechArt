using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableCsv
{
    public interface ICanReadCsvFiles
    {
        void FieldsInitialization(string[] fields);
    }
}
