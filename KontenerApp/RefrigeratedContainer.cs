namespace KontenerApp;

public class RefrigeratedContainer : Kontener
{
    private string _productType;
    private double _temperature;
    
    public RefrigeratedContainer(int heightCm, int selfMassKg, int depthCm, int maxLoadKg, string productType, int temperature)
        : base(heightCm, selfMassKg, depthCm, maxLoadKg)
    {
        GenerateSerialNumber('C');
        _productType = productType;
        _temperature = temperature;
    }
    
    public void Load(string loadName, int loadMassKg, double minTemperature)
    {
        if (_temperature < minTemperature)
        {
            Console.WriteLine($"Temperature to low to load: {loadName}");
        }
        else
        {
            base.Load(loadName, loadMassKg);
        }
    }
    
    public new void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Temperature: {_temperature}");
        Console.WriteLine("-------------------------------------\n");
    }
}