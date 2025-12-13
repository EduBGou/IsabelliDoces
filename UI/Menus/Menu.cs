using IsabelliDoces.Data;

namespace IsabelliDoces.UI.Menus;

public abstract class Menu()
{
    protected virtual string MenuTitle => "";
    protected virtual string MenuSubtitle => "";

    protected virtual Func<IsabelliDocesContext, string, Task> GoBackFunction =>
        (dbContext, label) => Task.CompletedTask;
    protected virtual MenuOption[] AllOptions => [];

    public virtual async Task Display(IsabelliDocesContext dbContext)
    {

        Console.Clear();
        Console.WriteLine($"=== {MenuTitle} ===");

        Dictionary<int, MenuOption> avaliableOptions = [];

        if (!string.IsNullOrWhiteSpace(MenuSubtitle))
            Console.WriteLine(MenuSubtitle);

        int i = 1;
        foreach (var op in AllOptions)
        {
            if (!op.HavePermission(dbContext)) continue;
            avaliableOptions.Add(i, op);
            Console.WriteLine($"{i} - {op.Label}");
            i++;
        }

        avaliableOptions.Add(0, new("Voltar para o Menu Anterior", GoBackFunction));

        Console.WriteLine($"0 - {avaliableOptions[0].Label}");

        int optionChosen;
        while (true)
        {
            Console.Write("-> ");
            string? iptStr = Console.ReadLine();

            if (int.TryParse(iptStr, out optionChosen) && avaliableOptions.ContainsKey(optionChosen))
                break;

            Console.WriteLine("Informe uma opção válida!");
        }
        await avaliableOptions[optionChosen].Execute(dbContext);
    }
}