using MyContacts.WebApi;
using Microsoft.EntityFrameworkCore;
using MyContacts.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.MapGet("/api/contacts", async ([FromQuery]string? s, ApplicationDbContext db) =>
{
    List<Contact> contacts;
    if(string.IsNullOrWhiteSpace(s))
    {
        contacts = await db.Contacts.ToListAsync();
    }
    else
    {
        contacts = await db.Contacts.Where(x => !string.IsNullOrWhiteSpace(x.name) && x.name.ToLower().IndexOf(s.ToLower()) >= 0 ||
        !string.IsNullOrWhiteSpace(x.email) && x.email.ToLower().IndexOf(s.ToLower()) >= 0 ||
        !string.IsNullOrWhiteSpace(x.number) && x.number.ToLower().IndexOf(s.ToLower()) >= 0 ||
        !string.IsNullOrWhiteSpace(x.address) && x.address.ToLower().IndexOf(s.ToLower()) >= 0).ToListAsync();
    }
    
    return Results.Ok(contacts);
});

app.MapPost("api/contacts", async (Contact contact, ApplicationDbContext db) =>
{
    db.Contacts.Add(contact);
    //TODO: Add validations
    await db.SaveChangesAsync();
});

app.MapPut("api/contacts/{contactId}", async (int contactId, Contact contact, ApplicationDbContext db) =>
{
    var contactToUpdate = await db.Contacts.FindAsync(contactId);

    if (contactToUpdate is null)
    {
        return Results.NotFound();
    }
    //TODO: add automapper nuget
    contactToUpdate.number = contact.number;
    contactToUpdate.name = contact.name;
    contactToUpdate.email = contact.email;
    contactToUpdate.address = contact.address;
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("api/contacts/{contactId}", async (int contactId, ApplicationDbContext db) =>
{
    var contactToUpdate = await db.Contacts.FindAsync(contactId);
    if (contactToUpdate != null) 
    {
        db.Contacts.Remove(contactToUpdate);
        await db.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();



