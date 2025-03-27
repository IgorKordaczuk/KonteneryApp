namespace KontenerApp;

class Program
{
    static void Main(string[] args)
    {
        
        var productsTemperatures = new Dictionary<string, double>
        {
            { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", 2 },
            { "Meat", -15 },
            { "Ice cream", -18 },
            { "Frozen pizza", -30 },
            { "Cheese", 7.2 },
            { "Sausages", 5 },
            { "Butter", 20.5 },
            { "Eggs", 19 }
        };
        
        ContainerShip containerShip1 = new ContainerShip(10, 4, 2);
        
        LiquidContainer kontener1 = new LiquidContainer(300, 400, 500, 2000);
        kontener1.Load("Piwo", 1600);
        kontener1.DisplayInfo();
        
        LiquidContainer kontener2 = new LiquidContainer( 300, 400, 500, 600);
        kontener2.Load("Woda", 260, false);
        kontener2.DisplayInfo();

        GasContainer kontener3 = new GasContainer(320, 200, 250, 700, 20);
        kontener3.Load("Gaz ziemny", 600);
        kontener3.Empty();
        kontener3.DisplayInfo();

        RefrigeratedContainer kontener4 = new RefrigeratedContainer(500, 200, 300, 500, "Bananas", 20);
        kontener4.Load("Bananas", 300, productsTemperatures.GetValueOrDefault("Bananas"));
        
        List<Kontener> containersToLoad1 = new List<Kontener>();
        containersToLoad1.Add(kontener2);
        containersToLoad1.Add(kontener3);
        
        ContainerShip containerShip2 = new ContainerShip(12, 3, 3);
        
        GasContainer kontener5 = new GasContainer(670, 100, 500, 1200, 20);
        kontener5.Load("Gaz wyekstraktowany z wody gazowanej", 900);
        kontener5.Empty();
        
        RefrigeratedContainer kontener6 = new RefrigeratedContainer(500, 200, 300, 700, "Bananas", 21);
        kontener6.Load("Eggs", 600, productsTemperatures.GetValueOrDefault("Eggs"));
        
        List<Kontener> containersToLoad2 = new List<Kontener>();
        containersToLoad2.Add(kontener5);
        containersToLoad2.Add(kontener6);
        
        containerShip1.LoadContainerShip(containersToLoad1);
        containerShip1.DisplayInfo();
        containerShip1.LoadContainerShip(kontener1);
        containerShip1.ReplaceContainer("KON-G-2", kontener4);
        
        containerShip2.LoadContainerShip(containersToLoad2);
        containerShip2.DisplayInfo();
        
        ContainerShip.TransferContainer(kontener2, containerShip1, containerShip2);
        containerShip2.DisplayInfo();
    }
}