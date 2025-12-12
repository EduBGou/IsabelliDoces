using IsabelliDoces.Utilities;

namespace IsabelliDoces.Entities;

public abstract class Entity()
{
    [AttributePresentation(Label = "Id", ListingOrder = 1, OnListing = true, ColumnLength = 5)]
    public int Id { get; init; }
}
