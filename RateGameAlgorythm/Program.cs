Console.WriteLine("Input data to generate a game review.");

string input = Console.ReadLine();
int ammountOfCommas = 0;

int genres, topics;
string genre1, genre2;
string platform;
int devTime;
string budget, publisher;
string topic1, topic2, topic3;
string marketing;
int ageRating, dimention;
List<int> resourceAllocation = new List<int>();
bool monetization; int multiplayer;

List<string> sequencesOfInput = new List<string>();

foreach (char character in input)
{
    if (character == ',') ++ammountOfCommas;
}

int i = 0;
for (int j = 0; j < ammountOfCommas; ++j)
{
    string currentSequence = "";
    while (input[i] != ',')
    {
        currentSequence += input[i];
        ++i;
    }
    ++i;
    sequencesOfInput.Add(currentSequence);
}

foreach (string seq in sequencesOfInput)
{
    Console.WriteLine(seq);
}