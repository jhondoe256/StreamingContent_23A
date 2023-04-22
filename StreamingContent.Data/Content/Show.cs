
public class Show : StreamingContentEntity
{
    public List<Episode> episodes = new List<Episode>();

    public int SeasonCount { get; set; }

    public int EpisodeCount { get; set; }

    public double AverageTime { get; set; }

    //empty Constructor
    public Show() { }

    //full constructor
    public Show(int seasonCount, int episodeCount, double averageTime, string title, string description, double starRating, MaturityRating rating,
                GenreType typeOfGenere)
    : base(title, description, starRating, rating ,typeOfGenere)
    {
        SeasonCount = seasonCount;
        EpisodeCount = episodeCount;
        AverageTime = averageTime;
    }

}
