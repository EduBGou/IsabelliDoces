using System.Linq.Expressions;
using IsabelliDoces.Data;
using IsabelliDoces.Entities;
using IsabelliDoces.Utilities;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.UI.Helpers;

public static class MenuExtention
{
    const int LINE_LENGTH = 60;
    public static void PrintList<T>(List<T> entities)
    {
        bool headerPrinted = false;
        int i = 0;
        while (i < entities.Count)
        {
            var entity = entities[i];
            var pMetadatas = PropertyMetadataReader.GetPropertyMetadatas(entity);

            for (int j = 0; j < pMetadatas.Count; j++)
            {
                var pMeta = pMetadatas[j];
                var value = pMeta.Value;
                var attr = pMeta.AttributePresentation;

                if (!attr.OnListing) continue;

                string valueStr = attr.Label;

                if (headerPrinted)
                {
                    if (value is null)
                        valueStr = "-";

                    else if (value is DateTime date)
                        valueStr = date.ToString("dd/MM/yyyy");

                    else if (value is decimal price)
                        valueStr = $"R$ {price:C}";

                    else
                        valueStr = value.ToString()!;
                }

                Console.Write($"{valueStr.PadRight(attr.ColumnLength)}");
            }

            Console.WriteLine();
            if (headerPrinted) { i++; }
            if (i == 0) headerPrinted = true;
        }
    }

    public static async Task<List<T>> ListingAsync<T>(
        IsabelliDocesContext dbContext,
        bool print = true,
        Func<IQueryable<T>, IQueryable<T>>? query = null
    ) where T : class
    {
        Console.Clear();
        Console.WriteLine($"Estes são todos os registros de <{typeof(T).Name}>:");
        IQueryable<T> dbSet = dbContext.Set<T>();

        if (query is not null)
        {
            dbSet = query(dbSet);
        }
        var list = await dbSet.ToListAsync();
        if (print) PrintList(list);
        return list;
    }

    public static bool Continue(
        string validText, string arlternativetext = "", char validChar = 'S')
    {
        var baseStr = $"\nDigite \"{validChar}\" se desejar {validText}";

        if (string.IsNullOrEmpty(arlternativetext))
            baseStr += '.';
        else
            baseStr += $"(ou {arlternativetext}).";

        Console.WriteLine(baseStr);
        Console.Write("-> ");
        string? input = Console.ReadLine();
        return !(string.IsNullOrWhiteSpace(input) || char.ToUpper(input[0]) != validChar);
    }
}