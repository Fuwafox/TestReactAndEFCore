using Microsoft.EntityFrameworkCore;
using TestReactAndEFCore.Models;

namespace TestReactAndEFCore.Help
{
    public class ApplicationContext<T>: DbContext where T:class/*определяет контекст данных, используемый для взаимодействия с базой данных*/
    {
        /// <summary>
        /// DbSet/DbSet<TEntity>:представляет набор объектов, которые хранятся в базе данных
        /// </summary>
        public DbSet<T> Users => Set<T>();
        /// <summary>
        ///EnsureCreated при создании контекста автоматически проверит наличие базы данных и, если она отсуствует, создаст ее
        /// </summary>
        public ApplicationContext(DbContextOptions<ApplicationContext<T>> options):base(options) => Database.EnsureCreated();


    }
}
