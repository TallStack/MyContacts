using SQLite;
using System.ComponentModel.DataAnnotations;
namespace MyContacts.CoreBusiness;

// All the code in this file is included in all platforms.
public class Contact
{
    [PrimaryKey]
    [Required, AutoIncrement]
    public int contactId { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string number { get; set; }
    public string address { get; set; }
    public string email { get; set; }
}

