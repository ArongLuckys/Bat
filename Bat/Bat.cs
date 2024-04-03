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
using Arong_Core;
using System.Threading;

namespace Main
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			this.Size = new Size(590,700);
			

        }

		//生成
		private void button1_Click(object sender, EventArgs e)
		{
			//创建文件夹
			Directory.CreateDirectory(textBox2.Text + "\\_Bat");
			if (textBox1.Text != "")
			{
				for (int i = 0; i < listBox1.Items.Count; i++)
				{
					Directory.Move(textBox2.Text + "\\" + listBox1.Items[i].ToString(), textBox2.Text + "\\_Bat\\" + listBox2.Items[i].ToString());
				}

				//暂缓1秒以免文件不存在
				Thread.Sleep(1000);

				for (int i = 0; i < listBox1.Items.Count; i++)
				{
					Directory.Move(textBox2.Text + "\\_Bat\\" + listBox2.Items[i].ToString() ,textBox2.Text + "\\" + listBox2.Items[i].ToString());
				}
				Directory.Delete(textBox2.Text + "\\_Bat");
			}
			else
			{
				MessageBox.Show("没有输入要替换的字符");
			}
			MessageBox.Show("完成");
		}

		//主循环
		private void Form1_Load(object sender, EventArgs e)
		{
            Form1_Resize(null, e);
        }

		//文件夹路径
		private void textBox2_TextChanged(object sender, EventArgs e)
		{
            if (textBox2.Text != "")
            {
                listBox1.Items.Clear();
                DirectoryInfo dir = new DirectoryInfo(textBox2.Text);
                if (dir.Exists == true)
                {
                    FileInfo[] f = dir.GetFiles();
                    for (int i = 0; i < f.Length; i++)
                    {
                        listBox1.Items.Add(f[i].ToString());
                    }
                }
            }
            else
            {
                listBox1.Items.Clear();
            }
		}

		//显示替换的字符
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
             
		}

		//预览
		private void button2_Click(object sender, EventArgs e)
		{
			if (textBox1.Text != "")
			{
				listBox2.Items.Clear();
				for (int i = 0; i < listBox1.Items.Count; i++)
				{
					string temp = listBox1.Items[i].ToString().Replace(textBox1.Text, textBox3.Text);
					listBox2.Items.Add(temp);
				}
			}
			else
			{
				MessageBox.Show("没有输入要替换的字符");
			}
		}

        //窗口发生改变时
        private void Form1_Resize(object sender, EventArgs e)
        {
            Size List1 = new Size(groupBox2.Width / 2 - 3, listBox1.Height);
            Size List2 = new Size(groupBox2.Width / 2 - 3, listBox2.Height);
            listBox1.Size = List1;
            listBox2.Size = List2;
        }

        /// <summary>
        /// 按下esc退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		/// <summary>
		/// 获得文件夹下面全部文件名称
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (Directory.Exists(textBox4.Text))
			{
                string[] files = Directory.GetFiles(textBox4.Text);
				for (int i = 0; i < files.Length; i++)
				{
					files[i] = files[i].Replace(textBox4.Text + "\\","");
					richTextBox1.Text = richTextBox1.Text += files[i] + "\n";
				}
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            if (File.Exists(textBox5.Text))
            {
                string[] files = File.ReadAllLines(textBox5.Text);
                for (int i = 0; i < files.Length; i++)
                {
                    //files[i] = files[i].Replace(textBox4.Text + "\\", "");
                    richTextBox2.Text = richTextBox2.Text += files[i] + "\n";
                }
            }
        }
    }
}
