using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;

namespace RunProgram
{

    public class Program
    {
        public static void Main()
        {

            Game testGame = new();
#pragma warning disable SYSLIB0011
            BinaryFormatter Formatter = new BinaryFormatter();


            using (FileStream fs = new FileStream("test.ini", FileMode.OpenOrCreate))
            {
                Formatter.Serialize(fs, testGame);
            }

            using (FileStream fs = new FileStream("test.ini", FileMode.OpenOrCreate))
            {
                Console.WriteLine(Formatter.Deserialize(fs));
            }
#pragma warning restore SYSLIB0011


            SoapWrapper soap = new();
            soap.SerializeObject("Soap.xml");
            soap.DeserializeObject("Soap.xml");

            XMLWrapper XML = new();
            XML.SerializeObject("XML.xml", 4);
            XML.DeserializeObject("XML.xml");

            JSONWrapper JSON = new();
            JSON.SerializeObject("JSON.json");
            JSON.DeserializeObject("JSON.json");


            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("XML.xml");
            XmlElement? xRoot = xDoc.DocumentElement;

            XmlNodeList? nodes = xRoot?.SelectNodes("Group[2]");
            XmlNodeList? nodes2 = xRoot?.SelectNodes("Group[PositiveInt=2000]");

            if (nodes is not null)
            {
                foreach (XmlNode node in nodes)
                    Console.WriteLine(node.OuterXml);
            }
            Console.WriteLine("\nSecond\n");
            if (nodes2 is not null)
            {
                foreach (XmlNode node in nodes2)
                    Console.WriteLine(node.OuterXml);
            }


            XDocument XDoc = XDocument.Load("XML.xml");
            var items1 = from xel in XDoc.Elements("Group")
                         select new
                         {
                             PositiveInt = xel.Element("PositiveInt")?.Value,
                             GroupVehicle = xel.Element("licenseNumber")?.Value,
                             GroupName = xel.Element("GroupName")?.Value
                         };
            foreach (var item in items1)
                Console.WriteLine($"{item.PositiveInt} {item.GroupVehicle} ({item.GroupName}");
            Console.ReadLine();


            var items2 = from xel in XDoc.Elements("Group")
                         where xel.Element("GroupName")?.Value == ".DA"
                         select new
                         {
                             PositiveInt = xel.Element("PositiveInt")?.Value,
                             GroupVehicle = xel.Element("licenseNumber")?.Value,
                             GroupName = xel.Element("GroupName")?.Value
                         };
            foreach (var item in items2)
                Console.WriteLine($"{item.PositiveInt} {item.GroupVehicle} ({item.GroupName}");
            Console.ReadLine();


            var items3 = from xel in XDoc.Elements("Group")
                         where xel.Element("GroupName")?.Value == ".NET"
                         orderby xel.Element("Today")?.Value descending
                         select new
                         {
                             PositiveInt = xel.Element("PositiveInt")?.Value,
                             GroupVehicle = xel.Element("licenseNumber")?.Value,
                             GroupName = xel.Element("GroupName")?.Value
                         };
            foreach (var item in items3)
                Console.WriteLine($"{item.PositiveInt} {item.GroupVehicle} ({item.GroupName}");
            Console.ReadLine();

        }
    }
}