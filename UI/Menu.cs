using IsabelliDoces.Data;

namespace IsabelliDoces.UI;

public abstract class Menu()
{
    protected virtual string MenuTitle => "";
    protected virtual string MenuSubtitle => "";
    public virtual Menu PreviousMenuHierarchy => MenuManager.LoginMenu;

    protected virtual MenuOption[] AllOptions => [];
    protected virtual Dictionary<int, MenuOption> AvaliableOptions { get; set; } = [];

    public virtual async Task Display(IsabelliDocesContext dbContext)
    {
        Console.Clear();
        Console.WriteLine($"=== {MenuTitle} ===");
        AvaliableOptions = [];

        if (!string.IsNullOrWhiteSpace(MenuSubtitle))
            Console.WriteLine(MenuSubtitle);

        int i = 1;
        foreach (var op in AllOptions)
        {
            if (!op.HavePermission(dbContext)) continue;
            AvaliableOptions.Add(i, op);
            Console.WriteLine($"{i} - {op.Label}");
            i++;
        }

        AvaliableOptions.Add(0, new("Voltar para a Tela de Login", (dbContext) =>
            { _ = PreviousMenuHierarchy.Display(dbContext); }));

        Console.WriteLine($"0 - {AvaliableOptions[0].Label}");

        int input;
        while (true)
        {
            Console.Write("-> ");
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                if (0 <= input && input < i) break;
            }
            catch
            {
                Console.WriteLine("Informe um valor válido!");
            }
        }
        AvaliableOptions[input].Action(dbContext);
    }
}