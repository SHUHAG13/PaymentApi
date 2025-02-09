using Microsoft.EntityFrameworkCore;
using PaymentApi.Models;

namespace PaymentApi.Data
{
    public class PaymentDetailsContext:DbContext
    {
       
        public PaymentDetailsContext(DbContextOptions<PaymentDetailsContext> options) : base(options)
        {
        }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
    }
}
