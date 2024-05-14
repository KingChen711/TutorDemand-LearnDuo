using K17221TutorDemand.DataAccess.Data;
using K17221TutorDemand.WebApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureUnitOfWork();
builder.Services.ConfigureServiceFactory();
builder.Services.RegisterMapsterConfiguration();
builder.Services.AddFluentEmail(builder.Configuration);

// Add Application Scoped
builder.Services.AddScoped<IDatabaseInitializer,DatabaseInitializer>();

var app = builder.Build();

// Hook into application lifetime events and trigger only application fully started
app.Lifetime.ApplicationStarted.Register(async () =>
{
    // Database Initialiser
    await app.InitializeDatabaseAsync();
});

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
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();