//
// Assignment 7.1
//
// 1. You are a student who has recently taken an exam with your
// classmates. However, the professor has not yet provided the
// students with a sorted list of exam scores. To make things
// easier, you write a program to sort exam scores in ascending
// order using the selection sort algorithm. This way, you can
// obtain the sorted list of scores and see how you performed
// compared to your classmates. Also, you choose selection sort
// since that is an easy way of implementation.
//

// initialize randomizer
Random random = new();
// main loop
do
{
    // clear each time new array & scores
    Console.Clear();

    // randomize size of array
    int[] randScores = new int[random.Next(4, 5)]; 

    for (int i = 0; i < randScores.Length; i++)
    {
        // assign random values to scores
        randScores[i] = random.Next(40, 101); 
    }
    // show currenting order of array
    ShowArray(randScores);

    int[] outputScores = new int[randScores.Length];

    // do ordering here:
    SelectionSort(randScores, out outputScores);

    // show finishing order of array
    ShowArray(outputScores);

    Console.WriteLine("\nESC to exit.");
} while (Console.ReadKey(true).Key != ConsoleKey.Escape);
//===========================================================
void SelectionSort(int[] array, out int[] result)
{
    for (int current = 0; current < (array.Length - 1); current++) // only go to one off from the end, don't go all the way 
    {
        int minElement = current;
        bool newlowestFound = false;
        for (int check = current + 1; check < array.Length; check++)
        {
            if (array[check] < array[minElement])
            {
                minElement = check;
                newlowestFound = true;
            }
        }

        if (newlowestFound)
        {
            //ShowArray(array, false);
            //Console.WriteLine("  (found minElement_" + array[minElement] + "  switching with current_" + array[current] + ")");
            
            //(array[current], array[lowestIndex]) = (array[lowestIndex], array[current]); // use tuple structure

            // or three way swap structure
            int temp = array[current];
            array[current] = array[minElement];
            array[minElement] = temp;
            newlowestFound = false;
        }


    }
    result = array;
}
//===========================================================
void ShowArray(int[] nums, bool newLine = true) // used for admin/main to show contents of 'stack' and test functionality
{
    //Console.Write(string.Join(", ", DataCache));
    Console.Write("   array is:  [");
    for (int i = 0; i < nums.Length; i++)
    {
        Console.Write(nums[i]);
        if (i < (nums.Length - 1))
        {
            Console.Write(", ");
        }
    }
    Console.Write("] ");
    if (newLine)
    {
        Console.WriteLine();
    }
}
//===========================================================