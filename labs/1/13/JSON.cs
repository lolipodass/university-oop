using System.Text.Json;

namespace RunProgram
{
    public class JSONWrapper
    {
        public void SerializeObject(string filename)
        {
            using (StreamWriter sw = new(filename))
            {
                var options = new JsonSerializerOptions { WriteIndented = true };

                Human tom = new Human("albert", 22);
                string json = JsonSerializer.Serialize(tom, options);
                sw.WriteLine(json);
            }
        }

        public void DeserializeObject(string filename)
        {
            using (StreamReader sw = new(filename))
            {
                string json = sw.ReadToEnd();
                Human? restoredPerson = JsonSerializer.Deserialize<Human>(json);
                Console.WriteLine(restoredPerson);
            }
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
    }
}