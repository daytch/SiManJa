using System.Linq;
using uangsaku.Domain.Interfaces;
using uangsaku.Domain.Models;
using uangsaku.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace uangsaku.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(UangsakuContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
