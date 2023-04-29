using OnlineTrafficWeb.Data;
using OnlineTrafficWeb.Models;
using OnlineTrafficWeb.Repository.IRepository;

namespace OnlineTrafficWeb.Repository
{
    public class FineHeaderRepository : Repository<FineHeader>, IFineHeaderRepository
    {
        private ApplicationDbContext _db;

        public FineHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(FineHeader obj)
        {
            _db.FineHeaders.Update(obj);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentstatus = null)
        {
            var orderFromDb = _db.FineHeaders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.FineStatus = orderStatus;
                if (paymentstatus != null)
                {
                    orderFromDb.PaymentStatus = paymentstatus;
                }
            }
        }

        public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
            var orderFromDb = _db.FineHeaders.FirstOrDefault(u => u.Id == id);
            orderFromDb.SessionId = sessionId;
            orderFromDb.PaymentIntentId = paymentIntentId;

        }
    }
}
