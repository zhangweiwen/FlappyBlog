using System.Collections.Generic;
using System.Linq.Expressions;
using FlappyBlog.Infrastructure.Paged;

// ReSharper disable once CheckNamespace
namespace System.Linq.Dynamic
{
    public static class DynamicLinqExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string propertyName)
        {
            return QueryableHelper<T>.OrderBy(queryable, propertyName, false);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string propertyName, bool desc)
        {
            return QueryableHelper<T>.OrderBy(queryable, propertyName, desc);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> orderedQueryable, string propertyName)
        {
            return QueryableHelper<T>.ThenBy(orderedQueryable, propertyName, false);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> orderedQueryable, string propertyName, bool desc)
        {
            return QueryableHelper<T>.ThenBy(orderedQueryable, propertyName, desc);
        }

        static class QueryableHelper<T>
        {
            // ReSharper disable once StaticFieldInGenericType
            private static readonly Dictionary<string, LambdaExpression> Cache = new Dictionary<string, LambdaExpression>();
            public static IOrderedQueryable<T> OrderBy(IQueryable<T> queryable, string propertyName, bool desc)
            {
                dynamic keySelector = GetLambdaExpression(propertyName);
                return desc ? Queryable.OrderByDescending(queryable, keySelector) : Queryable.OrderBy(queryable, keySelector);
            }
            public static IOrderedQueryable<T> ThenBy(IOrderedQueryable<T> orderedQueryable, string propertyName, bool desc)
            {
                dynamic keySelector = GetLambdaExpression(propertyName);
                return desc
                    ? Queryable.ThenByDescending(orderedQueryable, keySelector)
                    : Queryable.ThenBy(orderedQueryable, keySelector);
            }
            private static LambdaExpression GetLambdaExpression(string propertyName)
            {
                if (Cache.ContainsKey(propertyName)) return Cache[propertyName];
                var param = Expression.Parameter(typeof(T));
                var body = Expression.Property(param, propertyName);
                var keySelector = Expression.Lambda(body, param);
                Cache[propertyName] = keySelector;
                return keySelector;
            }
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> queryable, PagedInfo pagedInfo)
        {
            if (pagedInfo == null)
                throw new ArgumentNullException("pagedInfo");

            if (pagedInfo.PageSize <= 0)
                throw new ArgumentException("pageInfo.PageSize必须大于0!");

            if (pagedInfo.OrderInfos != null && pagedInfo.OrderInfos.Any())
            {
                for (var i = 0; i < pagedInfo.OrderInfos.Count; i++)
                {
                    var orderInfo = pagedInfo.OrderInfos[i];
                    if (i == 0 && string.IsNullOrWhiteSpace(orderInfo.PropertyName) == false)
                    {
                        queryable = queryable.OrderBy(orderInfo.PropertyName, orderInfo.IsDesc);
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(orderInfo.PropertyName) == false)
                    {
                        var orderedQueryable = (IOrderedQueryable<T>)queryable;
                        queryable = orderedQueryable.ThenBy(orderInfo.PropertyName, orderInfo.IsDesc);
                    }
                }
            }
            var count = queryable.Count();
            var items = queryable.Skip((pagedInfo.PageIndex - 1) * pagedInfo.PageSize).Take(pagedInfo.PageSize).ToList();
            return new PagedList<T>(pagedInfo.PageSize, count) { Items = items, PageIndex = pagedInfo.PageIndex };
        }

        public static PagedList<T1> Cast<T, T1>(this PagedList<T> pagedList, Func<T, T1> func)
        {
            return new PagedList<T1>
            {
                PageIndex = pagedList.PageIndex,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount,
                TotalPage = pagedList.TotalPage,
                Items = pagedList.Items.Select(func).ToList()
            };
        }
    }
}