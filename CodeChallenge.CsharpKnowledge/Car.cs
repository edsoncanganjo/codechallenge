namespace CodeChallenge.CsharpKnowledge;

public class Car : Vehicle
{
    public string FuelType { get; set; } = string.Empty;

    public static double CalculateFuelEfficiency(double distance, double consumption)
    {
        if (consumption == 0) return 0;
        
        return distance / consumption;
    }
}