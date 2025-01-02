using System.Collections.Generic;

internal class NorthwindEntities
{
    public NorthwindEntities()
    {
    }

    public IEnumerable<object> Customers { get; internal set; }
}