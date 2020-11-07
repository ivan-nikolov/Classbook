using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Classook.Services.Mapping
{
    public static class ObjectMappingExtension
    {
        public static TDestination To<TDestination>(
            this object source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return AutoMapperConfig.MapperInstance.Map<TDestination>(source);
        }

        public static TDestination To<TSource, TDestination>(
            this TSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return AutoMapperConfig.MapperInstance.Map<TDestination>(source);
        }
    }
}
