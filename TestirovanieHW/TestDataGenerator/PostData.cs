namespace TestDataGenerator;

public class PostData
{
    public PostData()
    {
    }

    public PostData(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
}