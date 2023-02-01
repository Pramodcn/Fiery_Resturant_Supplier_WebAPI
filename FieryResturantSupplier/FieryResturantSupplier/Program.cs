using FieryResturantData.Data;
using FieryResturantData.Interface;
using FieryResturantData.Repository;
using FieryResturantDTO.SupplierMap;
using FieryResturantServices.InterfaceDTO.Implementation;
using FieryResturantServices.InterfaceDTO.Interface;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace FieryResturantSupplier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //.....Nlog
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/Nlog.config"));
            //.....Add Services to the Container
            

            // Add services to the container.
            //......Add dataContext(Dependency Injection)
            builder.Services.AddDbContext<SupplierDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Supplierss")));



            builder.Services.AddControllers();
            //Interface and Repository...(Dependency Injection)
            builder.Services.AddScoped<ISupplier, SupplierRepository>();
            builder.Services.AddScoped<ISupplierDto, ISupplierService>();
            builder.Services.AddScoped<ILoggers, Loggingmanager>();
            //builder.Services.AddScoped<SupplierDbContext,SupplierDbContext>();
            builder.Services.AddHttpContextAccessor();

            //map....
            builder.Services.AddAutoMapper(typeof(SupplierDtoMap).Assembly);

            //caching....


            //CORs....................
            builder.Services.AddCors((setup) =>
            {
                setup.AddPolicy("default", (Options) =>
                {
                    Options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("default"); //CORs...............

            app.MapControllers();

            app.Run();
        }
    }
}