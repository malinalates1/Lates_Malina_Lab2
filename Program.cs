using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lates_Malina_Lab2.Data;
using Microsoft.AspNetCore.Identity;
using Lates_Malina_Lab2.Areas.Identity.Data; // pentru LibraryIdentityContext

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
});

// Contextul principal (pentru Books, Authors, etc.)
builder.Services.AddDbContext<Lates_Malina_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Lates_Malina_Lab2Context") ??
        throw new InvalidOperationException("Connection string 'Lates_Malina_Lab2Context' not found.")));

// Contextul pentru autentificare (Identity)
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Lates_Malina_Lab2Context") ??
        throw new InvalidOperationException("Connection string 'Lates_Malina_Lab2Context' not found.")));

// Adaugă serviciile de autentificare (Identity)
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
        options.SignIn.RequireConfirmedAccount = false)  // pentru test
    .AddRoles<IdentityRole>()

    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();   // <--- adăugată
app.UseAuthorization();

app.MapRazorPages();

app.Run();
