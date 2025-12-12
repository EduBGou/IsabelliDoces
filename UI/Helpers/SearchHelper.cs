using System.Linq.Expressions;
using IsabelliDoces.Data;
using IsabelliDoces.Entities;
using IsabelliDoces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.UI.Helpers;

public static class SearchHelper
{
    public static async Task<T?> SearchById<T>(
        IsabelliDocesContext dbContext) where T : Entity
    {
        Console.WriteLine("\nInforme o ID do registro (ou pressione ENTER para voltar):");
        T entityFound;

        var id = InputHelper.GetInputInt();

        if (id is null) return null;

        while (true)
        {
            var tempEntity = await dbContext.Set<T>().FindAsync(id);

            if (tempEntity is null)
            {
                Console.WriteLine("Não há nenhum registro com este Id. Tente novamente.");
                continue;
            }
            entityFound = tempEntity;
            break;

        }
        return entityFound;
    }

    public static T? SearchInListById<T>(List<T> localList) where T : Entity
    {
        Console.WriteLine("Informe o ID do registro (ou pressione ENTER para voltar):");

        var id = InputHelper.GetInputInt();
        if (id is null) return null;

        while (true)
        {
            var entity = localList.FirstOrDefault(e => e.Id == id);

            if (entity is null)
            {
                Console.WriteLine("Não há nenhum registro com este Id na lista. Tente novamente.");
                continue;
            }
            return entity;
        }
    }

    public static async Task<List<T>?> SearchByName<T>(IsabelliDocesContext dbContext) where T : class, INameable
    {
        List<T> entitiesFound;
        while (true)
        {
            var ipt = InputHelper.GetInputString();
            if (ipt is null) return null;

            entitiesFound = await dbContext.Set<T>()
                .Where(e => e.Name.ToLower()
                .Contains(ipt))
                .ToListAsync();

            if (entitiesFound.Count > 0) return entitiesFound;
            Console.WriteLine("Não há registros com esse nome.");
        }

    }
}
