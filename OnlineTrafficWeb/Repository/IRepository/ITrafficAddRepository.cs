using OnlineTrafficWeb.Models;
namespace OnlineTrafficWeb.Repository.IRepository
{

    public interface ITrafficAddRepository : IRepository<TrafficAdd>
    {
        void Update(TrafficAdd obj);

        //save must be done in Repository ma but this is not the good practice 
    }
}
