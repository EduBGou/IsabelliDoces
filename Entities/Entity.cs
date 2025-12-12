using IsabelliDoces.Utilities;

namespace IsabelliDoces.Entities;

public abstract class Entity()
{
    [AttributePresentation(Label = "Id", ListingOrder = 1, ColumnLength = 5)]
    public int Id { get; init; }
}
