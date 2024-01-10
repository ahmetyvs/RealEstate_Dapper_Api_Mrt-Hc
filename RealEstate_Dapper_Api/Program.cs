using RealEstate_Dapper_Api.Hubs;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;
using RealEstate_Dapper_Api.Repositories.ProductDetailRepository;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

var builder = WebApplication.CreateBuilder(args);

// var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; //CORS tanýmlama

// Add services to the container.

builder.Services.AddTransient<Context>();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductDetailRepository, ProductDetailRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddHttpClient();
// SignalR
builder.Services.AddSignalR();


// CORS (Default) tanýmlama 1. yol
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//                      policy =>
//                      {
//                          policy.WithOrigins("https://localhost:7067",
//                                              "https://localhost:7067")
//                                           .AllowAnyHeader()
//                                           .AllowAnyMethod()
//                                           .SetIsOriginAllowed((host) => true)
//                                           .AllowCredentials();
//                          //.WithMethods("PUT", "DELETE", "GET");
//                      });
//});

// CORS (Özel) tanýmlama 2. yol
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
     {
         builder.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials();
     });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS (Default) tanýmlama 1. yol
//app.UseCors(); //CORS

// CORS (Özel) tanýmlama 2. yol
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");
//localhost:1234/swager/category/index Yukarýdaki tanýmlama bu satýr yerine aþaðýdaki kolaylýðý saðlar
//localhost:1234/signalrhub  =  Yukarýdaki yerine buraya (view neredesye oraya) istek atýlmasýna saglar.

app.Run();
