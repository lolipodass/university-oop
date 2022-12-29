using System.Xml.Serialization;

namespace RunProgram
{
    [Serializable]
    [SoapInclude(typeof(Vehicle))]
    public class Group
    {
        public string GroupName;


        [SoapAttribute(DataType = "date", AttributeName = "CreationDate")]
        public DateTime Today;
        [SoapElement(DataType = "nonNegativeInteger", ElementName = "PosInt")]
        public string PositiveInt;

        public Vehicle GroupVehicle;
        public Group()
        {
            GroupName = "";
            PositiveInt = "1";
            Today = new();
            GroupVehicle = new();
        }
    }

    public class Vehicle
    {
        public string licenseNumber;
        public Vehicle()
        {
            licenseNumber = "11";
        }
    }
}