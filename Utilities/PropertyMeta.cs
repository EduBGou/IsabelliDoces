namespace IsabelliDoces.Utilities;

public record class PropertyMeta(
    string PropertyName, Type Type, object? Value, AttributePresentation AttributePresentation);
