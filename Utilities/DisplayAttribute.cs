namespace IsabelliDoces.Utilities;

[AttributeUsage(AttributeTargets.Property)]
public class AttributePresentation() : Attribute
{
    public string Label { get; set; } = string.Empty;
    public bool OnListing { get; set; } = false;
    public int ColumnLength { get; set; } = 25;
}
