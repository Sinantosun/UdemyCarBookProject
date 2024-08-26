using System.Text.Json.Serialization;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers.Write;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers.Write;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers.Write;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers.Write;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Write;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Application.Interfaces.StatisticInteraces;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Application.Services;
using UdemyCarBook.Persistence.Context;
using UdemyCarBook.Persistence.Repositories;
using UdemyCarBook.Persistence.Repositories.BlogRepositories;
using UdemyCarBook.Persistence.Repositories.CarPricingRepsitories;
using UdemyCarBook.Persistence.Repositories.CarRepositories;
using UdemyCarBook.Persistence.Repositories.CommentRepositories;
using UdemyCarBook.Persistence.Repositories.StatisticRepositories;
using UdemyCarBook.Persistence.Repositories.TagCloudRepositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository,CarRepository>();
builder.Services.AddScoped<IBlogRepository,BlogRepository>();
builder.Services.AddScoped<IStatisticRepository,StatisticRepository>();
builder.Services.AddScoped<ICarPricingRepository,CarPricingRepository>();
builder.Services.AddScoped<ITagCloudRepository, TagCloudRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();


builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();


builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddApplicationServices(builder.Configuration);


builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
