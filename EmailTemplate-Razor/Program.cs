using RazorEmailTemplateClassLibrary.Services;
using RazorEmailTemplateClassLibrary.Services.Interfaces;
using RazorHtmlEmails.Common.Services;
using RazorHtmlEmails.Common.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IRegisterAccountService, RegisterAccountService>();
builder.Services.AddScoped<IRazorViewToString, RazorViewToString>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
