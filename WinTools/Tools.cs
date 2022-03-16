using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WinTools
{
    public partial class Tools : Form
    {
        public Tools()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcuteDosCommand("notepad");
        }

        private void ExcuteDosCommand(string cmd)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                //p.OutputDataReceived += new DataReceivedEventHandler(sortProcess_OutputDataReceived);
                p.Start();
                StreamWriter cmdWriter = p.StandardInput;
                p.BeginOutputReadLine();
                if (!String.IsNullOrEmpty(cmd))
                {
                    cmdWriter.WriteLine(cmd);
                }
                cmdWriter.Close();
                p.WaitForExit();
                p.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("执行命令失败，请检查输入的命令是否正确！");
            }
        }

        private void sortProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                /*this.BeginInvoke(new Action(() => { this.listBox1.Items.Add(e.Data); }));*/
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExcuteDosCommand("calc");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExcuteDosCommand("dir|clip");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExcuteDosCommand("mspaint");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ExcuteDosCommand("control");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExcuteDosCommand("services.msc");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ExcuteDosCommand("regedit");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Text.Trim() == "" || numericUpDown1.Text == "0")
            {
                if (MessageBox.Show("确定直接关机？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ExcuteDosCommand("shutdown.exe -s -t 0");
                }
                else
                {
                    //取消按钮的方法，不做任何处理
                }
            }
            else
            {
                int time_min = int.Parse(numericUpDown1.Text.ToString());
                int time_s = time_min * 60;
                ExcuteDosCommand("shutdown.exe -s -t " + time_s);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ExcuteDosCommand("shutdown.exe -a");
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            ExcuteDosCommand("winver");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ExcuteDosCommand("magnify");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ExcuteDosCommand("dxdiag");
        }
    }
}
