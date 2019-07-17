using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformThread
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //创建一个委托，是为访问TextBox控件服务的。
        public delegate void UpdateTxt(string msg);
        //定义一个委托变量
        public UpdateTxt updateTxt;

        //修改TextBox值的方法。
        public void UpdateTxtMethod(string msg)
        {
            richTextBox1.AppendText(msg + "\r\n");
            richTextBox1.ScrollToCaret();
        }

        //此为在非创建线程中的调用方法，其实是使用TextBox的Invoke方法。
        public void ThreadMethodTxt(int n)
        {
            this.BeginInvoke(new Action<string>(msg=>
            {
                richTextBox1.AppendText( msg + "\r\n");
                richTextBox1.ScrollToCaret();
            }), "子线程 开始 线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());

            for (int i = 1; i <= n; i++)
            {   
                //一秒 执行一次
                Thread.Sleep(1000);
                this.BeginInvoke(updateTxt, "子线程 读数"+ i.ToString() +" 线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }

            this.BeginInvoke(new UpdateTxt(msg =>
            {
                richTextBox1.AppendText(msg + "\r\n");
                richTextBox1.ScrollToCaret();
            }), "子线程 结束 线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());

        }
        //开启线程
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            UpdateTxtMethod("主线程 开始 " + " 线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());

            for (int i = 0; i < 3; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(s =>
                {
                    ThreadMethodTxt(Convert.ToInt32(textBox1.Text.Trim()));
                }), null);
            }

            UpdateTxtMethod("主线程 结束 " + " 线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //实例化委托
            updateTxt = new UpdateTxt(UpdateTxtMethod);
        }
    }
}
