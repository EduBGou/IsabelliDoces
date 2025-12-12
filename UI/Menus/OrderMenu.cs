using System.Globalization;
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
        new("Cancelar Pedido", CancelOrder, PermissionType.CANCEL_ORDER),
        new("Cadastrar Pedido", CreateOrder, PermissionType.CREATE_ORDER),
        new("Confirmar Pedido", ConfirmOrder,  PermissionType.CONFIRM_ORDER),
    ];

    private async Task CreateOrder(IsabelliDocesContext dbContext)
    {
        Console.Clear();
        Console.WriteLine("=== NOVO PEDIDO ===");

        // 1. SELEÇÃO DO CLIENTE
        Console.WriteLine("Informe o NOME do Cliente (ou pressione ENTER para voltar):");

        var clientsFound = await SearchHelper.SearchByName<Client>(dbContext);
        if (clientsFound is null) return;

        Console.WriteLine("Selecione o Cliente:");
        MenuExtention.PrintList(clientsFound);
        var client = SearchHelper.SearchInListById(clientsFound);

        if (client is null) return;

        // 2. SELEÇÃO DO ENDEREÇO DE ENTREGA
        var deliveryAddresse = await dbContext.DeliveryPlaces
            .Include(dp => dp.Client).Include(dp => dp.Address)
            .Where(dp => dp.Client.Id == client.Id)
            .Select(dp => dp.Address)
            .ToListAsync();

        if (deliveryAddresse.Count == 0)
        {
            Console.WriteLine($"\n[ERRO]: O cliente {client.Name} não possui endereços de entrega cadastrados.");
            Console.WriteLine("Cadastre um endereço de entrega antes de prosseguir.");
            return;
        }

        Console.WriteLine("\n --- 2. Selecione o Local de Entrega (ID): ---");
        MenuExtention.PrintList(deliveryAddresse);
        var deliveryAddress = SearchHelper.SearchInListById(deliveryAddresse);
        if (deliveryAddress is null) return;

        // 3. DEFINIÇÃO DA DATA DE ENTREGA
        DateTime deliveryDate;
        while (true)
        {
            Console.WriteLine("\n--- 3. Informe a Data de Entrega (dd/mm/aaaa): ---");
            var dateString = InputHelper.GetInputString();
            if (dateString is null) return;

            if (DateTime.TryParseExact(
                dateString, "dd/MM/yyyy", null, DateTimeStyles.None, out deliveryDate) && deliveryDate >= DateTime.Today)
            {
                break;
            }
            Console.WriteLine("Data inválida. Use o formato dd/mm/aaaa e garanta que não seja retroativa.");
        }

        // 4. ADIÇÃO DOS ITENS
        var orderLines = new List<OrderLine>();
        Console.WriteLine("\n--- 4. Adição de Sabores (Itens do Pedido) ---");

        var availableFlavors = await dbContext.CakeFlavors.ToListAsync();
        if (availableFlavors.Count == 0)
        {
            Console.WriteLine("\n[ERRO]: Não há sabores de bolo cadastrados para venda.");
            return;
        }

        while (true)
        {
            MenuExtention.PrintList(availableFlavors);
            Console.WriteLine("\nSelecione o ID do Sabor (ou 0 para finalizar os itens):");
            var flavorId = InputHelper.GetInputInt();

            if (flavorId is null || flavorId == 0) break;

            var flavor = availableFlavors.FirstOrDefault(f => f.Id == flavorId);

            if (flavor is null)
            {
                Console.WriteLine("ID do sabor inválido. Tente novamente.");
                continue;
            }

            Console.WriteLine($"\nInforme a Quantidade para '{flavor.Name}':");
            var amount = InputHelper.GetInputInt();
            if (amount is null || amount <= 0)
            {
                Console.WriteLine("Quantidade inválida. Item ignorado.");
                continue;
            }

            orderLines.Add(new OrderLine { Amount = amount.Value, CakeFlavor = flavor });
            Console.WriteLine($"Item adicionado: {amount.Value}x {flavor.Name}.");
        }

        if (orderLines.Count == 0)
        {
            Console.WriteLine("Pedido cancelado: Nenhum item foi adicionado.");
            return;
        }

        // 5. CRIAÇÃO E SALVAMENTO DO PEDIDO
        var newOrder = new Order
        {
            Client = client,
            AccomplishDate = DateTime.Today,
            DeliveryDate = deliveryDate,
            Address = deliveryAddress,
            Status = OrderStatus.ACTIVE
        };

        dbContext.Orders.Add(newOrder);

        foreach (var line in orderLines)
        {
            line.Order = newOrder;
            dbContext.OrderLines.Add(line);
        }

        await dbContext.SaveChangesAsync();


        Console.WriteLine("Pedido registrado com sucesso. Pressione qualquer tecla pra voltar.");
        Console.ReadKey();
    }

    private Task ListOrders(IsabelliDocesContext dbContext) => throw new NotImplementedException();
    private Task UpdateOrder(IsabelliDocesContext dbContext) => throw new NotImplementedException();
    private Task CancelOrder(IsabelliDocesContext dbContext) => throw new NotImplementedException();
    private Task ConfirmOrder(IsabelliDocesContext dbContext) => throw new NotImplementedException();

    // private void CancelOrder()
    // {
    //     Console.Clear();
    //     Console.WriteLine("=== CANCELAR PEDIDO ===");

    //     var list = ((OrderDAO)DAOManager.GetDaoByEntityType<Order, OrderDTO>()).ListByStatus(Status.Active);

    //     if (list.Count == 0)
    //     {
    //         Console.WriteLine("\nNão há pedidos <Ativos> para cancelar.");
    //         Console.WriteLine("Pressione qualquer tecla para retornar.");
    //         Console.ReadKey();
    //         PreviousMenuHierarchy.Display();
    //         return;
    //     }

    //     Console.WriteLine($"Estes são todos os registros <Ativos> de <{Order.Label}>:");
    //     MenuExtention.PrintList<Order, OrderDTO>(list);

    //     Console.WriteLine("\nInforme o ID do pedido que deseja CANCELAR:");
    //     if (!int.TryParse(Console.ReadLine(), out int orderId)) return;

    //     var orderToCancel = DAOManager.OrderDAO.Get(orderId);

    //     if (orderToCancel is not null)
    //     {
    //         Console.WriteLine($"\nPedido Selecionado: ID {orderToCancel.Id} | Status Atual: {orderToCancel.Status}");

    //         if (orderToCancel.Status != Status.Active)
    //         {
    //             Console.WriteLine("\nERRO: Apenas pedidos 'Ativos' (Status 1) podem ser cancelados. Pressione qualquer tecla para retornar.");
    //             Console.ReadKey();
    //             PreviousMenuHierarchy.Display();
    //             return;
    //         }

    //         if (MenuExtention.Continue("CANCELAR este pedido"))
    //         {

    //             var cancelDTO = AutoMapper.Map<Order, OrderDTO>(orderToCancel);

    //             var updatedDTO = cancelDTO with { Status = Status.Canceled };

    //             DAOManager.OrderDAO.Update(orderToCancel.Id, updatedDTO);
    //             Console.WriteLine("Pedido cancelado com sucesso. Pressione qualquer tecla para retornar.");
    //         }
    //     }
    //     else
    //     {
    //         Console.WriteLine("Pedido não encontrado. Pressione qualquer tecla para retornar.");
    //         Console.ReadKey();
    //         PreviousMenuHierarchy.Display();
    //         return;
    //     }

    //     Console.ReadKey();
    //     PreviousMenuHierarchy.Display();
    // }

    // private void ConfirmOrder()
    // {
    //     Console.Clear();
    //     Console.WriteLine("=== CONFIRMAR/ENTREGAR PEDIDO ===");

    //     Console.WriteLine("Informe o ID do pedido que deseja CONFIRMAR/ENTREGAR:");
    //     if (!int.TryParse(Console.ReadLine(), out int orderId)) return;

    //     var orderToConfirm = DAOManager.OrderDAO.Get(orderId);

    //     if (orderToConfirm is not null)
    //     {
    //         Console.WriteLine($"\nPedido Selecionado: ID {orderToConfirm.Id} | Status Atual: {orderToConfirm.Status}");

    //         if (orderToConfirm.Status == Status.Canceled)
    //         {
    //             Console.WriteLine("\nERRO: Pedidos Cancelados não podem ser Confirmados/Entregues. Pressione qualquer tecla para retornar.");
    //             Console.ReadKey();
    //             PreviousMenuHierarchy.Display();
    //             return;
    //         }
    //         if (orderToConfirm.Status == Status.Delivered)
    //         {
    //             Console.WriteLine("\nINFO: Este pedido já está com o status 'Entregue'. Pressione qualquer tecla para retornar.");
    //             Console.ReadKey();
    //             PreviousMenuHierarchy.Display();
    //             return;
    //         }

    //         if (MenuExtention.Continue("CONFIRMAR a entrega deste pedido"))
    //         {
    //             var confirmDTO = AutoMapper.Map<Order, OrderDTO>(orderToConfirm);

    //             var updatedDTO = confirmDTO with { Status = Status.Delivered };

    //             DAOManager.OrderDAO.Update(orderToConfirm.Id, updatedDTO);
    //             Console.WriteLine("Pedido confirmado como entregue com sucesso. Pressione qualquer tecla para retornar.");
    //         }
    //     }
    //     else
    //     {
    //         Console.WriteLine("Pedido não encontrado. Pressione qualquer tecla para retornar.");
    //     }

    //     Console.ReadKey();
    //     PreviousMenuHierarchy.Display();
    // }

    // private void ListOrders()
    // {
    //     MenuExtention.Listing<Order, OrderDTO>();
    //     Console.WriteLine("Pressione qualquer tecla para retornar.");
    //     Console.ReadKey();
    //     PreviousMenuHierarchy.Display();
    // }
}