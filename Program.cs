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
}

class Programa
{
    static void Main()
    {

        Personaje jugador1 = new Personaje
        {
            Color = "Rojo",
            Vida = 100,
            Defensa = 10,
            Fuerza = 20,
            Mana = 50
        };

        Personaje jugador2 = new Personaje
        {
            Color = "Azul",
            Vida = 120,
            Defensa = 15,
            Fuerza = 18,
            Mana = 40
        };

        Console.WriteLine("Estado inicial: ");
        jugador1.Mostrar();
        jugador2.Mostrar();
        Console.WriteLine();


        jugador1.CambiarColor("Verde");
        Console.WriteLine("Jugador 1 cambia de color a Verde: ");
        jugador1.Mostrar();
        Console.WriteLine();

        jugador1.RecibirDaño(25);
        Console.WriteLine("Jugador 1 recibe 25 de daño: ");
        jugador1.Mostrar();
        Console.WriteLine();

        jugador1.Atacar(jugador2);
        Console.WriteLine("Jugador 1 ataca a Jugador 2: ");
        jugador1.Mostrar();
        jugador2.Mostrar();
        Console.WriteLine();

        jugador1.RecibirDaño(200);
        Console.WriteLine("Jugador 1 recibe daño letal: ");
        jugador1.Mostrar();
        if (jugador1.Vida <= 0)
        {
            Console.WriteLine("Jugador 1 ha sido derrotado");
            Console.WriteLine("Opción: reiniciar o terminar");
        }
    }
}

class pocion : Personaje
{

    public int VidaMaxima { get; set; }
    public int ManaMaximo { get; set; }

    public pocion (string color, int vida, int defensa, int fuerza, int mana)
    {
        color = Color;
        vida = Vida;
        defensa = Defensa;
        fuerza = Fuerza;
        mana = Mana;
        VidaMaxima = Vida;
        ManaMaximo = Mana;
    }

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

    public void CurarVida(int cantidad)
    {
        Vida += cantidad;
        if (Vida > VidaMaxima)
            Vida = VidaMaxima;
    }
    public void CurarMana(int cantidad)
    {
        Mana += cantidad;
        if (Mana > ManaMaximo)
            Mana = ManaMaximo;
    }
    public void Mostrar()
    {
        Console.WriteLine($"Color: {Color}, Vida: {Vida}/{VidaMaxima}, Defensa: {Defensa}, Fuerza: {Fuerza}, Mana: {Mana}/{ManaMaximo}");
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
    class PocionVida : Pocion
    {
        public PocionVida(int min, int max) : base(min, max) { }

        public void Usar(Personaje personaje)
        {
            int cantidad = rnd.Next(Minimo, Maximo + 1);
            personaje.CurarVida(cantidad);
            Console.WriteLine($"Se curo {cantidad} puntos de vida");
        }

        public override void Usar(Personaje personaje)
        {
            throw new NotImplementedException();
        }
    }
}