using OnlineTrafficWeb.Models;

namespace OnlineTrafficWeb.Repository.IRepository
{
    public interface IFineHeaderRepository: IRepository<FineHeader>
    {
        void Update(FineHeader obj);

    void UpdateStatus(int id, string orderStatus, string? paymentstatus = null);
    void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);

    //save must be done in Repository ma but this is not the good practice 
}
}

