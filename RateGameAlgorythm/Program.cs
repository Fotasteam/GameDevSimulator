using System.Net;

string genre1 = "Simulation", genre2 = "Strategy";
string platform1 = "PC"; string platform2 = "XBlock"; string platform3 = "PayStation";
int devTime = 24;
string budget = "Small", publisher = "YES";
string topic1 = "Airplane", topic2 = "Transport", topic3 = "City";
string marketing = "Medium";
int ageRating = 9;
string dimention = "3D";
List<int> resourceAllocation = new List<int>() { 1, 4, 15, 19, 1, 10, 30, 15, 5 };
string monetization = "Paid"; string multiplayer = "Both";
int additionalComponentsTotal = 5, additionalComponentsMaxValue = 15;

var client = new WebClient();

string downloadedScores = client.DownloadString("https://raw.githubusercontent.com/Fotasteam/GameDevSimulator/master/Data/scores.txt");

List<string> rows = new List<string>();

var sr = new StringReader(downloadedScores);
string line = null;
while (true)
{
    line = sr.ReadLine();
    if (line != null)
    {
        if (!line.Contains(',') && !line.Contains('.'))
            rows.Add(line);
    }
    else
        break;
}

int topic1GenreScore = 0;
int topic2GenreScore = 0;
int topic3GenreScore = 0;
int genrePlatform1Score = 0;
int genrePlatform2Score = 0;
int genrePlatform3Score = 0;
int devTimeScore = 0;
int budgetGenreScore = 0;
int ageRatingScore = 0;
int dimentionGenreScore = 0;
int questGenreScore = 0;
int gameplayGenreScore = 0;
int engineGenreScore = 0;
int aiGenreScore = 0;
int dialogueGenreScore = 0;
int levelDesignGenreScore = 0;
int worldDesignGenreScore = 0;
int graphicsGenreScore = 0;
int soundGenreScore = 0;
int monetizationGenreScore = 0;
int monetizationPlatformScore = 0;
int multiplayerGenreScore = 0;

for (int i = 100; i < 109; i++)
{
    switch (i)
    {
        case 100:
            questGenreScore = (returnRequestedScore(determineGenreColumn(genre1), rows[i]) + returnRequestedScore(determineGenreColumn(genre2), rows[i])) / 2;
            break;
        case 101:
            gameplayGenreScore = (returnRequestedScore(determineGenreColumn(genre1), rows[i]) + returnRequestedScore(determineGenreColumn(genre2), rows[i])) / 2;
            break;
        case 102:
            engineGenreScore = (returnRequestedScore(determineGenreColumn(genre1), rows[i]) + returnRequestedScore(determineGenreColumn(genre2), rows[i])) / 2;
            break;
        case 103:
            aiGenreScore = (returnRequestedScore(determineGenreColumn(genre1), rows[i]) + returnRequestedScore(determineGenreColumn(genre2), rows[i])) / 2;
            break;
        case 104:
            dialogueGenreScore = (returnRequestedScore(determineGenreColumn(genre1), rows[i]) + returnRequestedScore(determineGenreColumn(genre2), rows[i])) / 2;
            break;
        case 105:
            levelDesignGenreScore = (returnRequestedScore(determineGenreColumn(genre1), rows[i]) + returnRequestedScore(determineGenreColumn(genre2), rows[i])) / 2;
            break;
        case 106:
            worldDesignGenreScore = (returnRequestedScore(determineGenreColumn(genre1), rows[i]) + returnRequestedScore(determineGenreColumn(genre2), rows[i])) / 2;
            break;
        case 107:
            graphicsGenreScore = (returnRequestedScore(determineGenreColumn(genre1), rows[i]) + returnRequestedScore(determineGenreColumn(genre2), rows[i])) / 2;
            break;
        case 108:
            soundGenreScore = (returnRequestedScore(determineGenreColumn(genre1), rows[i]) + returnRequestedScore(determineGenreColumn(genre2), rows[i])) / 2;
            break;
    }
}

foreach (var row in rows)
{
    int genreColumn1 = determineGenreColumn(genre1);
    int genreColumn2 = determineGenreColumn(genre2);
    int platformColumn1 = determineGenrePlatform(platform1);
    int platformColumn2 = determineGenrePlatform(platform2);
    int platformColumn3 = determineGenrePlatform(platform3);
    int points = 0;

    if (row.Contains(topic1))
    {
        points += returnRequestedScore(genreColumn1, row);
        points += returnRequestedScore(genreColumn2, row);
        topic1GenreScore = points * 3;
    }
    else if (row.Contains(topic2))
    {
        points += returnRequestedScore(genreColumn1, row);
        points += returnRequestedScore(genreColumn2, row);
        topic2GenreScore = points * 3;
    }
    else if (row.Contains(topic3))
    {
        points += returnRequestedScore(genreColumn1, row);
        points += returnRequestedScore(genreColumn2, row);
        topic3GenreScore = points * 3;
    }
    else if (row.Contains(platform1))
    {
        points += returnRequestedScore(genreColumn1, row);
        points += returnRequestedScore(genreColumn2, row);
        genrePlatform1Score = points * 2;
    }
    else if (row.Contains(platform2))
    {
        points += returnRequestedScore(genreColumn1, row);
        points += returnRequestedScore(genreColumn2, row);
        genrePlatform2Score = points * 2;
    }
    else if (row.Contains(platform3))
    {
        points += returnRequestedScore(genreColumn1, row);
        points += returnRequestedScore(genreColumn2, row);
        genrePlatform3Score = points * 2;
    }
    else if (row.Contains(devTime.ToString()))
    {
        points += returnRequestedScore(genreColumn1, row);
        points += returnRequestedScore(genreColumn2, row);
        devTimeScore = points;
    }
    else if (row.Contains(budget))
    {
        points += returnRequestedScore(genreColumn1, row);
        points += returnRequestedScore(genreColumn2, row);
        budgetGenreScore = points;
    }
    else if (row.Contains(ageRating.ToString()))
    {
        points += returnRequestedScore(genreColumn1, row);
        points += returnRequestedScore(genreColumn2, row);
        ageRatingScore = points * 2;
    }
    else if (row.Contains(dimention))
    {
        points += returnRequestedScore(genreColumn1, row);
        points += returnRequestedScore(genreColumn2, row);
        dimentionGenreScore = points * 2;
    }
    else if (row.Contains(monetization + "P"))
    {
        points += returnRequestedScore(genreColumn1, row);
        points += returnRequestedScore(genreColumn2, row);
        monetizationGenreScore = points;
    }
    else if (row.Contains(monetization + "G"))
    {
        points += returnRequestedScore(platformColumn1, row);
        points += returnRequestedScore(platformColumn2, row);
        points += returnRequestedScore(platformColumn3, row);
        monetizationPlatformScore = points;
    }
    else if (row.Contains(multiplayer))
    {
        points += returnRequestedScore(genreColumn1, row);
        points += returnRequestedScore(genreColumn2, row);
        multiplayerGenreScore = points;
    }
}

//46 linijek w pliku?

int gameScore = topic1GenreScore + topic2GenreScore + topic3GenreScore 
    + genrePlatform1Score + genrePlatform2Score + genrePlatform3Score
    + devTimeScore + budgetGenreScore + ageRatingScore + dimentionGenreScore
    + questGenreScore + gameplayGenreScore + engineGenreScore + aiGenreScore 
    + dialogueGenreScore + levelDesignGenreScore + worldDesignGenreScore 
    + graphicsGenreScore + soundGenreScore + monetizationGenreScore
    + monetizationPlatformScore + multiplayerGenreScore + additionalComponentsTotal;

int maxScore = 86 + additionalComponentsMaxValue; // dodaj do tego komponenty pozniej

double betaScoreDouble = gameScore / maxScore;

Random random = new Random();
int rand = random.Next(0, 2);
int betaScore;

if (rand == 0)
    betaScoreDouble = Math.Ceiling(betaScoreDouble);
else
    betaScoreDouble = Math.Floor(betaScoreDouble);

betaScore = Convert.ToInt32(betaScoreDouble);
return betaScore;

int returnRequestedScore(int column, string line)
{
    List<string> seperatedInformation = new List<string>();
    string sequence = "";
    for (int i = 0; i < line.Length; ++i)
    {
        if (line[i] != ' ')
        {
            sequence += line[i];
        }
        else
        {
            seperatedInformation.Add(sequence);
            sequence = "";
        }
    }

    return int.Parse(seperatedInformation[column]);
}

int determineGenreColumn(string item)
{
    switch (item)
    {
        case "Simulation":
            return 1;
        case "Action":
            return 2;
        case "Adventure":
            return 3;
        case "Puzzle":
            return 4;
        case "RPG":
            return 5;
        case "Strategy":
            return 6;
        case "Casual":
            return 7;
        case "MMO":
            return 8;
    }
    return 0;
}

int determineGenrePlatform(string item)
{
    switch (item)
    {
        case "PC":
            return 1;
        case "XBlock":
            return 2;
        case "PayStation":
            return 3;
        case "MyOs":
            return 4;
        case "ADroid":
            return 5;
        case "Tintendo":
            return 6;
    }
    return 0;
}