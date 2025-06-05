using System;

abstract class Pocion : Item, IUsable
{
    public int Minimo { get; set; }
    public int Maximo { get; set; }
    protected Random rnd = new Random();

    public Pocion(int minimo, int maximo)
    {
        Minimo = minimo;
        Maximo = maximo;
    }

    public abstract void Usar(Personaje personaje);
}

class PocionVida : Pocion
{
    public PocionVida(int min, int max) : base(min, max)
    {
        Nombre = "Poción de Vida";
    }

    public override void Usar(Personaje personaje)
    {
        int cantidad = rnd.Next(Minimo, Maximo + 1);
        personaje.CurarVida(cantidad);
        Console.WriteLine($"Se curó {cantidad} puntos de vida.");
    }

    public override string ToString() => $"{Nombre} (cura entre {Minimo}-{Maximo} de vida)";
}

class PocionMana : Pocion
{
    public PocionMana(int min, int max) : base(min, max)
    {
        Nombre = "Poción de Mana";
    }

    public override void Usar(Personaje personaje)
    {
        int cantidad = rnd.Next(Minimo, Maximo + 1);
        personaje.RecuperarMana(cantidad);
        Console.WriteLine($"Se recuperó {cantidad} puntos de mana.");
    }

    public override string ToString() => $"{Nombre} (cura entre {Minimo}-{Maximo} de mana)";
}

