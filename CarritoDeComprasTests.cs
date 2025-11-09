using FluentAssertions;
using supermarket_receipt_kata.Model;

namespace supermarket_receipt_kata;

public class CarritoDeComprasTests
{
    [Fact]
    public void Si_CarritoVacio_Debe_TotalReciboSerCero()
    {
        // Arrange
        var catalogo = new Catalogo();
        var carrito = new CarritoDeCompras();
        
        // Act
        var total = carrito.CalcularTotal(catalogo);
        
        // Assert
        total.Should().Be(0.0);
    }
    
    [Fact]
    public void UnProductoPorUnidad_DeberiaCalcularPrecioCorrecto()
    {
        // Arrange
        var catalogo = new Catalogo();
        var manzanas = new Producto("Manzanas", TipoProducto.PorUnidad);
        catalogo.AgregarProducto(manzanas, 2.50);
        
        var carrito = new CarritoDeCompras();
        
        // Act
        carrito.AgregarItem(manzanas, 1);
        var total = carrito.CalcularTotal(catalogo);
        
        // Assert
        total.Should().Be(2.50);
    }
}