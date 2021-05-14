using System;
using System.Collections.Generic;
using System.Text;

namespace FromCsvToDatabase
{
    public abstract class ContextObject
    {
        public readonly int id;

        protected ContextObject() { }

        protected ContextObject(int id)
        {
            this.id = id;
        }
    }
}
