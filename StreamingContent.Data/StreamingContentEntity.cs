//* POCO => Plain Old C# Object
//* Abstraction -> what do we percive this content to be

public class StreamingContentEntity
{
    //*Full Constructor -> How we can create a StremingContent
    public StreamingContentEntity(
        string title,
        string description,
        double starRating,
        MaturityRating maturityRating,
        GenreType typeOfGenre
    )
    {
        Title = title;
        Description = description;
        StarRating = starRating;
        MaturityRating = maturityRating;
        TypeOfGenre = typeOfGenre;
    }

    public StreamingContentEntity() { }

    //* UNIQUE IDENTIFIER (Primary Key)
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public double StarRating { get; set; }

    public MaturityRating MaturityRating { get; set; }

    public bool IsFamilyFriendly
    {
        get
        {
            //* can put a 'switch' statement here
            switch (MaturityRating)
            {
                case MaturityRating.G:
                case MaturityRating.PG:
                case MaturityRating.TV_Y:
                case MaturityRating.TV_G:
                case MaturityRating.TV_PG:
                    return true;
                case MaturityRating.PG_13:
                case MaturityRating.R:
                case MaturityRating.NC_17:
                case MaturityRating.TV_14:
                case MaturityRating.TV_MA:
                default:
                    return false;
            }
        }
    }

    public GenreType TypeOfGenre { get; set; }
}
