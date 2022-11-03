using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class HostContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connStr = "Data Source=SQL5105.site4now.net;Initial Catalog=db_a8dfed_mydatabase1;User Id=db_a8dfed_mydatabase1_admin;Password=2657sgnusmas";
            builder.UseSqlServer(connStr);
        }
    }
}
