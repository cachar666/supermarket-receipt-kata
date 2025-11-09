using supermarket_receipt_kata.Model;

namespace supermarket_receipt_kata;

public class CarritoDeCompras
{
    private readonly List<ItemCarrito> _items = new();

    public void AgregarItem(Producto producto, decimal cantidad)
    {
        if (cantidad <= 0)
        {
            throw new ArgumentException("La cantidad debe ser mayor a cero", nameof(cantidad));
        }
        
        _items.Add(new ItemCarrito(producto, cantidad));
    }

    public decimal CalcularTotal(Catalogo catalogo)
    {
        decimal total = 0.0m;
        
        foreach (var item in _items)
        {
            var precioUnitario = catalogo.ObtenerPrecio(item.Producto);
            total += precioUnitario * item.Cantidad;
        }
        
        return total;
    }
}

public class ItemCarrito
{
    public Producto Producto { get; }
    public decimal Cantidad { get; }

    public ItemCarrito(Producto producto, decimal cantidad)
    {
        Producto = producto;
        Cantidad = cantidad;
    }
}