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
    
    [Fact]
    public void Si_AgregoVariasUnidadesMismoProducto_Debe_MultiplicarPrecio()
    {
        // Arrange
        var catalogo = new Catalogo();
        var leche = new Producto("Leche", TipoProducto.PorUnidad);
        catalogo.AgregarProducto(leche, 3.20);
        
        var carrito = new CarritoDeCompras();
        
        // Act
        carrito.AgregarItem(leche, 3);  // 3 unidades
        var total = carrito.CalcularTotal(catalogo);
        
        // Assert
        total.Should().Be(9.60);  // 3.20 * 3 = 9.60
    }
}