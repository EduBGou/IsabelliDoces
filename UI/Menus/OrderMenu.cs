using IsabelliDoces.Data;
using IsabelliDoces.Entities;
using IsabelliDoces.Enums;
using IsabelliDoces.UI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.UI.Menus;

public class OrderMenu() : Menu
{
    protected override string MenuTitle => "PEDIDO";
    protected override MenuOption[] AllOptions => [
        new("Listar Pedidos", ListOrders, PermissionType.LIST_ORDERS),
        new("Alterar Pedido", UpdateOrder, PermissionType.UPDATE_ORDER),
        new(
            "Cancelar Pedido", (context, label) =>
                ChangeOrderStatusAsync(context,OrderStatus.CANCELED, label),
            PermissionType.CANCEL_ORDER
        ),
        new("Cadastrar Pedido", CreateOrder, PermissionType.CREATE_ORDER),
        new(
            "Confirmar Entrega de Pedido", (context, label) =>
                ChangeOrderStatusAsync(context,OrderStatus.DELIVERED, label),
            PermissionType.CONFIRM_ORDER
        )
    ];

    private async Task ListOrders(IsabelliDocesContext dbContext, string label)
    {
        Console.Clear();
        Console.WriteLine($"=== {label.ToUpper()}===");
        await MenuExtention.ListingAsync<Order>(dbContext);
        Console.WriteLine("\nPressione qualquer tecla pra voltar.");
        Console.ReadKey();
    }

    private async Task CreateOrder(IsabelliDocesContext dbContext, string label)
    {
        Console.Clear();
        Console.WriteLine($"=== {label.ToUpper()}===");

        var clientFound = await CollectClient(dbContext);
        if (clientFound is null) return;

        var deliveryAddress = await CollectDeliveryAddress(dbContext, clientFound);
        if (deliveryAddress is null) return;

        var deliveryDate = CollectDeliveryDate();
        if (deliveryDate == DateTime.MinValue) return;

        var newOrder = new Order
        {
            Client = clientFound,
            AccomplishDate = DateTime.Today,
            DeliveryDate = deliveryDate,
            DeliveryAddress = deliveryAddress,
            Status = OrderStatus.ACTIVE
        };

        var orderLines = await CollectOrderLines(dbContext);
        if (orderLines is null) return;
        foreach (var line in orderLines) line.Order = newOrder;

        dbContext.Orders.Add(newOrder);
        dbContext.OrderLines.AddRange(orderLines);
        await dbContext.SaveChangesAsync();

        Console.WriteLine("\nPedido registrado com sucesso. Pressione qualquer tecla pra voltar.");
        Console.ReadKey();
    }

    private async Task UpdateOrder(IsabelliDocesContext dbContext, string label)
    {
        Console.Clear();
        Console.WriteLine($"=== {label.ToUpper()}===");

        var clientFound = await CollectClient(dbContext);
        if (clientFound is null) return;

        var orderFound = await CollectOrderOf(dbContext, clientFound);
        if (orderFound is null) return;

        var deliveryAddress = orderFound.DeliveryAddress;
        var deliveryDate = orderFound.DeliveryDate;

        Console.WriteLine($"\nEndereço de Entrega atual: {deliveryAddress}");
        if (MenuExtention.Continue("alterá-lo"))
        {
            deliveryAddress = await CollectDeliveryAddress(dbContext, clientFound);
            if (deliveryAddress is null) return;
        }

        Console.WriteLine($"\nData de Entrega atual: {deliveryDate}");
        if (MenuExtention.Continue("alterá-la"))
        {
            deliveryDate = CollectDeliveryDate();
            if (deliveryDate == DateTime.MinValue) return;
        }

        var newOrder = new Order
        {
            Client = clientFound,
            AccomplishDate = DateTime.Today,
            DeliveryDate = deliveryDate,
            DeliveryAddress = deliveryAddress,
            Status = OrderStatus.ACTIVE
        };

        Console.WriteLine("\nAtuais linhas do pedido:");
        var orderLines = await orderFound.ListingLinesAsync(dbContext);


        if (MenuExtention.Continue("alterá-las"))
        {
            orderLines = await CollectOrderLines(dbContext);
            if (orderLines is null) return;
            foreach (var line in orderLines) line.Order = newOrder;
            dbContext.OrderLines.AddRange(orderLines);
        }

        orderFound.Status = OrderStatus.CANCELED;
        dbContext.Orders.Add(newOrder);
        await dbContext.SaveChangesAsync();

        Console.WriteLine("\nPedido alterado com sucesso. Pressione qualquer tecla para voltar.");
        Console.ReadKey();
    }


    private static async Task ChangeOrderStatusAsync(IsabelliDocesContext dbContext, OrderStatus orderStatus, string label)
    {
        Console.Clear();
        Console.WriteLine($"=== {label.ToUpper()} ===");

        var clientFound = await CollectClient(dbContext);
        if (clientFound is null) return;

        var orderToConfirm = await CollectOrderOf(dbContext, clientFound);
        if (orderToConfirm is null) return;

        await orderToConfirm.ListingLinesAsync(dbContext);

        if (!MenuExtention.Continue($"{label.ToLower()} do Pedido", "pressione ENTER para abortar")) return;

        orderToConfirm.Status = orderStatus;
        await dbContext.SaveChangesAsync();

        Console.WriteLine("\nOperação realizada com sucesso. Pressione qualquer tecla para voltar.");
        Console.ReadKey();
    }

    private static async Task<Client?> CollectClient(IsabelliDocesContext dbContext)
    {
        Console.WriteLine("Informe o NOME do Cliente responsável pelo Pedido (ou pressione ENTER para voltar):");
        var clientsFound = await SearchHelper.SearchByName<Client>(dbContext);
        if (clientsFound is null) return null;

        Console.WriteLine("\nSelecione o Cliente:");
        MenuExtention.PrintList(clientsFound);

        var clientFound = SearchHelper.SearchInListById(clientsFound);
        return clientFound;
    }

    private static async Task<Order?> CollectOrderOf(IsabelliDocesContext dbContext, Client clientFound)
    {
        Console.WriteLine("\nSelecione o Pedido (ID)");

        var orders = await clientFound.ListingActiveOrdes(dbContext);

        var orderFound = SearchHelper.SearchInListById(orders);
        return orderFound;
    }

    private static async Task<List<OrderLine>?> CollectOrderLines(IsabelliDocesContext dbContext)
    {
        Console.WriteLine("\nAdição de Sabores (Itens do Pedido)");
        List<OrderLine> orderLines = [];
        var availableFlavors = await dbContext.CakeFlavors.ToListAsync();
        if (availableFlavors.Count == 0) return null;

        while (true)
        {
            MenuExtention.PrintList(availableFlavors);
            Console.WriteLine("\nSelecione o ID do Sabor (ou 0 para finalizar os itens):");
            var flavorId = InputHelper.GetInputInt();

            if ((flavorId is null || flavorId <= 0) && orderLines.Count > 0) break;

            var flavor = availableFlavors.FirstOrDefault(f => f.Id == flavorId);

            if (flavor is null)
            {
                Console.WriteLine("Id do sabor inválido. Tente novamente.");
                continue;
            }

            Console.WriteLine($"\nInforme a Quantidade para \"{flavor.Name}\":");
            var amount = InputHelper.GetInputInt();
            if (amount is null || amount <= 0)
            {
                Console.WriteLine("Quantidade inválida. Item ignorado.");
                continue;
            }

            orderLines.Add(new OrderLine { Amount = amount.Value, CakeFlavor = flavor });
            Console.WriteLine($"Item adicionado: {amount.Value}x {flavor.Name}.");
        }
        return orderLines;
    }

    private static async Task<Address?> CollectDeliveryAddress(IsabelliDocesContext dbContext, Client clientFound)
    {
        Console.WriteLine("\nSelecione o Endereço de Entrega (ID)");
        var deliveryAddresses = await clientFound.ListingDeliveryPlacesAddresses(dbContext, false);

        MenuExtention.PrintList(deliveryAddresses);

        if (deliveryAddresses.Count == 0) return null;

        var deliveryAddress = SearchHelper.SearchInListById(deliveryAddresses);
        return deliveryAddress;
    }

    private static DateTime CollectDeliveryDate()
    {
        Console.WriteLine("\nInforme a Data de Entrega (dd/mm/aaaa):");
        return InputHelper.GetInputDateTime();
    }
}