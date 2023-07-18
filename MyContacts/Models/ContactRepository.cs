using System;
namespace MyContacts.Models
{
	public static class ContactRepository
	{

		static List<Contact> contacts = new List<Contact>() { new Contact { name = "test", number = "0825547766" },
        new Contact { name = "test1", number = "0825547766" },
        new Contact { name = "test2", number = "0825547766" }};

        public static List<Contact> GetContacts() => contacts; 


        public static Contact GetContact(int contactId)
        {
            return contacts.FirstOrDefault(x => x.contactId == contactId);
        }

    }
}

