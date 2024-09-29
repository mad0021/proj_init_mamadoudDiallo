public class Car : Vehicle
{
    public int Doors { get; set; }

    public Car(string licensePlate, int useCount, bool isCompetition, int doors)
        : base(licensePlate, useCount, isCompetition)
    {
        Doors = doors;
    }

    public override string GetVehicleType() => "Car";
}
