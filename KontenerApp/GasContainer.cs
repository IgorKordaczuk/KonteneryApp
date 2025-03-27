namespace KontenerApp;

public class GasContainer : Kontener, IHazardNotifier
{
    private int _pressure;
    
    public GasContainer(int heightCm, int selfMassKg, int depthCm, int maxLoadKg, int pressure)
        : base(heightCm, selfMassKg, depthCm, maxLoadKg)
    {
        GenerateSerialNumber('G');
        _pressure = pressure;
    }

    public void Empty()
    {
        loadMassKg = (int)(loadMassKg * 0.05);
        Console.WriteLine($"Emptied container: {SerialNumber}"); 
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"--UWAGA! {message} (Pojemnik: {SerialNumber})");
    }
}