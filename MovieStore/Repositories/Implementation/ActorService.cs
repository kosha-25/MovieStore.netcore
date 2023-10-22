using MovieStore.Models.Domain;
using MovieStore.Repositories.Abstract;

namespace MovieStore.Repositories.Implementation
{
    public class ActorService : IActorService
    {
        private readonly DatabaseContext context;
        public ActorService(DatabaseContext context)
        {
            this.context = context;
        }

        public bool Add(Actor model)
        {
            try
            {
                context.Actor.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                context.Actor.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Actor FindById(int id)
        {
            return context.Actor.Find(id);
        }

        public IEnumerable<Actor> GetAll()
        {
            return context.Actor.ToList();
        }

        public bool Update(Actor model)
        {
            try
            {
                context.Actor.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
