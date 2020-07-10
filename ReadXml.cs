using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace UniversityApp
{
    public class ReadXml<T> where T : Information
    {
        public static List<T> ReadData(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            TextReader reader = new StreamReader(fileName);

            List<T> list = (List<T>)xmlSerializer.Deserialize(reader);

            reader.Close();

            return list;
        }
    }
}
