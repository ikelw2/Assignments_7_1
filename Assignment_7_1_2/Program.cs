//
// Assignment 7_1_2
//

// word1 and word2 consist of lowercase English letters.

// 2.You are given two strings word1 and word2. Merge the strings by adding
// letters in alternating order, starting with word1. If a string is longer
// than the other, append the additional letters onto the end of the merged
// string. Return the merged string.

// Example 1:
// Input: word1 = "abc", word2 = "pqr"
// Output: "apbqcr"
// Explanation: The merged string will be merged as so:
// word1: a b c
// word2: p q r
// merged: a p b q c r

// Example 2:
// Input: word1 = "ab", word2 = "pqrs"
// Output: "apbqrs"
// Explanation: Notice that as word2 is longer, "rs" is appended to the end.
// word1: a b
// word2: p q r s
// merged: a p b q r s



// initialize randomizer
using System.Text;

Random random = new();
// main loop
do
{
    // clear each time new array & scores
    Console.Clear();

    string allowedChars = "abcdefghijklmnopqrstuvwxyz";
    int minLength = 3;
    int maxLength = 8; // 15;
    // generate word length
    int word1Length = random.Next(minLength, maxLength + 1);
    int word2Length = random.Next(minLength, maxLength + 1);
    // generate random chars
    string word1 = GenerateRandomString(random, allowedChars, word1Length);
    string word2 = GenerateRandomString(random, allowedChars, word2Length);

    // print words at start
    Console.WriteLine($"Input: word1 = \"{word1}\", word2 = \"{word2}\"");

    string output = ZipperMergeStrings(word1, word2);

    Console.WriteLine($"Output: \"{output}\"");





    Console.WriteLine("\nESC to exit.");
} while (Console.ReadKey(true).Key != ConsoleKey.Escape);
//===========================================================

//===========================================================
string ZipperMergeStrings(string word1, string word2)
{
    // calculate integer difference between lengths of two words
    // positive if word1 is longer than word2,
    // or negative if word2 is longer than word1
    int difference = word1.Length - word2.Length;
    //Console.WriteLine("difference = " + difference);

    // initialize counter to lesser of two string lengths, or 1st string if equal lengths
    int shorterLength = (difference < 0) ? word1.Length : word2.Length;
    //Console.WriteLine("shorterLength (or 1st word if same length) = " + shorterLength);

    // initialize counter to greater of two string lengths, or 1st string if equal lengths
    int longerLength = (difference >= 0) ? word1.Length : word2.Length;
    //Console.WriteLine("longerLength (or 1st word if same length) = " + longerLength);

        // initialize empty output string
    string output = string.Empty;

    for (int i = 0; i < shorterLength; i++)
    {
        output += word1[i];
        output += word2[i];
        //Console.WriteLine(" " + output);
    }

    for (int i = shorterLength; i < longerLength; i++)
    {
        output += (difference >= 0) ? word1[i] : word2[i];
        //Console.WriteLine(" ." + output);
    }

    return output;
}
//===========================================================
string GenerateRandomString(Random random, string pool, int length)
{
    StringBuilder builder = new StringBuilder(length);

    for (int i = 0; i < length; i++)
    {
        // Pick a random index from the pool and append it
        int index = random.Next(pool.Length);
        builder.Append(pool[index]);
    }

    return builder.ToString();
}
