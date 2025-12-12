using System.Globalization;

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

    public static DateTime GetInputDateTime()
    {
        while (true)
        {
            var dateString = GetInputString();
            if (dateString is null) return DateTime.MinValue;

            if (DateTime.TryParseExact(
                dateString, "dd/MM/yyyy", null, DateTimeStyles.None, out var deliveryDate) && deliveryDate >= DateTime.Today)
                return deliveryDate;

            Console.WriteLine("Data inválida. Use o formato dd/mm/aaaa e garanta que não seja retroativa.");
        }
    }
}
