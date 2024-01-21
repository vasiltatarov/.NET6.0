using System.Buffers;

// Feature 1

Method(1,562,3);

void Method(params int[] arr)
{
    Console.WriteLine(string.Join(", ", arr));
}

// Feature 2
Console.WriteLine("----------------------------------");

const string base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

SearchValues<char> base64SearchVals = SearchValues.Create(base64Chars);

Console.WriteLine(IsBase64("as89dha98d="));
Console.WriteLine(IsBase64("as89d$ha98d="));

bool IsBase64(string exampleText)
{
    return exampleText.AsSpan().IndexOfAnyExcept(base64SearchVals) == -1;
}
