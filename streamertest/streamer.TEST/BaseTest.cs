using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using SS_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Streamer.Test
{
    public abstract class BaseTest
    {
       public BaseTest()
       {
           
       }

       public class DbTest: IDisposable {

            public ServiceProvider serviceProvider { get; private set; } 

            public DbTest()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddDbContext<StreamerContext>(o =>
                    o.UseSqlite("Data Source=StreamerDBTest.db"),
                    ServiceLifetime.Transient

                );

                serviceProvider = serviceCollection.BuildServiceProvider();
                using (var context = serviceProvider.GetService<StreamerContext>()) {
                    context.Database.EnsureCreated();
                }
            }

            public void Dispose(){
                using (var context = serviceProvider.GetService<StreamerContext>()) {
                    context.Database.EnsureDeleted();
                }
            }

       }
    }
}
