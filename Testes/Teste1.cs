using System;

namespace ScreenSound.Teste
{
    public class Teste1
    {
        public void DoIt()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("1", "One");
            dict.Add("2", "Two");
            dict.Add("3", "Three");
            dict.Add("4", "Four");
            dict.Add("5", "Five");

            Console.WriteLine(dict["1"]);
            Console.WriteLine(dict.Count);

        }
    }
}