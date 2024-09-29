public class Bicycle : Vehicle
{
    public bool IsElectric { get; set; }

    public Bicycle(string licensePlate, int useCount, bool isCompetition, bool isElectric)
        : base(licensePlate, useCount, isCompetition)
    {
        IsElectric = isElectric;
    }

    public override string GetVehicleType() => "Bicycle";
}
