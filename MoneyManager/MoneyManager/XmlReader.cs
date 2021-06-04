using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MoneyManager
{
    class XmlReader
    {
        public List<T> Read<T>(string path)
        {
            try
            {
             var xmlSerializer = new XmlSerializer(typeof(List<T>));
                        var result = new List<T>();
                        using (var fs = new FileStream(path, FileMode.Open))
                        {
                            var t = xmlSerializer.Deserialize(fs);
                            result.AddRange((List<T>)t);
                        }
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
