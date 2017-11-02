namespace AspNetCore20.Pages.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using AspNetCore20.Models;
    using PaginableCollections;

    public class AboutModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;

        public AboutModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public InputModel Input { get; set; }
        public Customer Customer { get; set; }


        public void OnGet(InputModel input)
        {
            this.Input = input;
            this.Customer = 
                this.customerRepository.GetCustomer(input.Id);
        }


        public class InputModel
        {
            public Guid Id { get; set; }
            public string FilterText { get; set; }
            public SortMode? SortMode { get; set; }
            public string UserRightIds { get;set; }
            public int PageNumber { get; set; } 
            public int ItemCountPerPage { get; set; }
        }
    }
}