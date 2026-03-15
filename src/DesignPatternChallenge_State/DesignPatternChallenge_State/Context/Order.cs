using DesignPatternChallenge_State.State;

namespace DesignPatternChallenge_State.Context
{
    internal class Order(string orderId, decimal totalAmount)
    {
        public string OrderId { get; set; } = orderId;
        public decimal TotalAmount { get; set; } = totalAmount;
        public string TrackingCode { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public IOrderState State { get; private set; } = new OrderPendingState();

        public void ProcessPayment()
        {
            Console.WriteLine($"\n[{OrderId}] Processando pagamento...");

            State.ProcessPayment(this);
        }

        public void Ship(string trackingCode)
        {
            Console.WriteLine($"\n[{OrderId}] Tentando enviar pedido...");

            State.Ship(this, trackingCode);
        }

        public void Deliver()
        {
            Console.WriteLine($"\n[{OrderId}] Registrando entrega...");

            State.Deliver(this);
        }

        public void Cancel()
        {
            Console.WriteLine($"\n[{OrderId}] Tentando cancelar pedido...");

            State.Cancel(this);
        }

        public void RequestReturn()
        {
            Console.WriteLine($"\n[{OrderId}] Solicitando devolução...");

            State.RequestReturn(this);
        }

        public void SetState(IOrderState state)
        {
            State = state ?? throw new ArgumentNullException(nameof(state));
        }
    }
}
