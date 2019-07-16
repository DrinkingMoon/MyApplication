using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleThread
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("主线程测试开始..");
        //    Thread th = new Thread(ThMethod);
        //    th.Start();
        //    Thread.Sleep(1000);
        //    Console.WriteLine("主线程测试结束..");
        //    Console.ReadLine();
        //}
        //static void ThMethod()
        //{
        //    Console.WriteLine("异步执行开始");
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine("异步执行" + i.ToString() + "..");
        //        Thread.Sleep(1000);
        //    }
        //    Console.WriteLine("异步执行完成");
        //}


        //static void Main(string[] args)
        //{
        //    Console.WriteLine("主线程测试开始.." + Thread.CurrentThread.ManagedThreadId.ToString());
        //    for (int i = 0; i < 3; i++)
        //    {
        //        MyMethod();
        //    }
        //    Thread.Sleep(1000);
        //    Console.WriteLine("主线程测试结束.." + Thread.CurrentThread.ManagedThreadId.ToString());
        //    Console.ReadLine();
        //}
        //static async void AsyncMethod()
        //{
        //    Console.WriteLine("开始异步代码" + Thread.CurrentThread.ManagedThreadId.ToString());
        //    await MyMethod();
        //    Console.WriteLine("异步代码执行完毕" + Thread.CurrentThread.ManagedThreadId.ToString());
        //}
        //static async Task MyMethod()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine("异步执行" + i.ToString() + ".." + Thread.CurrentThread.ManagedThreadId.ToString());
        //        await Task.Delay(1000); //模拟耗时操作
        //    }
        //}



        static void Main(string[] args)
        {
            Console.WriteLine("我是主线程，线程ID：" + Thread.CurrentThread.ManagedThreadId);
            //task用法一  
            Task task1 = new Task(() => MyAction());
            task1.Start();

            //task用法二  
            var strRes = Task.Run<string>(() => { return GetReturnStr(); });
            Console.WriteLine(strRes.Result);

            //task->async异步方法和await，主线程碰到await时会立即返回，继续以非阻塞形式执行主线程下面的逻辑  
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("①我是主线程，开始 线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            var testResult = TestAsync();
            Console.WriteLine("①我是主线程，结束 线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("--------------------------------------------");
            Console.ReadKey();
        }

        static async Task TestAsync()
        {

            Console.WriteLine("②调用GetReturnResult()之前，线程ID：{0}。当前时间：{1}", 
                Thread.CurrentThread.ManagedThreadId,
                DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));

            var name = GetReturnResult1();
            var name2 = GetReturnResult2();

            Console.WriteLine("④调用GetReturnResult()之后，线程ID：{0}。当前时间：{1}", 
                Thread.CurrentThread.ManagedThreadId,
                DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));

            Console.WriteLine("⑥得到GetReturnResult()1：{0}。当前时间：{1}",
                await name,
                DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));

            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");

            Console.WriteLine("⑥得到GetReturnResult()2：{0}。当前时间：{1}",
                name2.GetAwaiter().GetResult(),
                DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
        }

        static async Task<string> GetReturnResult1()
        {
            Console.WriteLine("③执行Task.Run之前, 线程ID：{0}", Thread.CurrentThread.ManagedThreadId);

            string str = await Task.Run(() =>
             {
                 Thread.Sleep(5000);
                 Console.WriteLine("⑤GetReturnResult1()方法里面线程ID: {0}", Thread.CurrentThread.ManagedThreadId);
                 return "我是返回值Name1";
             });

            Console.WriteLine("*******************************************");
            return str;
        }

        static async Task<string> GetReturnResult2()
        {
            Console.WriteLine("③执行Task.Run之前, 线程ID：{0}", Thread.CurrentThread.ManagedThreadId);

            await Task.Delay(1000);
            string str = "我是返回值Name2";
            Console.WriteLine("⑤GetReturnResult2()方法里面线程ID: {0}", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("*******************************************");
            return str;
        }

        static void MyAction()
        {
            Console.WriteLine("我是新进程，线程ID：() MyAction " + Thread.CurrentThread.ManagedThreadId);
        }

        static string GetReturnStr()
        {
            return "我是返回值 ，GetReturnStr 线程ID：" + Thread.CurrentThread.ManagedThreadId;
        }
    }
}
