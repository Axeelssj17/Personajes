using System;

using System;
using System.Collections.Generic;

interface IUsable
{
    void Usar(Personaje personaje);
}

interface IEquipable
{
    void Equipar(Personaje personaje);
    void Desequipar(Personaje personaje);
}

class Program
{
    static void Main()
    {
        Personaje jugador1 = new Personaje("Rojo", 100, 10, 20, 50);
        Personaje jugador2 = new Personaje("Azul", 120, 15, 18, 40);

        Console.WriteLine("Estado inicial:");
        jugador1.Mostrar();
        jugador2.Mostrar();

        Console.WriteLine("\nJugador 1 recibe 80 de daño:");
        jugador1.RecibirDaño(80);
        jugador1.Mostrar();

        Console.WriteLine("\nJugador 1 usa ítem:");
        var item1 = jugador1.Inventario.ObtenerPrimerItem<PocionVida>();
        if (item1 != null) jugador1.UsarItem(item1);
        jugador1.Mostrar();

        Console.WriteLine("\nJugador 2 usa ítem:");
        var item2 = jugador2.Inventario.ObtenerPrimerItem<PocionMana>();
        if (item2 != null) jugador2.UsarItem(item2);
        jugador2.Mostrar();

        if (jugador1.Vida <= 0)
        {
            Console.WriteLine("\nJugador 1 ha sido derrotado. ¿Reiniciar o salir?");
        }
    }
}
