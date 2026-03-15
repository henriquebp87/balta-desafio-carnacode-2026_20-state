using DesignPatternChallenge_State.Context;

namespace DesignPatternChallenge_State.State;

internal class OrderPaidState : IOrderState
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("❌ Pedido já foi pago!");
    }

    public void Ship(Order order, string trackingNumber)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        order.SetState(new OrderShippedState());
        order.TrackingCode = trackingNumber;
        order.ShippedDate = DateTime.Now;

        Console.WriteLine("✅ Pedido enviado!");
        Console.WriteLine($"   Código de rastreamento: {order.TrackingCode}");
        Console.WriteLine($"   Status: {order.State}");
    }

    public void Deliver(Order order)
    {
        Console.WriteLine("❌ Pedido ainda não foi enviado!");
    }

    public void Cancel(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        order.SetState(new OrderCancelledState());

        Console.WriteLine("✅ Pedido cancelado. Reembolso será processado.");
        Console.WriteLine($"   Valor: R$ {order.TotalAmount:N2}");
        Console.WriteLine($"   Status: {order.State}");
    }

    public void RequestReturn(Order order)
    {
        Console.WriteLine("❌ Pedido ainda não foi entregue. Use cancelamento.");
    }

    public override string ToString()
    {
        return "Pago";
    }
}