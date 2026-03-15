using DesignPatternChallenge_State.Context;

namespace DesignPatternChallenge_State.State;

internal class OrderDeliveredState : IOrderState
{
    public void ProcessPayment(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        Console.WriteLine($"❌ Não é possível processar pagamento. Pedido já está {order.State}");
    }

    public void Ship(Order order, string trackingNumber)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        if (!order.DeliveredDate.HasValue) throw new InvalidOperationException("Data de entrega não definida.");

        Console.WriteLine($"❌ Pedido já foi entregue em {order.DeliveredDate:dd/MM/yyyy}");
    }

    public void Deliver(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        Console.WriteLine($"❌ Pedido já foi entregue em {order.DeliveredDate:dd/MM/yyyy}");
    }

    public void Cancel(Order order)
    {
        Console.WriteLine("❌ Pedido já entregue. Solicite devolução se necessário.");
    }

    public void RequestReturn(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        if (!order.DeliveredDate.HasValue) throw new InvalidOperationException("Data de entrega não definida.");

        var daysSinceDelivery = (DateTime.Now - order.DeliveredDate.Value).Days;
        if (daysSinceDelivery <= 7)
        {
            order.SetState(new OrderReturnedState());

            Console.WriteLine("✅ Devolução aprovada! Prazo dentro de 7 dias.");
            Console.WriteLine($"   Reembolso: R$ {order.TotalAmount:N2}");
            Console.WriteLine($"   Status: {order.State}");
        }
        else
        {
            Console.WriteLine($"❌ Prazo de devolução expirado ({daysSinceDelivery} dias)");
        }
    }

    public override string ToString()
    {
        return "Entregue";
    }
}