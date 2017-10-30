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
        private readonly ICustomerRepository customerRepository;

        public IndexModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IPaginable<Customer> Customers { get; set; } = Paginable.Empty<Customer>();


        public void OnGet(string filterText, string userRightIds, SortMode sortMode, int pageNumber = 1, int itemCountPerPage = 20)
        {
            this.Input = new InputModel
            {
                PageNumber = pageNumber,
                ItemCountPerPage = itemCountPerPage,
                FilterText = filterText,
                UserRightIds = userRightIds,
                SortMode = sortMode,
                UserRights = userRightIds?.Split(",", StringSplitOptions.RemoveEmptyEntries)
            } ;

            this.Customers = 
                this.customerRepository.GetCustomers(
                    filterText,
                    pageNumber, 
                    itemCountPerPage);
        }

        public IActionResult OnPostFind()
        {            
            return RedirectToPage("Index", new { Input.FilterText, Input.SortMode, Input.PageNumber, Input.ItemCountPerPage, userRightIds=string.Join(",", Input.UserRights?? new string[]{}) });
        }



        public class InputModel
        {
            const int DefaultPageNumber = 1;
            const int DefaultItemCountPerPage = 50;

            public string FilterText { get; set; }
            public IEnumerable<string> UserRights { get; set; }
            public string UserRightIds { get; set; }
            public SortMode? SortMode { get; set; }
            public int PageNumber { get; set; } = DefaultPageNumber;
            public int ItemCountPerPage { get; set; } = DefaultItemCountPerPage;
        }
    }
}