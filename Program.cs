using System;

class Personaje
{
    public string Color { get; set; }
    public int Vida { get; set; }
    public int Defensa { get; set; }
    public int Fuerza { get; set; }
    public int Mana { get; set; }

    public void CambiarColor(string nuevoColor)
    {
        Color = nuevoColor;
    }

    public bool RecibirDaño(int daño)
    {
        int dañoFinal = daño - Defensa;
        if (dañoFinal < 0) dañoFinal = 0;
        Vida -= dañoFinal;
        if (Vida < 0) Vida = 0;
        return Vida > 0;
    }

    public bool Atacar(Personaje enemigo)
    {
        return enemigo.RecibirDaño(Fuerza);
    }

    public void Mostrar()
    {
        Console.WriteLine($"Color: {Color}, Vida: {Vida}, Defensa: {Defensa}, Fuerza: {Fuerza}, Mana: {Mana}");
    }

    public void CurarVida(int cantidad)
    {
        Vida += cantidad;
        Console.WriteLine($"Se curó {cantidad} puntos de vida");
    }

    public void CurarMana(int cantidad)
    {
        Mana += cantidad;
        Console.WriteLine($"Se recuperó {cantidad} puntos de maná");
    }
}

abstract class Pocion
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
    public PocionVida(int min, int max) : base(min, max) { }

    public override void Usar(Personaje personaje)
    {
        int cantidad = rnd.Next(Minimo, Maximo + 1);
        personaje.CurarVida(cantidad);
    }
}

class PocionMana : Pocion
{
    public PocionMana(int min, int max) : base(min, max) { }

    public override void Usar(Personaje personaje)
    {
        int cantidad = rnd.Next(Minimo, Maximo + 1);
        personaje.CurarMana(cantidad);
    }
}

class Programa
{
    static void Main()
    {
        Personaje jugador1 = new Personaje
        {
            Color = "Rojo",
            Vida = 50,
            Defensa = 5,
            Fuerza = 15,
            Mana = 30
        };

        Console.WriteLine("Estado inicial del jugador:");
        jugador1.Mostrar();
        Console.WriteLine();

        Pocion pocionVida = new PocionVida(10, 20);
        pocionVida.Usar(jugador1);

        Pocion pocionMana = new PocionMana(5, 15);
        pocionMana.Usar(jugador1);

        Console.WriteLine("\nEstado después de usar pociones:");
        jugador1.Mostrar();
    }
}
