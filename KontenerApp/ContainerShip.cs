namespace KontenerApp;

public class ContainerShip
{
    private List<Kontener> _containers = new List<Kontener>();
    private int _maxSpeedKnots;
    private int _maxContainersNumber;
    private double _maxContainersLoadT;
    private double _containersLoadT;

    public ContainerShip(int maxSpeedKnots, int maxContainersNumber, int maxContainersLoadT)
    {
        _maxSpeedKnots = maxSpeedKnots;
        _maxContainersNumber = maxContainersNumber;
        _maxContainersLoadT = maxContainersLoadT;
    }

    public void LoadContainerShip(Kontener container)
    {
        if (container.isLoaded || _containers.Contains(container))
        {
            Console.WriteLine("ERROR: Container already loaded.");
        }
        else if (_containers.Count >= _maxContainersNumber)
        {
            Console.WriteLine($"ERROR: No more containers may be loaded. Containers loaded ({_containers.Count} / {_maxContainersNumber})");
        }
        else if (_containersLoadT * 1000 + container.loadMassKg + container.selfMassKg > _maxContainersLoadT * 1000)
        {
            Console.WriteLine($"ERROR: Operation would exceed weight limit. ({_containersLoadT * 1000 + container.loadMassKg + container.selfMassKg} / {_maxContainersLoadT * 1000}) KG");
        }
        else
        {
            _containers.Add(container);
            container.isLoaded = true;
            CalculateContainersWeight();
            Console.WriteLine($"SUCCESS: Loaded Container:  {container.SerialNumber}");
        }
    }
    
    public void LoadContainerShip(List<Kontener> containers)
    {
        containers.ForEach((container) =>
        {
            LoadContainerShip(container);
        });
    }

    public void UnloadContainerFromShip(Kontener container)
    {
        if (!_containers.Contains(container))
        {
            Console.WriteLine($"ERROR: Cannot unload container. It's not on this ship.  ({container.SerialNumber})");
        }
        else
        {
            _containers.Remove(container);
            container.isLoaded = false;
            CalculateContainersWeight();
            Console.WriteLine($"SUCCESS: Unloaded Container:  {container.SerialNumber}");
        }
    }

    public void EmptyContainerShip()
    {
        _containers.ForEach((container) =>
        {
            container.isLoaded = false;
            UnloadContainerFromShip(container);
        });
        CalculateContainersWeight();
        Console.WriteLine($"SUCCESS: Unloaded Container Ship");

    }

    public void ReplaceContainer(string serialNumber, Kontener container)
    {
        for (int i = 0; i < _containers.Count; i++)
        {
            if (_containers[i].SerialNumber == serialNumber)
            {
                UnloadContainerFromShip(_containers[i]);
                break;
            }
            LoadContainerShip(container);
        };
        
        Console.WriteLine($"SUCCESS: Replaced Container: {serialNumber} with {container.SerialNumber}");
    }

    public static void TransferContainer(Kontener container, ContainerShip fromContainerShip, ContainerShip toContainerShip)
    {
        fromContainerShip.UnloadContainerFromShip(container);
        toContainerShip.LoadContainerShip(container);
    }

    private void CalculateContainersWeight()
    {
        double massT = 0;
        _containers.ForEach((container) =>
        {
            massT += (double)container.loadMassKg / 1000;
            massT += (double)container.selfMassKg / 1000;
            _containersLoadT = massT;
        });
        
        
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine("\n--ContainerShip-----------------------");
        Console.WriteLine($"Max speed: {_maxSpeedKnots}, Max Containers: {_maxContainersNumber}, Max load: {_maxContainersLoadT}");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine($"Loaded: ({_containersLoadT} / {_maxContainersLoadT}) T");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Load:");
        _containers.ForEach((container) =>
        {
            container.DisplayInfo();
        });
        Console.WriteLine("-------------------------------------\n");
    }
    
}