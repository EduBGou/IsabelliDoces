using System.Reflection;

namespace IsabelliDoces.Utilities;

public static class PropertyMetadataReader
{
    public static List<PropertyMeta> GetPropertyMetadatas<T>(T model)
    {
        var list = new List<PropertyMeta>();
        foreach (var p in typeof(T).GetProperties())
        {
            var attr = p.GetCustomAttribute<AttributePresentation>();
            if (attr is null) continue;
            var value = p.GetValue(model);
            list.Add(new(p.Name, p.GetType(), value, attr));
        }
        return list;
    }
}
