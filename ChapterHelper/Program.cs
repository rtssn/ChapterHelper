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

            List<Chapter> chapters = new List<Chapter>();

            using(StreamReader reader = new StreamReader(inputFile))
            {
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

                        int timestamp = (hour * 60 + min * 60 + second) * 1000;

                        Chapter chapter = new Chapter();
                        chapter.ChapterTitle = chapterTitle;
                        chapter.Timestamp = timestamp;

                        chapters.Add(chapter);
                    }
                }
            }
        }
    }
}