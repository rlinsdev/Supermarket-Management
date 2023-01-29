using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plugins.DataStore.InMemory;
using UseCases;
using UseCases.DataStorePluginInterfaces;
using WebApp.Data;

namespace WebApp
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddSingleton<WeatherForecastService>();

			// Dependency injection - in Memory repository
			services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
			services.AddScoped<IProductRepository, ProductInMemoryRepository>();
			services.AddScoped<ITransactionRepository, TransactionInMemoryRepository>();

			// Dependency injection - Use Cases and repositories
			services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
			services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
			services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
			services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
			services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
			services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
			services.AddTransient<IAddProductUseCase, AddProductUseCase>();
			services.AddTransient<IEditProductUseCase, EditProductUseCase>();
			services.AddTransient<IGetProductByIdUseCase, GetProductByIdUseCase>();
			services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
			services.AddTransient<IViewProductsByCategory, ViewProductsByCategory>();
			services.AddTransient<ISellProductUseCase, SellProductUseCase>();
			services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
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
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapBlazorHub();
				endpoints.MapFallbackToPage("/_Host");
			});
		}
	}
}
