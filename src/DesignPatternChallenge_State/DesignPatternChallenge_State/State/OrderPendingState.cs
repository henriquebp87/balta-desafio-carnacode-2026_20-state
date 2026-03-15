using DesignPatternChallenge_State.Context;

namespace DesignPatternChallenge_State.State;

internal class OrderPendingState : IOrderState
{
    public void ProcessPayment(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        order.SetState(new OrderPaidState());

        Console.WriteLine($"✅ Pagamento confirmado! Total: R$ {order.TotalAmount:N2}");
        Console.WriteLine($"   Status: {order.State}");
    }

    public void Ship(Order order, string trackingNumber)
    {
        Console.WriteLine("❌ Pedido ainda não foi pago!");
    }

    public void Deliver(Order order)
    {
        Console.WriteLine("❌ Pedido ainda não foi enviado!");
    }

    public void Cancel(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        order.SetState(new OrderCancelledState());

        Console.WriteLine("✅ Pedido cancelado. Nenhuma cobrança realizada.");
        Console.WriteLine($"   Status: {order.State}");
    }

    public void RequestReturn(Order order)
    {
        Console.WriteLine("❌ Pedido ainda não foi entregue. Use cancelamento.");
    }

    public override string ToString()
    {
        return "Pendente";
    }
}