using System;
using System.ComponentModel.DataAnnotations;

namespace MyContacts.WebApi.Models
{
    public class Contact
    {
        public int contactId { get; set; }
        public string? name { get; set; }
        public string? number { get; set; }
        public string? address { get; set; }
        public string? email { get; set; }
    }
}

