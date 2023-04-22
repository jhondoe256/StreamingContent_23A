
public class StreamingRepository : StreamingContentRepository
{
    public Show GetByTitle(string title)
    {
        foreach (var show in _contentDirectory)
        {
            if(show.Title.ToLower() == title.ToLower() && show.GetType() == typeof(Show))
            {
                return (Show)show;
            }
        }

        return null;
    }

    public Movie GetMovieByTitle(string title)
    {
        //? L.I.N.Q
        var movie = _contentDirectory.FirstOrDefault(mov => mov.Title.ToLower() == title.ToLower())!;
        return (Movie)movie;
    }

    public List<Show> GetAllShows()
    {
        // var allShows = new List<Show>();

        // foreach (var content in _contentDirectory)
        // {
        //     if(content is Show)
        //     {
        //         allShows.Add((Show)content);
        //     }
        // }

        // return allShows;
                                    //(Where)find a Show   -> .Select => Transform to Show Type.
        var allshows = _contentDirectory.Where(s => s is Show).Select(s=>new Show()).ToList();

        return allshows;
    }

    public List<Movie> GetAllMovies()
    {
        // var allMovies = new List<Movie>();

        // foreach (var content in _contentDirectory)
        // {
        //     if(content is Movie)
        //     {
        //         allMovies.Add((Movie)content);
        //     }
        // }

        // return allMovies;

        var allMovies = _contentDirectory.Where(m=>m is Movie).Select(m=>new Movie()).ToList();
        return allMovies;
    }
}


 //* Get by other parameters
        //* Get by RunTime/AverageRunTime
        //* Get Shows with over x episodes
        //* Get Shows/Movie By Rating