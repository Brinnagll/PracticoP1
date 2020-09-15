using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiWebGorena.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {
           
        }

        public System.Data.Entity.DbSet<ApiWebGorena.Models.Gorena> Gorenas { get; set; }
    }
}