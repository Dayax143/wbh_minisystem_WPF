using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using fortest.Models;

namespace fortest.Services
{
    public class MyDbContext: DbContext
    {
<<<<<<< HEAD
        //string connectionString = "Data source=172.16.168.212; initial catalog=wbh_minisystem0; user id=sa; password=123; trustservercertificate=true";
        string connectionString = Properties.Settings.Default.ConnectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
=======

        string connectionString = "Server=rt\\rtser22;Database=wbh_minisystem;User Id=sa;Password=123; trustservercertificate=true;";
		//string connectionString = Properties.Settings.Default.ConnectionString;
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
>>>>>>> 4fa392265099729a6024549a2092d8a1510cf0c0
        {
            // Use your actual connection string here
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<tblLora> tblLora { get; set; } 
        public DbSet<TblPlate> tblPlates { get; set; }
        public DbSet<TblRfm> TblRfms { get; set; }
        public DbSet<TblUser> TblUser { get; set; }
        public DbSet<Test> Tests { get; set; }

        public DbSet<NewTable> new_table { get; set; }

    }
}
