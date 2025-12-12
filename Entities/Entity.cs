using IsabelliDoces.Utilities;

namespace IsabelliDoces.Entities;

public abstract class Entity()
{
    [AttributePresentation(Label = "Id", OnListing = true, ColumnLength = 5)]
    public int Id { get; set; }
}
