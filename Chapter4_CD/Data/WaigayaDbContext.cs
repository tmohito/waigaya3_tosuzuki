using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Waigaya3.Models;

namespace Waigaya3.Data
{
    public class WaigayaDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        // DBSet
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;

        public WaigayaDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //接続情報
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = configuration.GetConnectionString("WaigayaDB");
            optionsBuilder.UseSqlServer(connectionString)
              .LogTo(message =>
              System.Diagnostics.Debug.WriteLine(message),
              new[] { DbLoggerCategory.Database.Command.Name },
              LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Migration時にUp()メソッドで、Insertされる初期データ
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Title = "回復アイテム", CreatedAt = DateTime.Now },
                new Category { Id = 2, Title = "武器", CreatedAt = DateTime.Now },
                new Category { Id = 3, Title = "防具", CreatedAt = DateTime.Now },
                new Category { Id = 4, Title = "家電", CreatedAt = DateTime.Now },
                new Category { Id = 5, Title = "生活用品", CreatedAt = DateTime.Now }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "エクスカリバー", Description = "エクスカリバーには、普通の剣には無い特別な力が備わって\r\nいたと考えられています。敵の攻撃を跳ね返す魔力や、所持\r\n者に無敵の力を与える等の能力が伝承されています。", Price = 54000, CategoryId = 2, CreatedAt = DateTime.Now },
                new Product { Id = 2, Name = "ヒートテック", Description = "ユニクロで売ってます", Price = 2000, CategoryId = 3, CreatedAt = DateTime.Now },
                new Product { Id = 3, Name = "掃除機", Description = "ダイソンではない", Price = 30000, CategoryId = 1, CreatedAt = DateTime.Now },
                new Product { Id = 4, Name = "プロテイン", Description = "たんぱく質を英語でいうとプロテイン", Price = 4000, CategoryId = 5, CreatedAt = DateTime.Now },
                new Product { Id = 5, Name = "500mlの水", Description = "ただの水です", Price = 100, CategoryId = 5, CreatedAt = DateTime.Now }
            );
        }
    }
}