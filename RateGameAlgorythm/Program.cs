using System.Net;

string genre1, genre2;
string platform1; string platform2; string platform3;
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

int topicGenreScore = 0;
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
    if (row.Contains(topic1))
    {

    }
}