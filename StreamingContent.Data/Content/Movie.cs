
public class Movie : StreamingContentEntity
{
    public double RunTime {get;set;}

    //empty constructor
    public Movie (){}

    //full constructor, append the 'base' constructor
    public Movie(string title, string description, double starRating, MaturityRating maturityRating, GenreType typeOfGenere, double runTime)
    : base(title, description, starRating, maturityRating, typeOfGenere)
    {
        RunTime = runTime;
    }

}
