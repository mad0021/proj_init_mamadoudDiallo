public abstract class Vehicle
{
    public string LicensePlate { get; set; }
    public int UseCount { get; set; }
    public bool IsCompetition { get; set; }

    public Vehicle(string licensePlate, int useCount, bool isCompetition)
    {
        LicensePlate = licensePlate;
        UseCount = useCount;
        IsCompetition = isCompetition;
    }

    public abstract string GetVehicleType();
}
