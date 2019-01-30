using Gra_PH_ine.Figures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gra_PH_ine.Classes
{
    public static class Serializator
    {
        public static void Serialize(String fileName)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, NotArtist.Figures);
            File.WriteAllText(fileName, stringWriter.ToString());
        }

        public static void Deserialize(String fileName)
        {
            if (!File.Exists(fileName))
                return;

            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            var stringReader = new StringReader(File.ReadAllText(fileName));
            NotArtist.Figures = (List<Figure>)xmlSerializer.Deserialize(stringReader);
        }
    }
}
