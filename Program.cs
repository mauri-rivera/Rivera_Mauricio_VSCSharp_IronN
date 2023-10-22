
Buffet menuNinja = new Buffet();
SweetTooth ninjaGoloso = new SweetTooth();
SpiceHound ninjaConsumidorPicante = new SpiceHound();

Food menuSeleccionadoFood1 = menuNinja.ServeFood();
Drink menuSeleccionadoDrink1 = menuNinja.ServeDrink();
Food menuSeleccionadoFood2 = menuNinja.ServeFood();
Drink menuSeleccionadoDrink2 = menuNinja.ServeDrink();
Food menuSeleccionadoFood3 = menuNinja.ServeFood();
Drink menuSeleccionadoDrink3 = menuNinja.ServeDrink();

ninjaGoloso.Consume(menuSeleccionadoDrink2);
ninjaGoloso.Consume(menuSeleccionadoFood2);
ninjaGoloso.Consume(menuSeleccionadoDrink3);

ninjaConsumidorPicante.Consume(menuSeleccionadoDrink3);
ninjaConsumidorPicante.Consume(menuSeleccionadoFood2);
ninjaConsumidorPicante.Consume(menuSeleccionadoDrink1);

int sumaCaloriasNinja1 = 0, sumaCaloriasNinja2 = 0;

for (int i = 0; i < ninjaGoloso.ConsumptionHistory.Count; i++)
{
    sumaCaloriasNinja1 += ninjaGoloso.ConsumptionHistory[i].Calories;
}

for (int i = 0; i < ninjaConsumidorPicante.ConsumptionHistory.Count; i++)
{
    sumaCaloriasNinja2 += ninjaConsumidorPicante.ConsumptionHistory[i].Calories;
}

int cantidadAlimentoNinja1 = ninjaGoloso.ConsumptionHistory.Count;
int cantidadAlimentoNinja2 = ninjaConsumidorPicante.ConsumptionHistory.Count;

if (cantidadAlimentoNinja1 > cantidadAlimentoNinja2)
{
    Console.WriteLine($"El ninja goloso consumió más alimentos que el ninja consumidor de especias picantes con {sumaCaloriasNinja1} y la cantidad de {cantidadAlimentoNinja1} en comparación con {sumaCaloriasNinja2} y {cantidadAlimentoNinja2} respectivamente");
}
else if (cantidadAlimentoNinja1 < cantidadAlimentoNinja2)
{
    Console.WriteLine($"El ninja consumidor de especias picantes consumió más alimentos que el ninja goloso con {sumaCaloriasNinja2} y la cantidad de {cantidadAlimentoNinja2} en comparación con {sumaCaloriasNinja1} y {cantidadAlimentoNinja1} respectivamente");
}
else
{
    Console.WriteLine($"Tanto el ninja goloso como el ninja consumidor de especias picantes consumieron la misma cantidad de alimentos con {sumaCaloriasNinja1} y la cantidad de {cantidadAlimentoNinja1} para el primero y {sumaCaloriasNinja2} con la cantidad de {cantidadAlimentoNinja2} para el otro ninja");
}

interface IConsumable
{
    string Name { get; set; }
    int Calories { get; set; }
    bool IsSpicy { get; set; }
    bool IsSweet { get; set; }
    string GetInfo();
}

class Buffet
{
    public List<Food> MenuFood;
    public List<Drink> MenuDrink;

    //constructor
    public Buffet()
    {
        MenuFood = new List<Food>()
        {
            new Food("Example", 1000, false, false),
            new Food("MenuFoodUno", 1030, true, false),
            new Food("MenuFoodDos", 1400, false, false),
            new Food("MenuFoodTres", 1100, true, false),
            new Food("MenuFoodCuatro", 2000, false, true),
            new Food("MenuFoodCinco", 400, false, true),
            new Food("MenuFoodSeis", 890, false, false),
            new Food("MenuFoodSiete", 1020, true, false)
        };

        MenuDrink = new List<Drink>()
        {
            new Drink("Example", 1300, false, false),
            new Drink("MenuDrinkUno", 930, true, false),
            new Drink("MenuDrinkDos", 1200, false, false),
            new Drink("MenuDrinkTres", 1300, true, false),
            new Drink("MenuDrinkCuatro", 1400, false, true),
            new Drink("MenuDrinkCinco", 900, false, true),
            new Drink("MenuDrinkSeis", 690, false, false),
            new Drink("MenuDrinkSiete", 920, true, false)
        };
    }

    public Food ServeFood()
    {
        Random menuAleatorioFood = new Random();
        int numeroMenuFood = menuAleatorioFood.Next(0, 8);

        return MenuFood[numeroMenuFood];
    }

    public Drink ServeDrink()
    {
        Random menuAleatorioDrink = new Random();
        int numeroMenuDrink = menuAleatorioDrink.Next(0, 8);

        return MenuDrink[numeroMenuDrink];
    }
}

class Food : IConsumable
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public bool IsSpicy { get; set; }
    public bool IsSweet { get; set; }
    public string GetInfo()
    {
        return $"{Name} (Food).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
    }
    public Food(string name, int calories, bool spicy, bool sweet)
    {
        Name = name;
        Calories = calories;
        IsSpicy = spicy;
        IsSweet = sweet;
    }
}

class Drink : IConsumable
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public bool IsSpicy { get; set; }
    public bool IsSweet { get; set; }

    // Implement a GetInfo Method
    // Add a constructor method
    public string GetInfo()
    {
        return $"{Name} (Drink).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
    }
    public Drink(string name, int calories, bool spicy, bool sweet)
    {
        Name = name;
        Calories = calories;
        IsSpicy = spicy;
        IsSweet = sweet;
    }
}

abstract class Ninja
{
    protected int calorieIntake;
    public List<IConsumable> ConsumptionHistory;
    public Ninja()
    {
        calorieIntake = 0;
        ConsumptionHistory = new List<IConsumable>();
    }
    public abstract bool IsFull { get; }
    public abstract void Consume(IConsumable item);
}

class SweetTooth : Ninja
{
    // provide override for IsFull (Full at 1500 Calories)
    public override bool IsFull 
    {
        get
        {
            if (calorieIntake < 1500)
            {
                return false;
            }
            else
            {
                return true;
            }
        } 
    }

    public override void Consume(IConsumable item)
    {   
        // provide override for Consume
        if (!IsFull)
        {
            if (item.IsSweet)
            {
                calorieIntake += item.Calories + 10;
            }
            else
            {
                calorieIntake += item.Calories;
            }

            ConsumptionHistory.Add(item);

            Console.WriteLine(item.GetInfo());
        }
        else
        {
            Console.WriteLine("El ninja goloso ya no está hambriento");
        }
    }
}

class SpiceHound : Ninja
{
    // provide override for IsFull (Full at 1200 Calories)
    public override bool IsFull
    {
        get
        {
            if (calorieIntake < 1200)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public override void Consume(IConsumable item)
    {
        // provide override for Consume
        if (!IsFull)
        {
            if (item.IsSpicy)
            {
                calorieIntake += item.Calories - 5;
            }
            else
            {
                calorieIntake += item.Calories;
            }

            ConsumptionHistory.Add(item);

            Console.WriteLine(item.GetInfo());
        }
        else
        {
            Console.WriteLine("El ninja consumidor de especias picantes ya no está hambriento");
        }
    }
}


