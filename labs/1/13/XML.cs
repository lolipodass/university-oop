using System.Text;
using System.Xml;
using System.Xml.Serialization;
namespace RunProgram
{
    public class XMLWrapper
    {
        public void SerializeObject(string filename, int amount)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(Group));


            XmlTextWriter writer =
            new XmlTextWriter(filename, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement("wrapper");
            for (int i = 0; i < amount; i++)
            {
                mySerializer.Serialize(writer, MakeGroup());
            }
            writer.WriteEndElement();
            writer.Close();
        }

        private Group MakeGroup()
        {
            Group myGroup = new Group();
            myGroup.GroupVehicle = new Vehicle();
            DateTime myDate = DateTime.Now;
            myGroup.Today = myDate;
            myGroup.GroupName = ".DA";
            myGroup.PositiveInt = "2000";
            myGroup.GroupVehicle.licenseNumber = "4321";
            return myGroup;
        }

        public void DeserializeObject(string filename)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(Group));

            XmlTextReader reader =
            new XmlTextReader(filename);
            reader.ReadStartElement("wrapper");

            Group? myGroup;
            while (reader.IsStartElement())
            {
                myGroup = (Group?)mySerializer.Deserialize(reader);
                Console.WriteLine(myGroup);

            }
            reader.ReadEndElement();
            reader.Close();
        }

    }
}