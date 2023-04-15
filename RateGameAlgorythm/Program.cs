using System.Net;

string genre1 = "Simulation", genre2 = "Strategy";
string platform1 = "PC"; string platform2 = "XBlock"; string platform3 = "PayStation";
int devTime;
string budget, publisher;
string topic1, topic2, topic3;
string marketing;
int ageRating, dimention;
List<int> resourceAllocation = new List<int>();
bool monetization; int multiplayer;

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
int genrePlatformScore = 0;
int budgetGenreScore = 0;
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
        topic1GenreScore = points;
    }
    else if(row.Contains(topic2))
    {

    }
    else if (row.Contains(topic3))
    {

    }
}

int returnRequestedScore(int column, string line)
{
    for (int i = 0; i < line.Length; ++i)
    {
        if (line[i] != ' ')
        {

        }
    }

    return 0;
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