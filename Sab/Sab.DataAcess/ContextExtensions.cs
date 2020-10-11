using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Sab.DataAcess
{
    public static class ContextExtensions
    {
        public static string GetTableName<T>(this SabDataContext context) where T : class
        {
            //var mapping = context.Model.FindEntityType(typeof(T)).Relational();
            //var schema = mapping.Schema;
            //var tableName = mapping.TableName;

            var tableName = context.Model.FindEntityType(typeof(T)).GetTableName();

            return tableName;
        }
        public static void ExecuteWithIdentityInsertRemoval<TModel>(this SabDataContext context, Action<SabDataContext> act) where TModel : class
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                var tableName = context.GetTableName<TModel>();
                try
                {
                    context.Database.ExecuteSqlRaw(string.Format("SET IDENTITY_INSERT {0} ON;", tableName));
                    context.SaveChanges();
                    act(context);
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    context.Database.ExecuteSqlRaw(string.Format("SET IDENTITY_INSERT {0} OFF;", tableName));
                    context.SaveChanges();
                }
            }
        }
    }
}
