namespace AspNetCore20.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Bogus;
    using PaginableCollections;

    public class CustomerRepository : ICustomerRepository
    {
        private readonly IList<Customer> customers;

        public CustomerRepository()
        {
            this.customers =
                Enumerable.Range(1, 1000)
                    .Select(t =>
                        new Faker<Customer>()
                            .RuleFor(u => u.FirstName, e => e.Name.FirstName())
                            .RuleFor(u => u.LastName, e => e.Name.LastName())
                            .RuleFor(u => u.OrganizationName, e => e.Company.CompanyName())
                            .RuleFor(u => u.PhoneNumber, e => e.Phone.PhoneNumber())
                            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                            .Generate())
                    .ToList();
        }

        public IPaginable<Customer> GetCustomers(int pageNumber, int itemCountPerPage)
        {
            return customers.ToPaginable(pageNumber, itemCountPerPage);
        }
    }
}