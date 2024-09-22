using Microsoft.EntityFrameworkCore;
using Proyecto17.Entities;

namespace Proyecto17.Context
{
    public class ProductoContext : DbContext 
    {
        #region"Constructor"
        public ProductoContext(DbContextOptions<ProductoContext> options) : base(options)
        {

        }
        #endregion

        #region"Db Sets"
        public DbSet<Productos> Productos { get; set; }
        #endregion
    }
}
