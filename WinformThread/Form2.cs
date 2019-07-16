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
    public partial class Form2 : Form
    {
        public Form2()
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

        void WriteStr(int k)
        {
            this.BeginInvoke(updateTxt, " 子线程 读数" + k.ToString() + " 线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }

        //此为在非创建线程中的调用方法，其实是使用TextBox的Invoke方法。
        void ThreadMethodTxt(int n)
        {
            this.BeginInvoke(updateTxt, " 子线程 开始 线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());

            for (int k = 1; k <= n; k++)
            {
                Thread.Sleep(1000);
                WriteStr(k);
            };

            this.BeginInvoke(updateTxt, " 子线程 结束 线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
        //开启线程
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            UpdateTxtMethod("主线程 开始 " + "线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());

            //ThreadMethodTxt(Convert.ToInt32(textBox1.Text.Trim()));

            Task.Run(() => { ThreadMethodTxt(Convert.ToInt32(textBox1.Text.Trim())); });

            UpdateTxtMethod("主线程 结束 " + "线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            updateTxt = new UpdateTxt(UpdateTxtMethod);
        }
    }
}
