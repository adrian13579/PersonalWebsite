
namespace PersonalWebsite.Components.Terminal
{
    public class CommandLineParser
    {
        public static List<string> Parse(string command)
        {
            return command.Split(' ').ToList();
        }
    }
}
