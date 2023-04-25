
public class ProgramUI
{
    private readonly IConsole _console;

    public ProgramUI(IConsole console)
    {
        _console = console;
    }

    private readonly StreamingContentRepository _scRepo = new StreamingContentRepository();

    //Entry Point to app
    public void Run()
    {
        SeedContentList();
        RunMenu();
    }

    private void RunMenu()
    {
        bool continueToRun = true;

        while (continueToRun)
        {
            _console.Clear();
            _console.WriteLine("Please Make a Selection:\n" +
            "1. Show All Streaming Content\n" +
            "2. Find Streaming Content by Title\n" +
            "3. Add New Streaming Content\n" +
            "4. Update Existing Content\n" +
            "5. Remove Streaming Content\n" +
            "6. Exit Application\n"
            );

            string userInput = _console.ReadLine()!;

            switch (userInput)
            {
                case "1":
                case "one":
                    ShowAllContent();
                    break;

                case "2":
                case "two":
                    ShowContentByTitle();
                    break;

                case "3":
                case "three":
                    CreateNewStreamingContent();
                    break;

                case "4":
                case "four":
                    UpdateExistingContent();
                    break;

                case "5":
                case "five":
                    RemoveContentFromList();
                    break;

                case "6":
                case "six":
                    continueToRun = false;
                    _console.WriteLine("Thanks for using Streaming Content!");
                    PauseUntilKeyPress();
                    _console.Clear();
                    break;

                default:
                    _console.WriteLine("Please enter a valid number between 1-6.");
                    PauseUntilKeyPress();
                    break;
            }
        }
    }

    private void RemoveContentFromList()
    {
        //1. Get complete list of streaming content
        //todo: Remember List<T> start at index 0. (any collection)
        List<StreamingContentEntity> contentList = _scRepo.GetAllContent();

        //2. check if there is any content in 'contentList'
        if (contentList.Count() > 0)
        {
            //3. Ask user which content to remove
            _console.WriteLine("Which would you like to remove.");

            //4. Menu counter
            int count = 0;
            foreach (var content in contentList)
            {
                count++;
                _console.WriteLine($"{count}. {content.Title}");
            }

            //5. Manipulate user input
            int targetContentId = int.Parse(_console.ReadLine()!);
            int targetIndex = targetContentId - 1;

            if (targetIndex >= 0 && targetIndex < contentList.Count())
            {
                StreamingContentEntity desiredContent = contentList[targetIndex];

                if (_scRepo.DeleteExistingContent(desiredContent))
                {
                    _console.WriteLine($"{desiredContent.Title} successfully removed.");
                }
                else
                {
                    _console.WriteLine("Deletion unsuccessful!");
                }
            }
            else
            {
                _console.WriteLine("I can't do that!, No content has that ID.");
            }
        }
        else
        {
            _console.WriteLine("Sorry there is no content available.");
        }
    }

    private void UpdateExistingContent()
    {
        try
        {
            //Find the content by title for update.
            _console.WriteLine("Please input a Title.");
            var userInput = _console.ReadLine();

            var content = _scRepo.GetContent(userInput!);

            if (content != null)
            {
                _console.Clear();

                StreamingContentEntity scContent = new StreamingContentEntity();

                //create empty form
                _console.WriteLine("Please enter a title: ");
                scContent.Title = _console.ReadLine()!;

                _console.WriteLine("Please enter a description: ");
                scContent.Description = _console.ReadLine()!;

                _console.WriteLine("Please enter a star rating (1-10)");
                scContent.StarRating = double.Parse(_console.ReadLine()!);

                scContent.MaturityRating = GiveMeAMaturityRating(scContent);
                _console.Clear();
                _console.WriteLine("Select a Genre: \n" +
                "1. Horror\n" +
                "2. RomCom\n" +
                "3. SciFi\n" +
                "4. Documentary\n" +
                "5. Bromance\n" +
                "6. Drama\n" +
                "7. Action\n");

                string genreInput = _console.ReadLine()!;
                int genreValue = int.Parse(genreInput);

                scContent.TypeOfGenre = (GenreType)genreValue;

                //see if EVERTHNIG IS GOING TO WORK
                bool isSuccessfull = _scRepo.UpdateExistingContent(content.Title, scContent);
                if (isSuccessfull)
                {
                    _console.WriteLine($"The content named: {scContent.Title} WAS UPDATED to the database.");
                }
                else
                {
                    _console.WriteLine($"The content named: {scContent.Title} WAS NOT UPDATED to the database.");
                }

            }
            else
            {
                _console.WriteLine($"Sorry, no available content: {userInput}");
            }
            //  PauseUntilKeyPress();
        }
        catch (Exception ex)
        {
            _console.WriteLine(ex.Message);
        }
        PauseUntilKeyPress();
    }

    private void CreateNewStreamingContent()
    {
        _console.Clear();

        //create empty form
        StreamingContentEntity content = new StreamingContentEntity();

        _console.WriteLine("Please enter a title: ");
        content.Title = _console.ReadLine()!;

        _console.WriteLine("Please enter a description: ");
        content.Description = _console.ReadLine()!;

        _console.WriteLine("Please enter a star rating (1-10)");
        content.StarRating = double.Parse(_console.ReadLine()!);

        content.MaturityRating = GiveMeAMaturityRating(content);
        _console.Clear();
        _console.WriteLine("Select a Genre: \n" +
        "1. Horror\n" +
        "2. RomCom\n" +
        "3. SciFi\n" +
        "4. Documentary\n" +
        "5. Bromance\n" +
        "6. Drama\n" +
        "7. Action\n");

        string genreInput = _console.ReadLine()!;
        int genreValue = int.Parse(genreInput);

        content.TypeOfGenre = (GenreType)genreValue;

        _console.WriteLine("Is this a:\n" +
        "1. Movie\n" +
        "2. Show\n");

        var streamingContentValue = ConvertMe(content);
        _console.WriteLine($"Streaming content is now of type: {streamingContentValue.GetType().Name}");

        //see if EVERTHNIG IS GOING TO WORK
        bool isSuccessfull = _scRepo.AddContentToDirectory(streamingContentValue);
        if (isSuccessfull)
        {
            _console.WriteLine($"The content named: {streamingContentValue.Title} WAS ADDED to the database.");
        }
        else
        {
            _console.WriteLine($"The content named: {streamingContentValue.Title} WAS NOT ADDED to the database.");
        }

        PauseUntilKeyPress();
    }

    private StreamingContentEntity ConvertMe(StreamingContentEntity content)
    {

        string userInputSC_contentType = _console.ReadLine()!;
        switch (userInputSC_contentType)
        {
            case "1":
            case "Movie":
                _console.WriteLine("-- Movie Creation Menu --");
                _console.WriteLine("Please enter this movies runtime.");
                double movieRuntime = double.Parse(_console.ReadLine()!);
                var movie = new Movie(
                content.Title
                , content.Description
                , content.StarRating
                , content.MaturityRating
                , content.TypeOfGenre
                , movieRuntime
                );
                return movie;

            case "2":
            case "Show":
                _console.WriteLine("-- Show Creation Menu --");

                _console.WriteLine("Please enter the Season Count.");
                int seasonCount = int.Parse(_console.ReadLine()!);

                _console.WriteLine("Please enter the Episode Count.");
                int episodeCount = int.Parse(_console.ReadLine()!);

                _console.WriteLine("Please enter the episode runtime.");
                double showRuntime = double.Parse(_console.ReadLine()!);
                var show = new Show(
                  seasonCount
                , episodeCount
                , showRuntime
                , content.Title
                , content.Description
                , content.StarRating
                , content.MaturityRating
                , content.TypeOfGenre
                );
                return show;
            default:
                _console.WriteLine("Sorry, invalid selection. Returning Default Type (Streaming Content Entity).");
                return content;
        }
    }

    private MaturityRating GiveMeAMaturityRating(StreamingContentEntity content)
    {
        _console.WriteLine("Select a Maturity rating:\n" +
        "1. G\n" +
        "2. PG\n" +
        "3. PG 13\n" +
        "4. R\n" +
        "5. NC 17\n" +
        "6. TV Y\n" +
        "7. TV G\n" +
        "8. TV PG\n" +
        "9. TV 14\n" +
        "10. TV MA\n"
        );

        string maturityRating = _console.ReadLine()!;

        switch (maturityRating)
        {
            case "1":
                return MaturityRating.G;
            case "2":
                return MaturityRating.PG;
            case "3":
                return MaturityRating.PG_13;
            case "4":
                return MaturityRating.R;
            case "5":
                return MaturityRating.NC_17;
            case "6":
                return MaturityRating.TV_Y;
            case "7":
                return MaturityRating.TV_G;
            case "8":
                return MaturityRating.TV_PG;
            case "9":
                return MaturityRating.TV_14;
            case "10":
                return MaturityRating.TV_MA;
            default:
                _console.WriteLine("Invalid Operation");
                return MaturityRating.UNDEFINED;
        }
    }

    private void ShowContentByTitle()
    {
        _console.Clear();
        _console.WriteLine("Enter a Title: ");
        string title = _console.ReadLine()!;

        StreamingContentEntity content = _scRepo.GetContent(title);
        if (content != null)
        {
            DisplayContent(content);
        }
        else
        {
            _console.WriteLine("Invalid title. Could not find resuls.");
        }

        PauseUntilKeyPress();
    }

    private void ShowAllContent()
    {
        _console.Clear();

        List<StreamingContentEntity> ListOfContent = _scRepo.GetAllContent();

        foreach (StreamingContentEntity content in ListOfContent)
        {
            DisplayContent(content);
        }

        PauseUntilKeyPress();
    }

    private void DisplayContent(StreamingContentEntity content)
    {
        _console.WriteLine($"Title: {content.Title}\n" +
        $"Description: {content.Description}\n" +
        $"Genere: {content.TypeOfGenre}\n" +
        $"Stars: {content.StarRating}\n" +
        $"Family Frendly: {content.IsFamilyFriendly}\n" +
        $"Rating: {content.MaturityRating}\n");
    }

    private void PauseUntilKeyPress()
    {
        _console.WriteLine("Press any key to continue.");
        _console.ReadKey();
    }

    private void SeedContentList()
    {
        //Create some content
        StreamingContentEntity rubber = new StreamingContentEntity("Rubber",
        "Tyre that comes to life and kills people.",
        5.8d,
        MaturityRating.R,
        GenreType.Horror);

        StreamingContentEntity toyStory = new StreamingContentEntity("Toy Story",
         "Best childhood movie.",
          10.0d,
          MaturityRating.G,
        GenreType.Bromance);

        var starWars = new StreamingContentEntity("Star Wars",
        "Jar Jar saves the world!!!",
        9.2d,
         MaturityRating.PG_13,
        GenreType.SciFi);

        //* Add to _scRepo (The Repository)
        _scRepo.AddContentToDirectory(rubber);
        _scRepo.AddContentToDirectory(toyStory);
        _scRepo.AddContentToDirectory(starWars);
    }
}
