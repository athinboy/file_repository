using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Text;

namespace SimpleRunTest
{
    internal class Program
    {

        static string[] _args;

        static void Main(string[] args)
        {

            IReadOnlyDictionary<string, object> results = GC.GetConfigurationVariables();
            foreach (var result in results)
            {
                Console.WriteLine("{ " + $"{result.Key} : {result.Value?.ToString()}" + " }");
            }
            _args = args;
            for (int i = 0; i < 1; i++)
            {
                Test();
                TestList();
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10; i++)
            {
                Test();
            }
            sw.Stop();
            Console.WriteLine(nameof(Test));
            Console.WriteLine(sw.ElapsedMilliseconds);


            sw.Restart();
            for (int i = 0; i < 10; i++)
            {
                TestList();
            }
            Console.WriteLine(nameof(TestList));
            Console.WriteLine(sw.ElapsedMilliseconds);

        }


        public static void Test()
        {
            Console.WriteLine(nameof(Test));
            Stopwatch sw = new Stopwatch();
            int count = int.Parse(_args == null || _args.Length == 0 ? "10000000" : _args[0]);
            Console.WriteLine(count);
            sw.Start();

            //Span<StringBuilder> list = new Span<StringBuilder>();
            List<StringBuilder> list = new List<StringBuilder>();

            for (int i = 0; i < count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"hellow world.{i}");
                //list.Fill(sb);
                list.Add(sb);
            }
            //foreach (StringBuilder sb in list)
            //{
            //    sb.ToString();
            //}
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }


        public static void TestList()
        {

            Console.WriteLine(nameof(TestList));
            Stopwatch sw = new Stopwatch();
            int count = int.Parse(_args == null || _args.Length == 0 ? "10000000" : _args[0]);
            Console.WriteLine(count);
            sw.Start();


            List<String> list = new List<String>();

            for (int i = 0; i < count; i++)
            {
                string str = @"hellow world." + i.ToString();

                list.Add(str);
            }
            //foreach (StringBuilder sb in list)
            //{
            //    sb.ToString();
            //}
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
