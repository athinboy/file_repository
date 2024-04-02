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

            IReadOnlyDictionary<string, object> gcConfigs = GC.GetConfigurationVariables();
            foreach (var c in gcConfigs)
            {
                Console.WriteLine("{ " + $"{c.Key} : {c.Value?.ToString()}" + " }");
            }
            _args = args;
            for (int i = 0; i < 1; i++)
            {
                Test();
                TestList();
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Dictionary<string, long> result = new Dictionary<string, long>();
            for (int i = 0; i < 10; i++)
            {
                Test();
            }
            sw.Stop();
            result.Add(nameof(Test), sw.ElapsedMilliseconds);


            sw.Restart();
            for (int i = 0; i < 10; i++)
            {
                TestList();
            }
            result.Add(nameof(TestList), sw.ElapsedMilliseconds);

            foreach (var c in result)
            {
                Console.WriteLine("{ " + $"{c.Key} : {c.Value}" + " }");
            }
        }


        public static void Test()
        {
            Console.Write(nameof(Test) + "_");
            Stopwatch sw = new Stopwatch();
            int count = int.Parse(_args == null || _args.Length == 0 ? "10000000" : _args[0]);
            Console.Write(count + "_");
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

            Console.Write(nameof(TestList) + "_");
            Stopwatch sw = new Stopwatch();
            int count = int.Parse(_args == null || _args.Length == 0 ? "10000000" : _args[0]);
            Console.Write(count + "_");

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
