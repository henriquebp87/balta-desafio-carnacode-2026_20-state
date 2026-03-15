using DesignPatternChallenge_State.Context;

namespace DesignPatternChallenge_State.State;

internal class OrderReturnedState : IOrderState
{
    public void ProcessPayment(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        Console.WriteLine($"❌ Operação inválida para estado {order.State}");
    }

    public void Ship(Order order, string trackingNumber)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        Console.WriteLine($"❌ Operação inválida para estado {order.State}");
    }

    public void Deliver(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        Console.WriteLine($"❌ Operação inválida para estado {order.State}");
    }

    public void Cancel(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        Console.WriteLine($"❌ Operação inválida para estado {order.State}");
    }

    public void RequestReturn(Order order)
    {
        Console.WriteLine("❌ Devolução já processada!");
    }

    public override string ToString()
    {
        return "Devolvido";
    }
}