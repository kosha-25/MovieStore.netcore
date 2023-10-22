using MovieStore.Models.Domain;
using MovieStore.Repositories.Abstract;

namespace MovieStore.Repositories.Implementation
{
    public class MovieService:IMovieService
    {
        private readonly DatabaseContext context;
        public MovieService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Movie model)
        {
            try
            {
                context.Movie.Add(model);
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
                context.Movie.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Movie FindById(int id)
        {
            return context.Movie.Find(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            var data = (from movie in context.Movie
                        join actor in context.Actor
                        on movie.ActorId equals actor.Id
                        join director in context.Director on movie.DirectorId equals director.Id
                        join genre in context.Genre on movie.GenreId equals genre.Id
                        select new Movie
                        {
                            Id = movie.Id,
                            Title = movie.Title,
                            ImgURL = movie.ImgURL,
                            ActorId = movie.ActorId,
                            DirectorId = movie.DirectorId,
                            GenreId = movie.GenreId,
                            
                            
                            
                            Price = movie.Price,
                            ActorName = actor.ActorName,
                            DirectorName = director.DirectorName,
                            GenreName = genre.Name
                           
                        }
                        ).ToList();
            return data;
        }

        public bool Update(Movie model)
        {
            try
            {
                context.Movie.Update(model);
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
