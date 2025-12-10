using System.Reflection;

namespace IsabelliDoces.Utilities;

public static class AutoMapper
{
    public static TDestination Map<TSource, TDestination>(this TSource source) where TDestination : new()
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        var dest = new TDestination();

        var sourceProps = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        var destProps = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var sProp in sourceProps)
        {
            var dProp = destProps.FirstOrDefault(p =>
                p.Name == sProp.Name &&
                p.PropertyType == sProp.PropertyType &&
                p.CanWrite
            );

            if (dProp is not null)
            {
                var value = sProp.GetValue(source);
                dProp.SetValue(dest, value);
            }
        }

        return dest;
    }
}
