using System.Text;
using System.Text.RegularExpressions;

namespace ChapterHelper
{
    class Program
    {
        private static Regex TimeLineRegex = new Regex(@"(\d+):(\d+):(\d+)\s(.*)");

        static void Main(string[] args)
        {
            if(args.Count() != 2)
            {
                Console.WriteLine("引数に間違いがあります。");

                return;
            }

            string inputFile = args[0];
            string outputFile = args[1];

            bool isInputfileExsits = File.Exists(inputFile);

            if(isInputfileExsits == false)
            {
                Console.WriteLine("入力ファイルが存在しません。");

                return;
            }

            StringBuilder outputBuilder = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFile))
            {
                int count = 1;


                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();

                    if (line != null)
                    {
                        Match match = TimeLineRegex.Match(line);

                        int hour = 0;
                        int min = 0;
                        int second = 0;
                        string chapterTitle = match.Groups[4].Value;

                        int.TryParse(match.Groups[1].Value, out hour);
                        int.TryParse(match.Groups[2].Value, out min);
                        int.TryParse(match.Groups[3].Value, out second);

                        string chapterText = $"CHAPTER{count:D2}={hour:D2}:{min:D2}:{second:D2}.000\n"
                            + $"CHAPTER{count:D2}NAME={chapterTitle}";

                        outputBuilder.AppendLine(chapterText);
                    }
                }
            }

            Encoding encoding = new UTF8Encoding(false);

            using (StreamWriter writer = new StreamWriter(outputFile, false, encoding))
            {

                string output = outputBuilder.ToString();
                writer.Write(output);
            }
        }
    }
}