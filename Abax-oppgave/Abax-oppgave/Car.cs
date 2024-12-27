namespace Abax_oppgave
{
    internal class Car : Vehicle
    {
        public int TopSpeed { get;}
        public string Color { get;}

        public Car(string plateNumber, int effect, int topSpeed, string color, string type, int id, string vehicleClass) : base(plateNumber, effect, id, type, vehicleClass)
        {
            Color = color;
            Type = type;
            TopSpeed = topSpeed;
            Id = id;
            VehicleClass = vehicleClass;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Vehicle information");
            Console.WriteLine($"{line}");
            Console.WriteLine($"Vehicle:{Type}");
            Console.WriteLine($"Color:{Color}");
            Console.WriteLine($"Vehicle class:{VehicleClass}");
            Console.WriteLine($"Horse power:{Effect}");
            Console.WriteLine($"Top speed:{TopSpeed} km/h");
        }
        public override void Drive()
        {
            Console.WriteLine($"{Type} with plate {PlateNumber} is now driving in {TopSpeed} km/h down the racetrack!");
        }
    }
}
