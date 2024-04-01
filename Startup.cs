using IdentityServer4.Dapper.Extensions.MySql;
using Microsoft.AspNetCore.Builder;
using System.Text.Json.Serialization;
using WebApi.Helpers;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi
{
	public class Startup(IConfiguration configuration)
	{
		public IConfiguration Configuration { get; } = configuration;

		public void Configure(IApplicationBuilder app)
		{

			// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
			// ensure database and tables exist
			//{
			//	var scope = ((WebApplication)app).Services.CreateAsyncScope();
			//	var context = scope.ServiceProvider.GetRequiredService<DataContext>();
			//	await context.Init();
			//}

			// configure HTTP request pipeline
			{
				//app.UseIdentityServer();

				// global cors policy
				app.UseCors(x => x
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());
				app.UseRouting();
				// global error handler
				app.UseMiddleware<ErrorHandlerMiddleware>();

				app.UseEndpoints(endpoints =>
				{
					endpoints.MapControllers();
				});
			}

		}

		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddIdentityServer()
			//	.AddMySQLProvider(options => 
			//	{
			//		options.ConnectionString = "server=localhost;uid=root;pwd=;database=dotnet-7-dapper-crud-api1;SslMode=None;";
			//	});
		

			services.AddCors();
			services.AddControllers().AddJsonOptions(x =>
			{
				// serialize enums as strings in api responses (e.g. Role)
				x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

				// ignore omitted parameters on models to enable optional params (e.g. User update)
				x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
			});
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			// configure strongly typed settings object
			services.Configure<DbSettings>(Configuration.GetSection("DbSettings"));

			// configure DI for application services
			services.AddSingleton<DataContext>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserService, UserService>();

			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductService, ProductService>();

			services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
			services.AddScoped<IOrderDetailService, OrderDetailService>();

			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IOrderService, OrderService>();

			services.AddScoped<IAuthorRepository, AuthorRepository>();
			services.AddScoped<IAuthorService, AuthorService>();

			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<ICategoryService, CategoryService>();

			services.AddScoped<IProductImageRepository, ProductImageRepository>();
			services.AddScoped<IProductImageService, ProductImageService>();

			services.AddScoped<IProductTagRepository, ProductTagRepository>();
			services.AddScoped<IProductTagService, ProductTagService>();

			services.AddScoped<ITagRepository, TagRepository>();
			services.AddScoped<ITagService, TagService>();

			services.AddScoped<IUserGroupRepository, UserGroupRepository>();
			services.AddScoped<IUserGroupService, UserGroupService>();

			services.AddScoped<IUserProfileRepository, UserProfileRepository>();
			services.AddScoped<IUserProfileService, UserProfileService>();

			services.BuildServiceProvider().CreateScope().ServiceProvider.GetRequiredService<DataContext>().Init().Wait();
			
			
		}
	}
}
