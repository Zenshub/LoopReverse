using System;
using System.Linq;

namespace LoopReverse
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            string text = "Reverse words in this sentence";
            var fortext = ForLoopReverse(text);
            Console.WriteLine("For Loop Reverse: \n" + fortext);
            var whiletext = WhileLoopReverse(text);
            Console.WriteLine("While Loop Reverse: \n" + whiletext);
            var foreachtext = ForEachLoopReverse(text);
            Console.WriteLine("Foreach Loop Reverse: \n" + foreachtext);
            var gototext = StupidGotoReverse(text);
            Console.WriteLine("Stupid GoTo Reverse: \n" + gototext);
            var linqtext = LinqReverse(text);
            Console.WriteLine("Linq Reverse: \n" + linqtext);
        }

        private static string ForLoopReverse(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            string rtext = string.Empty;
            string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i].ToCharArray();

                var rword = string.Empty;
                for (int j = word.Length - 1; j >= 0; j--)
                {
                    rword += word[j].ToString();
                }

                rtext += rword + " ";
            }
            return rtext;
        }


        private static string WhileLoopReverse(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            var words = text.Split(' ');

            var rtext = string.Empty;
            int i = 0;

            while (i < words.Length)
            {
                var word = words[i].ToCharArray();
                var rword = string.Empty;
                int len = word.Length;
                int index = len - 1;
                while (index >= 0)
                {
                    rword += word[index];
                    index--;
                }
                rtext += rword + " ";
                i++;
            }
            return rtext;
        }

        private static string ForEachLoopReverse(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            var words = text.Split(' ');

            var rtext = string.Empty;
            foreach (var word in words)
            {
                string rword = string.Empty;
                foreach (var ch in word.ToCharArray())
                {
                    rword = ch + rword;
                }
                rtext += rword + " ";
            }
            return rtext;
        }

        private static string LinqReverse(string text)
        {
            return string.Join(" ", text.Split(' ').Select(x => new String(x.Reverse().ToArray())));
        }

        //This is the first time I use this stupid goto statement and will be the only one time ever.
        private static string StupidGotoReverse(string text)
        {
            var rtext = string.Empty;
            if (string.IsNullOrWhiteSpace(text))
                goto outside;
            else
                goto nextStep;

            nextStep:
            var words = text.Split(' ');
            var len = words.Length;
            int i = 0;
            goto theword;

        theword:
            var word = words[i];
            int index = word.Length - 1;
            var rword = string.Empty;
            goto thechar;

        thechar:
            rword += word[index];
            index--;
            if (index >= 0)
                goto thechar;
            else
                goto theRtext;


            theRtext:
            rtext += rword + " ";
            i++;
            if (i < len)
                goto theword;
            else
                goto outside;


            outside:
            return rtext;
        }
    }
}
