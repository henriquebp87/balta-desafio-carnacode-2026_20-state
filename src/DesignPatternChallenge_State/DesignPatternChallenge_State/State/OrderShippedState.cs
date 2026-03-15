using DesignPatternChallenge_State.Context;

namespace DesignPatternChallenge_State.State;

internal class OrderShippedState : IOrderState
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine($"❌ Não é possível processar pagamento. Pedido já está {order.State}");
    }

    public void Ship(Order order, string trackingNumber)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        if (!order.ShippedDate.HasValue) throw new InvalidOperationException("Data de envio não definida.");

        Console.WriteLine($"❌ Pedido já foi enviado em {order.ShippedDate:dd/MM/yyyy}");
    }

    public void Deliver(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        order.SetState(new OrderDeliveredState());
        order.DeliveredDate = DateTime.Now;

        Console.WriteLine("✅ Pedido entregue com sucesso!");
        Console.WriteLine($"   Data: {order.DeliveredDate:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"   Status: {order.State}");
    }

    public void Cancel(Order order)
    {
        Console.WriteLine("❌ Pedido já enviado. Use processo de devolução.");
    }

    public void RequestReturn(Order order)
    {
        Console.WriteLine("❌ Aguarde a entrega para solicitar devolução.");
    }

    public override string ToString()
    {
        return "Enviado";
    }
}