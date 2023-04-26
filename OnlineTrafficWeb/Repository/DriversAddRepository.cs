using OnlineTrafficWeb.Data;
using OnlineTrafficWeb.Models;
using OnlineTrafficWeb.Repository.IRepository;

namespace OnlineTrafficWeb.Repository
{
    public class DriversAddRepository : Repository<DriversAdd>, IDriversAddRepository
    {

        private ApplicationDbContext _db;

        public DriversAddRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(DriversAdd obj)
        {
            _db.DriversAds.Update(obj);
        }
    }
}
