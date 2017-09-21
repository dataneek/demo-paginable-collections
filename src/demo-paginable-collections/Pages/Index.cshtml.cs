namespace AspNetCore20.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using AspNetCore20.Models;
    using PaginableCollections;

    public class IndexModel : PageModel
    {
        private const int DefaultPageNumber = 1;
        private const int DefaultItemCountPerPage = 50;
        
        private readonly ICustomerRepository customerRepository;

        public IndexModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }


        public IPaginable<Customer> Customers { get; set; } = Paginable.Empty<Customer>();


        public void OnGet(int? pageNumber = DefaultPageNumber, int? itemCountPerPage = DefaultItemCountPerPage)
        {
            Customers = 
                this.customerRepository.GetCustomers(
                    pageNumber.Value, itemCountPerPage.Value);
        }
    }
}