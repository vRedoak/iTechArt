using System;
using System.Collections.Generic;
using System.Text;

namespace FromCsvToDatabase.Repository
{
    public class Animals : ContextObject
    {
        public string name;
        public string type;
        public double speed;

        public Animals() { }

        public Animals(int id, string name, string type, double speed) : base(id)
        {
            this.name = name;
            this.type = type;
            this.speed = speed;
        }
    }
}
