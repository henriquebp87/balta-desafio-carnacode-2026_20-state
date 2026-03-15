// DESAFIO: Sistema de Pedido de E-commerce com Estados
// PROBLEMA: Um pedido passa por múltiplos estados (Pendente, Pago, Enviado, Entregue, Cancelado)
// e cada estado permite operações diferentes.
// O código anterior usava condicionais gigantes que verificavam o estado atual
// antes de cada operação, tornando difícil adicionar novos estados

using DesignPatternChallenge_State.Context;

namespace DesignPatternChallenge_State;

internal class Program
{
    // Contexto: Sistema de e-commerce onde pedidos passam por ciclo de vida complexo
    // Cada estado tem regras específicas sobre quais operações são permitidas

    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema de Gerenciamento de Pedidos ===");

        var order1 = new Order("ORD-001", 250.00m);
        Console.WriteLine($"\n=== Pedido {order1.OrderId} criado ===");
        Console.WriteLine($"Status inicial: {order1.State}");

        // Fluxo normal
        order1.ProcessPayment();
        order1.Ship("BR123456789");
        order1.Deliver();
        order1.RequestReturn();

        Console.WriteLine("\n" + new string('=', 60));

        var order2 = new Order("ORD-002", 150.00m);
        Console.WriteLine($"\n=== Pedido {order2.OrderId} criado ===");
        Console.WriteLine($"Status inicial: {order2.State}");

        // Tentativas inválidas
        order2.Ship("BR987654321");  // Não pago ainda
        order2.ProcessPayment();
        order2.ProcessPayment();     // Já pago
        order2.Cancel();             // Cancelar após pagamento

        Console.WriteLine("\n" + new string('=', 60));

        var order3 = new Order("ORD-003", 300.00m);
        Console.WriteLine($"\n=== Pedido {order3.OrderId} criado ===");
        Console.WriteLine($"Status inicial: {order3.State}");

        // Entrega antes do pagamento
        order3.Deliver();
        // Devolução antes do pagamento
        order3.RequestReturn();

        order3.ProcessPayment();
        //Entrega antes do envio
        order3.Deliver();

        // Envio com código de rastreamento
        order3.Ship("BR1111111");
        // Envio novamente
        order3.Ship("BR2222222");

        order3.Deliver();
        // Cancelamento após entrega
        order3.Cancel();
        // Solicitação de devolução após entrega
        order3.RequestReturn();

        Console.WriteLine("\n" + new string('=', 60));
    }
}