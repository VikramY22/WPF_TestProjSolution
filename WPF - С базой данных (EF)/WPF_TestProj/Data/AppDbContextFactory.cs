using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WPF_TestProj.Views;
using WPF_TestProj.Data;

namespace WPF_TestProj.Data
{
    //фабрика нужна из-за отсутствия DI контейнера в wpf-ках, без нее не работают миграции
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

                                        // Тут такая же строка подключения, как и в AppDbContext
            optionsBuilder.UseSqlServer("Server=HOME-PC,1433;Database=testovoe;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

