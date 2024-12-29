namespace Abax_oppgave
{
    internal abstract class Vehicle
    {
        public string PlateNumber { get;}

        public int Effect { get;}

        public int Id { get; protected set; }

        public string Type { get; protected set;}
        public string VehicleClass { get; protected set; }

        public string line = new ('_', 60);


        public Vehicle(string plateNumber, int effect, int id, string type, string vehicleClass)
        {
            PlateNumber = plateNumber;
            Effect = effect;
            Id = id;
            Type = type;
            VehicleClass = vehicleClass;
        }

        public abstract void ShowInfo();

        public abstract void Drive();

        public int GetId()
        {
            return Id;
        }
    }
}
