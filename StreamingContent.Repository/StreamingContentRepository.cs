
public class StreamingContentRepository
{
    //* This is the object that will hold ALL OF THE STREAMING CONTENT!
    //* this is a COLLECTION!
    //! It represents our DATABASE (ITS FAKE FOR NOW...)
    protected readonly List<StreamingContentEntity> _contentDirectory = new List<StreamingContentEntity>();

    //* We can use C.R.U.D on this collection!

    //? Create Method
    public bool AddContentToDirectory(StreamingContentEntity content)
    {
        //* Check the overall _contentDirectory count (how many are there)
        int startingCount = _contentDirectory.Count();

        //* Add the content to the fake database
        _contentDirectory.Add(content);

        //* Comparison to see if the startingCount is less than the _contentDirectory.Count
        bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
        return wasAdded;
    }

    //? Read -> ALL
    public List<StreamingContentEntity> GetAllContent()
    {
        return _contentDirectory;
    }

    //? Read -> UNIQUE IDENTIFIER (Title)
    //* This is considered to be a HELPER METHOD!
    public StreamingContentEntity GetContent(string title)
    {
        //loop through the collection(fake db)
        foreach (StreamingContentEntity content in _contentDirectory)
        {
            //logic that will compare what the user put in and what is in the _contentDirectory
            if (content.Title.ToLower() == title.ToLower())
            {
                return content;
            }
        }
        return null;
    }

    //? Update
    public bool UpdateExistingContent(string originalTitle, StreamingContentEntity newContent)
    {
        StreamingContentEntity oldContent = GetContent(originalTitle);

        //*Check to see if 'oldContent' exists
        if (oldContent != null)
        {
            oldContent.Title = newContent.Title;
            oldContent.Description = newContent.Description;
            oldContent.StarRating = newContent.StarRating;
            oldContent.TypeOfGenre = newContent.TypeOfGenre;

            return true;
        }
        return false;
    }

    //? Delete
    public bool DeleteExistingContent(StreamingContentEntity content)
    {
        bool deleteResult = _contentDirectory.Remove(content);
        return deleteResult;
    }

    //? you can make other methods 
    //? not restricted to C.R.U.D

    //* Get StreamingContent by Genere
    public List<StreamingContentEntity> GetContentByGenere(GenreType type)
    {
        //todo: start with an empty list:
        var genereList = new List<StreamingContentEntity>();

        //todo: loop through the entire directory
        foreach (StreamingContentEntity content in _contentDirectory)
        {
            //todo: find matching genere
            if (content.TypeOfGenre == type)
            {
                //todo: lets add it to the list
                genereList.Add(content);
            }
        }

        //todo: return the list that was made
        return genereList;
    }

    public List<StreamingContentEntity> GetContentByMaturity(MaturityRating matRating)
    {
        //L.I.N.Q   -> Language Integrated Query
        var sContent = _contentDirectory.Where(sc => sc.MaturityRating == matRating).ToList();
        return sContent;
    }
}
