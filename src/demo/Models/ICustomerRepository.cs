namespace AspNetCore20.Models
{
    using PaginableCollections;

    public interface ICustomerRepository
    {
        IPaginable<Customer> GetCustomers(int pageNumber, int itemCountPerPage);
    }
}