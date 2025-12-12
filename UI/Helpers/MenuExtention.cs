using IsabelliDoces.Data;
using IsabelliDoces.Utilities;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.UI.Helpers;

public static class MenuExtention
{
        // const int LINE_LENGTH = 60;

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
                    {
                        valueStr = "-";
                    }
                    else if (value is DateTime date)
                    {
                        valueStr = date.ToString("dd/MM/yyyy");
                    }
                    else if (value is decimal price)
                    {
                        valueStr = $"R$ {price:C}";
                    }
                    else
                    {
                        valueStr = value.ToString()!;
                    }
                }

                Console.Write($"{valueStr.PadRight(attr.ColumnLength)}");
            }

            Console.WriteLine();
            if (headerPrinted) { i++; }
            if (i == 0) headerPrinted = true;
        }
    }

    public static async Task Listing<T>(IsabelliDocesContext dbContext) where T : class
    {
        Console.Clear();
        Console.WriteLine($"Estes são todos os registros de <{typeof(T).Name}>:");
        var dbSet = dbContext.Set<T>();
        var list = await dbSet.ToListAsync();
        PrintList(list);
    }

    // public static T SelectionByName<T>() where T : class, new()
    // {
    //     Console.WriteLine("Informe o nome do registro para a buscar os resgistros: ");
    //     T gotModel;
    //     while (true)
    //     {
    //         try
    //         {
    //             Console.Write("-> ");
    //             int id = Convert.ToInt32(Console.ReadLine());
    //             var dao = DAOManager.GetDaoByEntityType<T, TDTO>();
    //             var tempGotModel = dao.Get(id);

    //             if (tempGotModel is null)
    //             {
    //                 Console.WriteLine("Não há nenhum registro com este id. Tente novamente.");
    //                 continue;
    //             }
    //             gotModel = tempGotModel;
    //             break;
    //         }
    //         catch
    //         {
    //             Console.WriteLine("Informe um valor válido.");
    //         }
    //     }
    //     return gotModel;
    // }

    // public static async Task<T?> SelectionById<T>(IsabelliDocesContext dbContext) where T : class, new()
    // {
    //     Console.WriteLine("Informe o ID do registro (ou pressione ENTER para voltar):");
    //     T entityFound;
    //     while (true)
    //     {
    //         try
    //         {
    //             Console.Write("-> ");
    //             var ipt = Console.ReadLine();
                
    //             if (string.IsNullOrEmpty(ipt)) return null;

    //             if (!int.TryParse(ipt, out int id))
    //             {
    //                 Console.WriteLine("Informe um valor válido. Tente novamente.");
    //                 continue;
    //             }

    //             var tempEntity = await dbContext.Set<T>().FindAsync(id);

    //             if (tempEntity is null)
    //             {
    //                 Console.WriteLine("Não há nenhum registro com este Id. Tente novamente.");
    //                 continue;
    //             }
    //             entityFound = tempEntity;
    //             break;
    //         }
    //         catch
    //         {
    //             Console.WriteLine("Informe um valor válido.");
    //         }
    //     }
    //     return entityFound;
    // }

    //     public static void ModelDetails<T, TDTO>(T model) where T : class, IModel, new()
    //     {
    //         var propertiesMeta = PropertyMetadataReader.GetPropertiesMetaFromModel(model);
    //         foreach (var pMeta in propertiesMeta)
    //         {
    //             var value = pMeta.Value;
    //             var attr = pMeta.AttributePresentation;
    //             int dots = LINE_LENGTH / 3 - attr.Label.Length;

    //             string valueStr = value is null ? "" : value.ToString()!;

    //             Console.WriteLine(
    //                 $"{attr.Label.PadRight(attr.Label.Length)} {new string('.', dots)} {valueStr.PadRight(valueStr.Length)}");
    //         }
    //     }

    //     public static void UpdateField<TDTO>(ref TDTO tempDTO, Func<string, TDTO> setter, bool isDate = false)
    //     {
    //         if (isDate) Console.WriteLine("Informe a nova data (no formato dd/MM/yyyy):");
    //         else Console.WriteLine("Informe o valor:");
    //         while (true)
    //         {
    //             try
    //             {
    //                 Console.Write("-> ");
    //                 var newValue = Console.ReadLine();
    //                 if (string.IsNullOrWhiteSpace(newValue)) continue;
    //                 tempDTO = setter(newValue);
    //                 break;
    //             }
    //             catch { Console.WriteLine("Informe um valor válido."); }
    //         }
    //     }

    //     public static TP UpdateForingKeyInput<TP, TPDTO>() where TP : class, IModel, new()
    //     {
    //         Listing<TP, TPDTO>();
    //         Console.WriteLine($"Informe o Id:");
    //         while (true)
    //         {
    //             try
    //             {
    //                 Console.Write("-> ");
    //                 var newId = Convert.ToInt32(Console.ReadLine());
    //                 var dao = DAOManager.GetDaoByEntityType<TP, TPDTO>();
    //                 TP? newValue = dao.Get(newId);
    //                 if (newValue is null) continue;
    //                 return newValue;
    //             }
    //             catch { Console.WriteLine("Informe um valor válido."); }
    //         }
    //     }

    //     public static TDTO DtoFromInputSimpleFields<T, TDTO>(T gotModel, TDTO tempDTO, bool create = false) 
    //     where T : class, IModel, new() 
    //     where TDTO : new()
    //     {
    //         var propertiesMeta = PropertyMetadataReader.GetPropertiesMetaFromModel(gotModel);
    //         foreach (var pMeta in propertiesMeta)
    //         {
    //             var value = pMeta.Value;
    //             var pName = pMeta.PropertyName;
    //             var pAttr = pMeta.AttributePresentation;
    //             var type = value?.GetType();

    //             if (pAttr.IsForeignKey) continue;
    //             if (create)
    //             {
    //                 if (!pAttr.Creatable) continue;
    //             }
    //             else
    //             {
    //                 if (!pAttr.Updatable) continue;
    //                 if (!Continue($"alterar o {pAttr.Label}")) continue;
    //             }

    //             if (value is string) UpdateField(ref tempDTO, (ipt) =>
    //                 DTOUpdater.Update(tempDTO, pName, ipt));

    //             else if (value is int) UpdateField(ref tempDTO, (ipt) =>
    //                 DTOUpdater.Update(tempDTO, pName, Convert.ToInt32(ipt)));

    //             else if (value is DateTime) UpdateField(ref tempDTO, (ipt) =>
    //                 {
    //                     if (!DateTime.TryParseExact(ipt, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
    //                     {
    //                         Console.WriteLine("Data inválida! Use o formato dd/MM/yyyy");
    //                         return tempDTO;
    //                     }
    //                     return DTOUpdater.Update(tempDTO, pName, date);
    //                 }, true);
    //         }
    //         return tempDTO;
    //     }

    //     public static bool Continue(
    //         string validText, char validChar = 'S')
    //     {
    //         Console.WriteLine($"Informe \"{validChar}\" se desejar {validText}.");
    //         Console.Write("-> ");
    //         string? input = Console.ReadLine();
    //         return !(string.IsNullOrWhiteSpace(input) || char.ToUpper(input[0]) != validChar);
    //     }
}