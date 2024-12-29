namespace Abax_oppgave
{
    internal class Plane : Vehicle
    {
        public int PayloadCapacity { get;}
        public int TotalWeight { get;}

        public int WingSpan { get;}

        public string Type { get;}
        public Plane(string plateNumber, int effect, int payloadCapacity, int totalWeight, int wingspan, string type, int id, string vehicleClass) : base(plateNumber, effect, id, type, vehicleClass)
        {
            PayloadCapacity = payloadCapacity;
            TotalWeight = totalWeight;
            WingSpan = wingspan;
            Type = type;
            Id = id;
            VehicleClass = vehicleClass;
        }
        public override void ShowInfo()
        {
            Console.WriteLine("Vehicle information");
            Console.WriteLine($"{line}");
            Console.WriteLine($"Vehicle:{Type}");
            Console.WriteLine($"Vehicle class:{VehicleClass}");
            Console.WriteLine($"Horse power:{Effect}");
            Console.WriteLine($"Wingspan:{WingSpan} metres");
            Console.WriteLine($"Payload capacity:{PayloadCapacity} kg");
            Console.WriteLine($"Total weight:{TotalWeight} kg");
            Console.WriteLine($"Platenumber:{PlateNumber}");
        }
        public override void Drive()
        {
            Console.WriteLine($"The {Type} is taking of, the {Effect} horse powers is doing this beast justice");
        }
    }
}
