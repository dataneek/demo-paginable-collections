namespace AspNetCore20.Models
{
    using PaginableCollections;

    public interface IFilterable<T>
    {
        string FilterText { get; }
        SortMode SortMode { get; }
        IPaginable<T> Paginable { get; }
    }
}