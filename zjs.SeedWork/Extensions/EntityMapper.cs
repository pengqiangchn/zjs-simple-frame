using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace zjs.SeedWork.Extensions
{
    public static class EntityMapper
    {
        static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    throw new ArgumentNullException(nameof(_mapper));
                }
                return _mapper;
            }
            set => _mapper = value;
        }

        public static void UseEntityMapper(this IApplicationBuilder applicationBuilder)
        {
            _mapper = applicationBuilder.ApplicationServices.GetRequiredService<IMapper>();
            if (_mapper == null)
            {
                throw new ArgumentNullException(nameof(_mapper));
            }
        }

        public static TEntity MapTo<TEntity>(this Entity item)
            where TEntity : class, new()
        {
            return Mapper.Map<TEntity>(item);
        }

        public static List<TEntity> MapTo<TEntity>(this IEnumerable<Entity> items)
            where TEntity : class, new()
        {
            return Mapper.Map<List<TEntity>>(items);
        }

        public static TEntity MapTo<TEntity>(this DTO item)
            where TEntity : class, new()
        {
            return Mapper.Map<TEntity>(item);
        }

        public static List<TEntity> MapTo<TEntity>(this IEnumerable<DTO> items)
            where TEntity : class, new()
        {
            return Mapper.Map<List<TEntity>>(items);
        }
    }
}
