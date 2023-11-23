using DexteraTech.CarStore.Application.Repositorio;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Data;
using DexteraTech.CarStore.Web.Mapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DexteraTech.CarStore.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddScoped<ICarroceriaRepositorio, CarroceriaRepositorio>();
        builder.Services.AddScoped<IVersaoRepositorio, VersaoRepositorio>();
        builder.Services.AddScoped<IModeloRepositorio, ModeloRepositorio>();
        builder.Services.AddScoped<ICambioRepositorio, CambioRepositorio>();
        builder.Services.AddScoped<IVeiculoRepositorio, VeiculoRepositorio>();
        builder.Services.AddScoped<ICorRepositorio, CorRepositorio>();
        builder.Services.AddScoped<IFotoRepositorio, FotoRepositorio>();
        builder.Services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
        builder.Services.Configure<FormOptions>(x => x.MultipartBodyLengthLimit = long.MaxValue);
        builder.Services.AddAutoMapper(typeof(DefaultMapper));

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseStaticFiles();

        app.UseRouting();
      
        app.UseAuthorization();
      
        app.UseHttpsRedirection();

        app.MapControllerRoute(
            "default",
            "{controller=Home}/{action=Index}/{id?}");

        app.MapRazorPages();

        app.Run();
    }
}