using System;
namespace MyContacts.Models
{
	public class Contact
	{
		public Contact()
		{
		}
		public int contactId { get; set; }
		public string name { get; set; }
		public string number { get; set; }
		public string address { get; set; }
		public string email { get; set; }

	}
}

