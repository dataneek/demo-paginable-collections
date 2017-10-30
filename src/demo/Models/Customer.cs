namespace AspNetCore20.Models
{
    using System;

    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string OrganizationName { get; set; }
        public string Email { get; set; }
    }
}