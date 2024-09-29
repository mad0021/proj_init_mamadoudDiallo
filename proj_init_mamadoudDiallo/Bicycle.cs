public class Bicycle : Vehicle
{
    public bool IsElectric { get; set; }

    public Bicycle(int useCount, bool isCompetition, bool isElectric)
        : base("ESPECIAL", useCount, isCompetition)
    {
        IsElectric = isElectric;
    }

    public override string GetVehicleType() => "Bicycle";
}
