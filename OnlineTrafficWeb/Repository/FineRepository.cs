using OnlineTrafficWeb.Data;
using OnlineTrafficWeb.Models;
using OnlineTrafficWeb.Repository.IRepository;

namespace OnlineTrafficWeb.Repository
{
    public class FineRepository : Repository<FineModel>, IFineRepository
    {

        private ApplicationDbContext _db;

        public FineRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(FineModel obj)
        {

            _db.FineModels.Update(obj);
        }
    }
}
