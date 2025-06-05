using System;

abstract class Item
{
    public string Nombre { get; set; }
    public override string ToString() => Nombre;
}
