using OnlineTrafficWeb.Models;

namespace OnlineTrafficWeb.Repository.IRepository
{
    public interface IDriversAddRepository : IRepository<DriversAdd>
    {
        void Update(DriversAdd obj);

        //save must be done in Repository ma but this is not the good practice 
    }
}
