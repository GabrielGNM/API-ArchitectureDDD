using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            //MySQL var connectionString = "Server=localhost;Port=3306;DataBase=dbAPI;Uid=root;Pwd=mudar@123";
            var connectionString = "Server=.\\SQLEXPRESS2017; Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=mudar@123";
            //MySQL var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //MySQL optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
