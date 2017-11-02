namespace AspNetCore20.Models
{
    using System.ComponentModel;

    public enum SortMode
    {
        [Description("desc")]
        Descending = 0,
        [Description("asc")]
        Ascending = 1
    }
}