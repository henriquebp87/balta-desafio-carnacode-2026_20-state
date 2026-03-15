using DesignPatternChallenge_State.Context;

namespace DesignPatternChallenge_State.State;

internal class OrderCancelledState : IOrderState
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("❌ Pedido foi cancelado. Crie novo pedido.");
    }

    public void Ship(Order order, string trackingNumber)
    {
        Console.WriteLine("❌ Não é possível enviar pedido cancelado");
    }

    public void Deliver(Order order)
    {
        Console.WriteLine("❌ Pedido cancelado não pode ser entregue");
    }

    public void Cancel(Order order)
    {
        Console.WriteLine("❌ Pedido já está cancelado!");
    }

    public void RequestReturn(Order order)
    {
        Console.WriteLine("❌ Pedido cancelado não pode ser devolvido.");
    }

    public override string ToString()
    {
        return "Cancelado";
    }
}