using System;
namespace MyContacts.Models
{
	public static class ContactRepository
	{

		static List<Contact> contacts = new List<Contact>() { new Contact { contactId = 1, name = "test", number = "0825547766" },
        new Contact { contactId = 2, name = "test1", number = "0825547766" },
        new Contact { contactId = 3, name = "test2", number = "0825547766" }};

        public static List<Contact> GetContacts() => contacts; 


        public static Contact GetContact(int contactId)
        {
            var contact = contacts.FirstOrDefault(x => x.contactId == contactId);
            if (contact != null)
            {
                return new Contact
                {
                    contactId = contact.contactId,
                    address = contact.address,
                    name = contact.name,
                    email = contact.email,
                    number = contact.number
                };
            }
            return null;
        }
        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.contactId)
                return;
            var updatedContact = contacts.FirstOrDefault(x => x.contactId == contactId);
            if (updatedContact != null)
            {
                //AutoMapper
                updatedContact.name = contact.name;
                updatedContact.number = contact.number;
                updatedContact.address = contact.address;
                updatedContact.email = contact.email;
            }
        }
    }
}

