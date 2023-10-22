using MovieStore.Models.Domain;

namespace MovieStore.Repositories.Abstract
{
    public interface IDirectorService
    {
        bool Add(Director model);
        bool Update(Director model);
        bool Delete(int id);
        Director FindById(int id);
        IEnumerable<Director> GetAll();
    }
}
