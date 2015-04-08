using System.Linq;

namespace ForumSystem.Common.Repository
{
    public interface IDeletableEntityRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();
    }
}
