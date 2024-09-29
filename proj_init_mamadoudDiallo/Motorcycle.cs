public class Motorcycle : Vehicle
{
    public bool HasHelmetStorage { get; set; }

    public Motorcycle(string licensePlate, int useCount, bool isCompetition, bool hasHelmetStorage)
        : base(licensePlate, useCount, isCompetition)
    {
        HasHelmetStorage = hasHelmetStorage;
    }

    public override string GetVehicleType() => "Motorcycle";
}
