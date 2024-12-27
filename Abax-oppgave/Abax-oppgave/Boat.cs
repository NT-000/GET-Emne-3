namespace Abax_oppgave
{
    internal class Boat : Vehicle
    {
        public int TopSpeed { get;}
        public int GrossTonnage { get;}
        public Boat(string plateNumber, int effect, int topSpeed, int grossTonnage, int id, string type,string vehicleClass) : base(plateNumber, effect, id, type, vehicleClass)
        {
            GrossTonnage = grossTonnage;
            TopSpeed = topSpeed;
            Id = id;
            Type = type;
            VehicleClass = vehicleClass;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Vehicle information");
            Console.WriteLine($"{line}");
            Console.WriteLine($"Vehicle:{Type}");
            Console.WriteLine($"Vehicle class:{VehicleClass}");
            Console.WriteLine($"Horse power:{Effect}");
            Console.WriteLine($"Top speed:{TopSpeed} knot");
            Console.WriteLine($"Gross tonnage:{GrossTonnage}");
            Console.WriteLine($"Platenumber:{PlateNumber}");
        }
        public override void Drive()
        {
            Console.WriteLine($"{Type} with plate {PlateNumber} is now cruising the waves with a top speed of {TopSpeed} knot!");
        }
    }
}
