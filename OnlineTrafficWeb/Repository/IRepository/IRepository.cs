using System.Linq.Expressions;

namespace OnlineTrafficWeb.Repository
{
        public interface IRepository<T> where T : class
        {
            //T- Category(suppose )
            T GetFirstorDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);
            //categorycontroller bata retrieve
            IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

            void Add(T entity);

            //update ko lagi generic repo ma narakhney

            //for Delete
            void Remove(T entity);
            void RemoveRange(IEnumerable<T> entity);
        }
}
