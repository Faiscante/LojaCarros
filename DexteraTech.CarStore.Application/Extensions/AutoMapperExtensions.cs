using AutoMapper;

namespace DexteraTech.CarStore.Application.Extensions;

public static class AutoMapperExtensions
{
    public static IMappingExpression<TSource, TDestination> IgnoreAllMembers<TSource, TDestination>(
        this IMappingExpression<TSource, TDestination> expr)
    {
        var destinationType = typeof(TDestination);

        foreach (var property in destinationType.GetProperties())
            expr.ForMember(property.Name, opt => opt.Ignore());

        return expr;
    }

    public static IMappingExpression<TSource, TDestination> IgnoreNonExistingMembers<TSource, TDestination>(
        this IMappingExpression<TSource, TDestination> expr)
    {
        var sourceType = typeof(TSource);
        var destinationType = typeof(TDestination);

        foreach (var property in destinationType.GetProperties())
        {
            if (sourceType.GetProperty(property.Name) != null)
                continue;
            expr.ForMember(property.Name, opt => opt.Ignore());
        }

        return expr;
    }
}