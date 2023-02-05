using ItemsWebService.Application.Dto;
using ItemsWebService.Application.Services;
using ItemsWebService.Domain.Repositories;
using ItemsWebService.Infrastructure.EntityFramework.Contexts;
using ItemsWebService.Infrastructure.EntityFramework.Models;
using ItemsWebService.Infrastructure.EntityFramework.Services;
using ItemsWebService.Infrastructure.Repositories;
using ItemsWebService.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ItemsWebService.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddQueries();
            services.AddDbContext<ReadAppDbContext>(ctx => ctx.UseSqlServer("ReadConnectionString"));
            services.AddDbContext<WriteAppDbContext>(ctx => ctx.UseSqlServer("WriteConnectionString"));

            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddScoped<IColorsRepository, ColorsRepository>();
            services.AddScoped<IItemsService, ItemsService>();
            return services;
        }

        public static ItemDto AsDto(this ItemReadModel model)
        {
            return new ItemDto
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
                Color = new ColorDto()
                {
                    Id = model.Color.Id,
                    Name = model.Color.Name
                },
                Comment = model.Comment
            };


        }
    }
}
