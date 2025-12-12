namespace IsabelliDoces.UI.Helpers;

public class InputHelper
{
    public static string? GetInputString()
    {
        Console.Write("-> ");
        string ipt = Console.ReadLine()?.ToLower() ?? "";

        if (string.IsNullOrEmpty(ipt)) return null;
    
        return ipt;
    }

    public static int? GetInputInt()
    {
        while (true)
        {
            Console.Write("-> ");
            var ipt = Console.ReadLine();

            if (string.IsNullOrEmpty(ipt)) return null;
            

            if (int.TryParse(ipt, out int intIpt)) return intIpt;

            Console.WriteLine("Informe um valor válido. Tente novamente.");
        }
    }
}
