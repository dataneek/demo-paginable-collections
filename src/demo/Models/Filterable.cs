namespace AspNetCore20.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PaginableCollections;

    public class Filterable<T> :  IFilterable<T>
    {
        public Filterable() {}
        public Filterable(IPaginable<T> paginable) 
        {
            this.Paginable = paginable;
        }

        public string FilterText { get; set;}
        public SortMode SortMode { get; set;}

        public IPaginable<T> Paginable { get; set; }
    }
}