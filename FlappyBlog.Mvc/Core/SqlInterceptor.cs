using System.Diagnostics;
using NHibernate;
using NHibernate.SqlCommand;

namespace FlappyBlog.Mvc.Core
{
    public class SqlInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            Debug.WriteLine(sql);
            var parameters = sql.GetParameters();
            foreach (var parameter in parameters)
            {
                Debug.WriteLine(parameter.ToString());
            }
            return base.OnPrepareStatement(sql);
        }
    }
}