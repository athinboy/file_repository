

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using System.Collections;
using System.Diagnostics;
using System.Text;
namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var sw = System.Diagnostics.Stopwatch.StartNew();
            //List<long> times = new List<long>();
            //int j = 0;
            //while (true)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    long t1 = sw.ElapsedMilliseconds;
            //    for (int i = 0; i < int.MaxValue / 50; i++)
            //    {
            //        sb.Append(i);
            //        sb.Append("Hello");
            //    }
            //    long t2 = sw.ElapsedMilliseconds;
            //    Console.WriteLine(t2-t1); 
            //    j++;
            //    sw.Restart();
            //}

            MyTest.args = args;
       
            var summary = BenchmarkRunner.Run<MyTest>();




            return;
        }
        [SimpleJob(RunStrategy.Throughput, launchCount: 10)]
        public class MyTest
        {
            public static string[] args;

            [Benchmark]
            public void Test()
            {

                Stopwatch sw = new Stopwatch();
                int count = int.Parse(args == null || args.Length == 0 ? "10000000" : args[0]);
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

            [Benchmark]
            public void TestList()
            {

                Stopwatch sw = new Stopwatch();
                int count = int.Parse(args == null || args.Length == 0 ? "10000000" : args[0]);
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
}
