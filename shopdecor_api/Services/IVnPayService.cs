using shopdecor_api.Data;
using shopdecor_api.ViewModel;

namespace shopdecor_api.Services
{
    public interface IVnPayService
    {
        string CreatePaymentUrl (SeabugDbContext context, VnPaymentRequestModel model);
        VnPaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
