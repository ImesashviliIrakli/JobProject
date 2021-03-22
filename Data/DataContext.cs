using JobProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JobProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {

        }
        public DbSet<acctInfo> acctInfos { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}