using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casher.Properties.model
{
    public class CasherContext:DbContext
    {
        public DbSet<Customerr> customers { get; set; }
        public DbSet<Orderr> orders { get; set; }
        public DbSet<OrderItemm> orderItems { get; set; }
        public DbSet<Productt> products { get; set; }
        public DbSet<Categoryy> categories { get; set; }
        public DbSet<Storee> stores { get; set; }
        public DbSet<Adminn> admins { get; set; }
        public DbSet<Dto> dtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MEDOMATEBOOKD;
                                           DataBase=CasherDb;
                                          Trusted_Connection=True;");
        }
    }
}
