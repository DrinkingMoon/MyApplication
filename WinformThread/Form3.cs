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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        void UpdateTxtMethod(string msg)
        {
            richTextBox1.AppendText(msg + "\r\n");
            richTextBox1.ScrollToCaret();
        }

        async void Thread1(int n)
        {
            await Task.Run(() =>
            {
                for (int i = 1; i <= n; i++)
                {
                    Thread.Sleep(1000);
                    BeginInvoke(new Action<string>(msg =>
                    {
                        richTextBox1.AppendText(msg + "\r\n");
                        richTextBox1.ScrollToCaret();
                    }), "读数 " + i.ToString() + " 线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
                }
            });

        }

        async void Thread2(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                await Task.Delay(1000);
                UpdateTxtMethod("读数 " + i.ToString() + " 线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }
        }

        async void Thread3(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Thread.Sleep(1000);
                UpdateTxtMethod("读数 " + i.ToString() + " 线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }
        }

        void Thread4(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Thread.Sleep(1000);
                BeginInvoke(new Action<string>(msg =>
                {
                    richTextBox1.AppendText(msg + "\r\n");
                    richTextBox1.ScrollToCaret();
                }), "读数 " + i.ToString() + " 线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            UpdateTxtMethod("主线程 开始 " + "线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
            Thread1(Convert.ToInt32(textBox1.Text.ToString()));
            UpdateTxtMethod("主线程 结束 " + "线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            UpdateTxtMethod("主线程 开始 " + "线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
            Thread2(Convert.ToInt32(textBox1.Text.ToString()));
            UpdateTxtMethod("主线程 结束 " + "线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            UpdateTxtMethod("主线程 开始 " + "线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
            Thread3(Convert.ToInt32(textBox1.Text.ToString()));
            UpdateTxtMethod("主线程 结束 " + "线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            UpdateTxtMethod("主线程 开始 " + "线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());

            ThreadPool.QueueUserWorkItem((WaitCallback)delegate
            {
                Thread4(Convert.ToInt32(textBox1.Text.ToString()));
            });

            UpdateTxtMethod("主线程 结束 " + "线程ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
}
