using EasySmart.Components;
using EasySmart.Data;
using EasySmart.Services;
using EasySmart.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;

namespace EasySmart
{
    public class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();

            ServiceProvider = app.Services;
            ConfigurePipeline(app);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var razorBuilder = services.AddRazorComponents();
            razorBuilder.AddInteractiveServerComponents();
            services.AddFluentUIComponents();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserSession, UserSession>();
        }

        private static void ConfigurePipeline(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();
            app.UseAntiforgery();
            app.MapStaticAssets();

            var razorEndpoint = app.MapRazorComponents<App>();
            razorEndpoint.AddInteractiveServerRenderMode();
        }
    }
}