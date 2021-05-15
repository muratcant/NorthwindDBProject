using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using NorthwindDBProject.MvcWebUI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NorthwindDBProject.DataAccess.Concrete.EntityFramework;
using NorthwindDBProject.DataAccess.Abstract;
using NorthwindDBProject.Business.Concrete;
using NorthwindDBProject.Business.Abstract;

namespace NorthwindDBProject.MvcWebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            #region EntitesInjects
            services.AddTransient<ICategoryDal, EFCategoryDal>();
            services.AddTransient<ICategoryService, CategoryManager>();

            services.AddTransient<ICustomerDal, EFCustomerDal>();
            services.AddTransient<ICustomerService, CustomerManager>();

            services.AddTransient<ICustomerCustomerDemoDal, EFCustomerCustomerDemoDal>();
            services.AddTransient<ICustomerCustomerDemoService, CustomerCustomerDemoManager>();

            services.AddTransient<ICustomerDemographicDal, EFCustomerDemographicDal>();
            services.AddTransient<ICustomerDemographicService, CustomerDemographicManager>();

            services.AddTransient<IEmployeeDal, EFEmployeeDal>();
            services.AddTransient<IEmployeeService, EmployeeManager>();

            services.AddTransient<IEmployeeTerritoryDal, EFEmployeeTerritoryDal>();
            services.AddTransient<IEmployeeTerritoryService, EmployeeTerritoryManager>();

            services.AddTransient<IOrderDal, EFOrderDal>();
            services.AddTransient<IOrderService, OrderManager>();

            services.AddTransient<IOrderDetailDal, EFOrderDetailDal>();
            services.AddTransient<IOrderDetailService, OrderDetailManager>();

            services.AddTransient<IProductDal, EFProductDal>();
            services.AddTransient<IProductService, ProductManager>();

            services.AddTransient<IRegionDal, EFRegionDal>();
            services.AddTransient<IRegionService, RegionManager>();

            services.AddTransient<IShipperDal, EFShipperDal>();
            services.AddTransient<IShipperService, ShipperManager>();

            services.AddTransient<ISupplierDal, EFSupplierDal>();
            services.AddTransient<ISupplierService, SupplierManager>();

            services.AddTransient<ITerritoryDal, EFTerritoryDal>();
            services.AddTransient<ITerritoryService, TerritoryManager>();

            services.AddTransient<IUsStateDal, EFUsStateDal>();
            services.AddTransient<IUsStateService, UsStateManager>();

            #endregion

            string connectionString = @"Host=localhost;Port=5432;Database=NorthwindDB;Username=muratcant;Password=PostgreSQL1.";
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseNpgsql(connectionString));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserManager<UserManager<IdentityUser>>()
                .AddSignInManager<SignInManager<IdentityUser>>();
            services.AddControllersWithViews();
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
