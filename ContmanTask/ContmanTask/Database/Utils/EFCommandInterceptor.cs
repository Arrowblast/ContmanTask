using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Text.RegularExpressions;
namespace ContmanTask.Database.Utils
{
    public class EFCommandInterceptor : IDbCommandInterceptor
    {
        public EFCommandInterceptor(string databaseName = "MySqlModel", string defaultDbSchema = "contman_task_database")
        {
            newDatabaseSchema = databaseName;
            oldDatabaseSchema = defaultDbSchema;
        }
        //change database schema by interceptor for executed query 
        string oldDatabaseSchema;
        string newDatabaseSchema;
        static bool LogSqlCommands => bool.Parse(ConfigurationManager.AppSettings["LogSqlCommands"]);
        private static readonly Regex _tableAliasRegex = new Regex(@"(?<query>(?! WITH \(*HINT*\))\)\s+AS \""Project\d+\"")", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        private System.Data.Common.DbCommand ChangeDatabaseSchema(System.Data.Common.DbCommand command, string oldDatabaseSchema, string newDatabaseSchema)
        {
            System.Data.Common.DbCommand cmd = command;
            if (!string.IsNullOrEmpty(newDatabaseSchema) && newDatabaseSchema != oldDatabaseSchema)
            {
                //change database schema in the query
                cmd.CommandText = command.CommandText.Replace(oldDatabaseSchema, newDatabaseSchema);
            }
            //https://stackoverflow.com/questions/20864934/option-recompile-is-always-faster-why
            //RECOMPILE_WITH_SQL_PARAMETERS - tego nie ma w obecnej wersji hany a być może przyspieszy to wykonywanie prepared statements 
            // - do sprawdzenia po aaktualizacji czy jest jakas różnica
            //cmd.CommandText = _tableAliasRegex.Replace(command.CommandText, " WITH HINT (*HINT*)${query}");
            //cmd.CommandText = command.CommandText.Replace("*HINT*", "RECOMPILE_WITH_SQL_PARAMETERS");
            return cmd;
        }
        public void NonQueryExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogInfo("NonQueryExecuting", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }
        public void ReaderExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            LogInfo("ReaderExecuting", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }
        public void ScalarExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogInfo("ScalarExecuting", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }
        private void LogInfo(string command, string commandText)
        {
            if (!LogSqlCommands)
            {
                return;
            }
            Console.WriteLine("Intercepted on: {0} :- {1} ", command, commandText);
        }
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
        }
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
        }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }
    }
}
