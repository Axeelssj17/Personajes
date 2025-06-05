using System;

class Inventario
{
    private List<Item> items = new List<Item>();

    public void AgregarItem(Item item) => items.Add(item);

    public void QuitarItem(Item item) => items.Remove(item);

    public List<Item> ObtenerItems() => new List<Item>(items);

    public Item ObtenerPrimerItem<T>() where T : Item
    {
        foreach (var item in items)
        {
            if (item is T)
                return item;
        }
        return null;
    }
}



