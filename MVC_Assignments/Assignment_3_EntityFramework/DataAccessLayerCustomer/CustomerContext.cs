using System;
using System.Collections.Generic;
using System.Data.Entity;
using BusinessLayerCustomer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerCustomer
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }

    }
}
