using PaymentApi.Models;

namespace PaymentApi.Interfaces
{
    public interface IPaymentDetailsInterface
    {
        Task<List<PaymentDetails>> GetPaymentDetailsasync();
        Task<PaymentDetails> GetPaymentDetailByIdasync(int id);
        Task<PaymentDetails> CreatePaymentDetailsAsync(PaymentDetails paymentDetails);
        Task<PaymentDetails> UpdatePaymentDetailsAsync(int id, PaymentDetails paymentDetails);
        Task<bool> DeletePaymentDetailsAsync(int id);
    }
}
