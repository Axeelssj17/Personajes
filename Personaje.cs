using System;

class Personaje
{
    public string Color { get; set; }
    public int Vida { get; set; }
    public int Defensa { get; set; }
    public int Fuerza { get; set; }
    public int Mana { get; set; }
    public int VidaMaxima { get; private set; }
    public int ManaMaximo { get; private set; }
    public Inventario Inventario { get; private set; }
    public List<Item> Equipamiento { get; private set; } = new List<Item>();

    public Personaje(string color, int vida, int defensa, int fuerza, int mana)
    {
        Color = color;
        Vida = vida;
        Defensa = defensa;
        Fuerza = fuerza;
        Mana = mana;
        VidaMaxima = vida;
        ManaMaximo = mana;
        Inventario = new Inventario();
        Inventario.AgregarItem(new PocionVida(10, 30));
        Inventario.AgregarItem(new PocionMana(10, 30));
    }

    public void CambiarColor(string nuevoColor) => Color = nuevoColor;

    public bool RecibirDaño(int daño)
    {
        int dañoFinal = daño - Defensa;
        if (dañoFinal < 0) dañoFinal = 0;
        Vida -= dañoFinal;
        if (Vida < 0) Vida = 0;
        return Vida > 0;
    }

    public bool Atacar(Personaje enemigo) => enemigo.RecibirDaño(Fuerza);

    public void CurarVida(int cantidad)
    {
        Vida += cantidad;
        if (Vida > VidaMaxima)
            Vida = VidaMaxima;
    }

    public void RecuperarMana(int cantidad)
    {
        Mana += cantidad;
        if (Mana > ManaMaximo)
            Mana = ManaMaximo;
    }

    public void Mostrar()
    {
        Console.WriteLine($"Color: {Color}, Vida: {Vida}/{VidaMaxima}, Defensa: {Defensa}, Fuerza: {Fuerza}, Mana: {Mana}/{ManaMaximo}");
        Console.WriteLine("Inventario:");
        foreach (var item in Inventario.ObtenerItems())
            Console.WriteLine("- " + item);

        Console.WriteLine("Equipamiento:");
        foreach (var item in Equipamiento)
            Console.WriteLine("- " + item);
    }

    public void UsarItem(Item item)
    {
        if (item is IUsable usable)
        {
            usable.Usar(this);
            Inventario.QuitarItem(item);
        }
        else
        {
            Console.WriteLine("Este ítem no se puede usar.");
        }
    }

    public void EquiparItem(Item item)
    {
        if (item is IEquipable equipable)
        {
            equipable.Equipar(this);
            Equipamiento.Add(item);
            Inventario.QuitarItem(item);
        }
        else
        {
            Console.WriteLine("Este ítem no se puede equipar.");
        }
    }

    public void DesequiparItem(Item item)
    {
        if (item is IEquipable equipable && Equipamiento.Contains(item))
        {
            equipable.Desequipar(this);
            Equipamiento.Remove(item);
            Inventario.AgregarItem(item);
        }
        else
        {
            Console.WriteLine("Este ítem no se puede desequipar.");
        }
    }
}
