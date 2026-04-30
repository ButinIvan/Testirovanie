using System.Xml.Serialization;

namespace TestDataGenerator;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: TestDataGenerator.exe <count> <file> <format>");
            return;
        }

        int count = Convert.ToInt32(args[0]);
        string file = args[1];
        string format = args[2];

        List<PostData> posts = GeneratePosts(count);

        if (format == "xml")
        {
            WritePostsToXmlFile(posts, file);
        }
        else
        {
            Console.WriteLine("Unsupported format: " + format);
        }
    }

    static List<PostData> GeneratePosts(int count)
    {
        List<PostData> posts = new List<PostData>();

        for (int i = 0; i < count; i++)
        {
            posts.Add(new PostData("Тестовое сообщение " + DateTime.Now.Ticks + "_" + i));
        }

        return posts;
    }

    static void WritePostsToXmlFile(List<PostData> posts, string file)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<PostData>));

        using (StreamWriter writer = new StreamWriter(file))
        {
            serializer.Serialize(writer, posts);
        }
    }
}