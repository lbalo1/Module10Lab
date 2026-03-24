using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using VirtualPetAdoption.Data;
using VirtualPetAdoption.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PetAdoptionContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("PetAdoptionContext")));

var app = builder.Build();

// Code to run when app starts up and makes sure the database is created and up to data
using (var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;
   //Get a instance of the db contexte so we can talk to the db
   var context = services.GetRequiredService<PetAdoptionContext>
   (); 
   context.Database.Migrate();

}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
