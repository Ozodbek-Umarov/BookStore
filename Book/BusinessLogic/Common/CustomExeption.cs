namespace Book.BusinessLogic.Common;

public class CustomExeption(string key, string message)
    : Exception(message)
{
    public string Key { get; } = key;
}
