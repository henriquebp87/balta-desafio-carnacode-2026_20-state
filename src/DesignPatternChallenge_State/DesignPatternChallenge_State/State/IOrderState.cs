using DesignPatternChallenge_State.Context;

namespace DesignPatternChallenge_State.State;

internal interface IOrderState
{
    void ProcessPayment(Order order);

    void Ship(Order order, string trackingNumber);

    void Deliver(Order order);

    void Cancel(Order order);

    void RequestReturn(Order order);
}