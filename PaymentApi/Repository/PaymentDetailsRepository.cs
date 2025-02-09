using Microsoft.EntityFrameworkCore;
using PaymentApi.Data;
using PaymentApi.Interfaces;
using PaymentApi.Models;

namespace PaymentApi.Repository
{
    public class PaymentDetailsRepository : IPaymentDetailsInterface
    {
        private readonly PaymentDetailsContext _context;

        public PaymentDetailsRepository(PaymentDetailsContext context)
        {
            _context = context;
        }
        public async Task<PaymentDetails> CreatePaymentDetailsAsync(PaymentDetails paymentDetails)
        {
            await _context.PaymentDetails.AddAsync(paymentDetails);
            await _context.SaveChangesAsync();
            return paymentDetails;
        }


        public async Task<bool> DeletePaymentDetailsAsync(int id)
        {
            var toDelete = await _context.PaymentDetails.FindAsync(id);
            if (toDelete == null)
            {
                return false;
            }
            _context.PaymentDetails.Remove(toDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PaymentDetails> GetPaymentDetailByIdasync(int id)
        {
            return await _context.PaymentDetails.FindAsync(id);
        }

        public async Task<List<PaymentDetails>> GetPaymentDetailsasync()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        public async Task<PaymentDetails> UpdatePaymentDetailsAsync(int id, PaymentDetails paymentDetails)
        {
            var toUpdate = await _context.PaymentDetails.FindAsync(id);
            if (toUpdate == null)
            {
                return null;
            }
            toUpdate.CardOwnerName = paymentDetails.CardOwnerName;
            toUpdate.CardNumber = paymentDetails.CardNumber;
            toUpdate.ExpirationDate = paymentDetails.ExpirationDate;
            toUpdate.SecurityCode = paymentDetails.SecurityCode;
            await _context.SaveChangesAsync();
            return toUpdate;

        }
    }
}
