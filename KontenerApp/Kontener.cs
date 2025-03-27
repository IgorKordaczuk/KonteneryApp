namespace KontenerApp;

public abstract class Kontener
{
    public static int NumberRegister = 0;

    public int loadMassKg { get; protected set;  }
    private int _heightCm;
    public int selfMassKg { get; }
    private int _depthCm;
    public string SerialNumber { get;  protected set; }
    protected int _maxLoadKg;
    protected string _loadName = "";
    
    public bool isLoaded = false;

    public Kontener(int heightCm, int selfMassKg, int depthCm, int maxLoadKg)
    {
        _heightCm = heightCm;
        this.selfMassKg = selfMassKg;
        _depthCm = depthCm;
        _maxLoadKg = maxLoadKg;
    }

    public void Empty()
    {
        _loadName = "";
        loadMassKg = 0;
        Console.WriteLine($"Emptied container: {SerialNumber}"); 
    }

    public void Load(string loadName, int loadMassKg)
    {
        if (loadMassKg > _maxLoadKg)
        {
            throw new OverfillException($"Nie można załadować {loadMassKg}kg do kontenera. Maksymalna pojemność: {_maxLoadKg}kg.");
        }

        if (_loadName != "")
        {
            Console.WriteLine($"Failed to load Container. Not proper load."); 
        }
        else if (_loadName != "" && _loadName != loadName)
        {
            Console.WriteLine($"Failed to load Container. Already loaded with different type."); 
        }
        else
        {
            _loadName = loadName;
            this.loadMassKg += loadMassKg;
        
            Console.WriteLine($"Załadowano {loadMassKg}kg ładunku: {loadName}"); 
        }
    }

    public void GenerateSerialNumber(char typeChar)
    {
        int serialNumber = NumberRegister;
        NumberRegister++;
        this.SerialNumber = "KON-" + typeChar + "-" + serialNumber;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine("\n-------------------------------------");
        Console.WriteLine($"Kontener: {SerialNumber}");
        Console.WriteLine($"Wymiary: {_heightCm}cm x {_depthCm}cm");
        Console.WriteLine($"Masa własna: {selfMassKg}kg, Maksymalne obciążenie: {_maxLoadKg}kg");
        Console.WriteLine($"Ładunek: {_loadName}, Masa ładunku: {loadMassKg}kg");
        Console.WriteLine("-------------------------------------");
    }
}