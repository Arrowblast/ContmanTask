using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Diagnostics;
using System.IO;
namespace ContmanTask.Database.Utils
{
    public class CustomDbConfiguration : DbConfiguration
    {
        static string DatabaseName => "contman_task_database";
        static string DefaultDatabaseName => "contman_task_database";
        public CustomDbConfiguration()
        {
            string path = Path.GetDirectoryName(this.GetType().Assembly.Location);
            CustomDbModelStore cachedDbModelStore = new CustomDbModelStore(path);
            IDbDependencyResolver dependencyResolver = new SingletonDependencyResolver<DbModelStore>(cachedDbModelStore);
            AddDependencyResolver(dependencyResolver);
            this.AddInterceptor(new EFCommandInterceptor(DatabaseName, DefaultDatabaseName));
        }
        private class CustomDbModelStore : DefaultDbModelStore
        {
            public CustomDbModelStore(string location)
                : base(location)
            { }
            public override DbCompiledModel TryLoad(Type contextType)
            {
                string path = GetFilePath(contextType);
                if (File.Exists(path))
                {
                    DateTime lastWriteTime = File.GetLastWriteTimeUtc(path);
                    DateTime lastWriteTimeDomainAssembly = File.GetLastWriteTimeUtc(this.GetType().Assembly.Location);
                    if (lastWriteTimeDomainAssembly > lastWriteTime)
                    {
                        File.Delete(path);
                        Trace.TraceInformation("Cached db model obsolete. Re-creating cached db model edmx.");
                    }
                }
                else
                {
                    Trace.TraceInformation("No cached db model found. Creating cached db model edmx.");
                }
                return base.TryLoad(contextType);
            }
        }
    }
    public sealed class CustomDbConfigurationProvider
    {
        private static readonly Lazy<CustomDbConfiguration>
            lazy =
            new Lazy<CustomDbConfiguration>
                (() => new CustomDbConfiguration());
        public static CustomDbConfiguration CustomDbConfigurationInstance { get { return lazy.Value; } }
        private CustomDbConfigurationProvider()
        {
        }
    }
}
