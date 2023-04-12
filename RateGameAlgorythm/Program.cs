Console.WriteLine("Input data to generate a game review.");

string input = Console.ReadLine();
int ammountOfCommas = 0;

string genre1, genre2;
string platform;
int devTime;
string budget, publisher;
string topic1, topic2, topic3;
string marketing;
int ageRating, dimention;
List<int> resourceAllocation = new List<int>();
bool monetization; int multiplayer;

//List<string> sequencesOfInput = new List<string>();

//foreach (char character in input)
//{
//    if (character == ',') ++ammountOfCommas;
//}

//int j = 0;
//for (int i = 0; i < ammountOfCommas; ++i)
//{
//    string currentSequence = "";
//    while (input[j] != ',')
//    {
//        currentSequence += input[j];
//        ++j;
//    }
//    ++j;
//    sequencesOfInput.Add(currentSequence);
//}

//for (int i = 0; i < sequencesOfInput.Count; ++i)
//{
//    Console.WriteLine(sequencesOfInput[i]);

//    switch (i)
//    {
//        case 0:
            
//            break;

//        case 1:
//            break;

//        default:
//            Console.WriteLine("Something went wrong...");
//            break;
//    }
//}

