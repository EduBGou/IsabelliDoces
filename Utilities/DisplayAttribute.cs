namespace IsabelliDoces.Utilities;

[AttributeUsage(AttributeTargets.Property)]
public class AttributePresentation() : Attribute
{
    private int _listingOrder;

    public int ListingOrder
    {
        get => _listingOrder;
        set
        {
            _listingOrder = value; 
            OnListing = true;
        }
    }
    public string Label { get; set; } = string.Empty;
    public bool OnListing { get; set; } = false;
    public int ColumnLength { get; set; } = 25;
}
