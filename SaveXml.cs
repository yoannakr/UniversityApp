using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace UniversityApp
{
    public class SaveXml<T> where T : Information
    {
        public static void SaveData(List<T> all, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            TextWriter writer = new StreamWriter(fileName);

            xmlSerializer.Serialize(writer, all);

            writer.Close();
        }
    }
}
