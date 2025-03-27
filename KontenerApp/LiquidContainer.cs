namespace KontenerApp;

public class LiquidContainer : Kontener, IHazardNotifier
{
    private bool _isSafe;
    private int _maxCapacity;
    
    public LiquidContainer(int heightCm, int selfMassKg, int depthCm, int maxLoadKg)
        : base(heightCm, selfMassKg, depthCm, maxLoadKg)
    {
        GenerateSerialNumber('L');
    }

    public void Load(string loadName, int loadMassKg, bool isSafe=true)
    {
        if (isSafe) _maxCapacity = (int)(_maxLoadKg * 0.9);
        else _maxCapacity = (int)(_maxLoadKg * 0.5);
        
        if (isSafe && loadMassKg <= _maxCapacity)
        {
            base.Load(loadName, loadMassKg);
        }
        else if (!isSafe && loadMassKg <= _maxCapacity)
        {
            base.Load(loadName, loadMassKg);
        }
        else
        {
            NotifyHazard($"Tried to load liquid container against safety regulations. Load name: {loadName}, load mass: ({loadMassKg}kg / {_maxCapacity}kg max)");
        }
        
        _isSafe = isSafe;
    }


    public void NotifyHazard(string message)
    {
        Console.WriteLine($"--UWAGA! {message} (Pojemnik: {SerialNumber})");
    }
}