using FluentAssertions;

namespace supermarket_receipt_kata;

public class CarritoDeComprasTests
{
    [Fact]
    public void CarritoVacio_DeberiaObtenerTotalCero()
    {
        // Arrange (Preparar)
        var carrito = new CarritoDeCompras();
        
        // Act (Actuar)
        var total = carrito.ObtenerTotal();
        
        // Assert (Afirmar)
        total.Should().Be(0.0);
    }
}