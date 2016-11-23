using System;
using System.Windows.Forms;

namespace ConvClipboardPath
{
    class Program
    {
        private static readonly string usage =
            @"Usage cmd [OPTION]" + "\n" +
            @"-bs    '\'BackSlash to '/'Slash" + "\n" +
            @"-hz    '\'hankaku to '￥'zenkaku" + "\n";
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Write(usage);
            }
            else
            {
                switch (args[0])
                {
                    case "-bs":
                        Clipboard.SetText(bsTos(Clipboard.GetText()));
                        break;
                    case "-hz":
                        Clipboard.SetText(hankakuToZenkaku(Clipboard.GetText()));
                        break;
                }
            }
        }
        static private string surround(string input)
        {
            if (input.Contains(" "))
            {
                return "\"" + input + "\"";
            }
            return input;
        }
        static private string bsTos(string input)
        {
            return surround(input).Replace("\\", "/");
        }
        static private string hankakuToZenkaku(string input)
        {
            return surround(input).Replace("\\", "￥");
        }
    }
}
