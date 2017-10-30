namespace AspNetCore20.Models
{
    using System;
    using PaginableCollections;

    public interface ICustomerRepository
    {
        Customer GetCustomer(Guid id);
        IPaginable<Customer> GetCustomers(string filterText, int pageNumber, int itemCountPerPage);
    }
}