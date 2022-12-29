using System.Text;
using System.Xml;
using System.Xml.Serialization;
namespace RunProgram
{
    public class SoapWrapper
    {
        public void SerializeObject(string filename)
        {
            XmlSerializer mySerializer = ReturnSOAPSerializer();

            Group myGroup = MakeGroup();

            XmlTextWriter writer =
            new XmlTextWriter(filename, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement("wrapper");

            mySerializer.Serialize(writer, myGroup);
            writer.WriteEndElement();
            writer.Close();
        }

        private Group MakeGroup()
        {
            Group myGroup = new Group();
            myGroup.GroupName = ".NET";
            DateTime myDate = new DateTime(2002, 5, 2);
            myGroup.Today = myDate;
            myGroup.PositiveInt = "10000";
            myGroup.GroupVehicle = new Vehicle();
            myGroup.GroupVehicle.licenseNumber = "1234";
            return myGroup;
        }

        public void DeserializeObject(string filename)
        {
            XmlSerializer mySerializer = ReturnSOAPSerializer();

            XmlTextReader reader =
            new XmlTextReader(filename);
            reader.ReadStartElement("wrapper");

            Group? myGroup;
            myGroup = (Group?)mySerializer.Deserialize(reader);
            Console.WriteLine(myGroup);
            reader.ReadEndElement();
            reader.Close();
        }

        private XmlSerializer ReturnSOAPSerializer()
        {
            XmlTypeMapping myMapping =
            (new SoapReflectionImporter().ImportTypeMapping
            (typeof(Group)));
            return new XmlSerializer(myMapping);
        }
    }
}