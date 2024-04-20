using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Waigaya3.Models;

namespace Waigaya3.Data
{
    public class WaigayaDbContext : DbContext
    {
        // DBSet
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;

        //接続情報
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builer = new SqlConnectionStringBuilder();
            builer.DataSource = @"(localdb)\MSSQLLocalDB";
            // localDBを新規で作り直したいときは…
            // InitialCatalogをWaigaya●等に変更する
            builer.InitialCatalog = "WaigayaDB1";
            builer.IntegratedSecurity = true;

            string azureConnecitonString = "Server=tcp:{自分のSQLServiceを入れてね},1433;Initial Catalog=waigayadb;Persist Security Info=False;User ID=dbadmin;Password=Pacific123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            /*
             * LogTo( Action<string> でコンソールにSQLのログを出力する
             * 不要なログが多いので、Log出力のカテゴリーを指定: DbLoggerCategory.Database.Command.Name
             * LogLevelはInfomationに設定
             */
            bool isProduction = false;  // trueならAzure, falseならlocaldb
            string connectionString = isProduction ? 
                azureConnecitonString : builer.ConnectionString;
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