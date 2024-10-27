// a) Write a function in C# that reverses a string without using predefined methods like Array.Reverse or String.Reverse. (5 points)

// get input values from the prompt

using System.Text;

try
{
    Console.WriteLine("###### Write down the string to be reverted ######");
    string? inputValue = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(inputValue))
    {
        throw new ArgumentNullException(inputValue);
    }
    
    Console.WriteLine(RevertString(inputValue));
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
}

return;

// This is the method that reverts the string
static string RevertString(string value)
{
    StringBuilder reverted = new();
    for (int index = value.Length - 1; index >= 0; index--)
        reverted.Append(value[index]);

    return reverted.ToString();
}