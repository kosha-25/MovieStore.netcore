using MovieStore.Models.Domain;

namespace MovieStore.Repositories.Abstract
{
    public interface IActorService
    {
        bool Add(Actor model);
        bool Update(Actor model);
        bool Delete(int id);
        Actor FindById(int id);
        IEnumerable<Actor> GetAll();
    }
}
