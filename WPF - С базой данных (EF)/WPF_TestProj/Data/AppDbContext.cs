using global::WPF_TestProj.Models;
using WPF_TestProj.Views;
using Microsoft.EntityFrameworkCore;

    namespace WPF_TestProj.Data
    {
        public class AppDbContext : DbContext
        {
            public DbSet<City> Cities => Set<City>();
            public DbSet<Workshop> Workshops => Set<Workshop>();
            public DbSet<Employee> Employees => Set<Employee>();
            public DbSet<Brigade> Brigades => Set<Brigade>();

            public AppDbContext() { }
        
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {                               //заменить на свою
                    optionsBuilder.UseSqlServer("Server=HOME-PC,1433;Database=testovoe;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");
                }
            }
        
        //Рандомный набор стартовых данных для первой миграции в БД

            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{
            //    base.OnModelCreating(modelBuilder);

            //    modelBuilder.Entity<City>().HasData(
            //        new City { Id = 1, Name = "Москва" },
            //        new City { Id = 2, Name = "Владивосток" }
            //    );

            //    modelBuilder.Entity<Workshop>().HasData(
            //        new Workshop { Id = 1, Name = "Цех #1", CityId = 1 },
            //        new Workshop { Id = 2, Name = "Цех #2", CityId = 1 },
            //        new Workshop { Id = 3, Name = "Цех #3", CityId = 2 }
            //    );

            //    modelBuilder.Entity<Employee>().HasData(
            //        new Employee { Id = 1, Name = "Иванов И.И.", WorkshopId = 1 },
            //        new Employee { Id = 2, Name = "Сергеев С.С.", WorkshopId = 2 },
            //        new Employee { Id = 3, Name = "Пушкин А.С.", WorkshopId = 3 }
            //    );

            //    modelBuilder.Entity<Brigade>().HasData(
            //        new Brigade { Id = 1, Name = "Бригада 1" },
            //        new Brigade { Id = 2, Name = "Бригада 2" }
            //    );
            //}
        }
    }
