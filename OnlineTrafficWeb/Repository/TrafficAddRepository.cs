using OnlineTrafficWeb.Data;
using OnlineTrafficWeb.Models;
using OnlineTrafficWeb.Repository.IRepository;

namespace OnlineTrafficWeb.Repository
{
    public class TrafficAddRepository : Repository<TrafficAdd>, ITrafficAddRepository
    {

        private ApplicationDbContext _db;

        public TrafficAddRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(TrafficAdd obj)
        {
            _db.TrafficAds.Update(obj);
        }
    }
}
