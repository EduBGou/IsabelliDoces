using System.Reflection;

namespace IsabelliDoces.Utilities;

public static class PropertyMetadataReader
{
    public static List<PropertyMeta> GetPropertyMetadatas<T>(T model)
    {
        var list = new List<PropertyMeta>();


        var properties = typeof(T).GetProperties()
            .OrderBy(p => p.GetCustomAttribute<AttributePresentation>()?.ListingOrder ?? int.MaxValue);

        foreach (var p in properties)
        {
            var attr = p.GetCustomAttribute<AttributePresentation>();
            if (attr is null) continue;
            var value = p.GetValue(model);
            list.Add(new(p.Name, p.GetType(), value, attr));
        }
        return list;
    }
}
