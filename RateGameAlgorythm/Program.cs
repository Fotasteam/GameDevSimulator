Console.WriteLine("Input data to generate a game review.");

string input = Console.ReadLine();
int ammoutOfCommas = 0;

string genre1, genre2;
string platform;
int devTime;
string budget, publisher;
string topic1, topic2, topic3;
string marketing;
int ageRating;

foreach (char character in input)
{
    if (character ==  ',') ammoutOfCommas++;
}

for (int i = 0; i < ammoutOfCommas; ++i)
{

}