using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Program__18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label6.Text = ("00:00:00:000");
            button1.Enabled = false;
            label7.Enabled = false;
            trackBar1.Enabled = false;
            textBox1.Enabled = false;
            button3.Enabled = false;
        }
        public static Form1 form1;
        public static Form2 form2 = new Form2();
        public string path;
        public string file = "";
        public int[] mas;
        public int listcount = 0;
        int count = 0;
        public static int iterationCount = 0;
        public static int comprasin = 0;
        public static int NumberOfPermutations = 0;
        public static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
        public int[] Generate(int count)
        {
            int[] array = new int[count];
            int seed = unchecked(DateTime.Now.Ticks.GetHashCode());
            Random rand = new Random(seed);
            for (int i = 0; i < count; i++)
            {
                array[i] = rand.Next(0, 999);
            }
            return array;
        }
        public void AddItemsListBox(int[] mas, int first = -1, int second = -1)
        {
            listBox1.Items.Add("");
            foreach (var item in mas)
            {
                if (item == first || item == second)
                {
                    listBox1.Items[listcount] += '[' + Convert.ToString(item) + ']' + " ";
                }
                else
                {
                    listBox1.Items[listcount] += Convert.ToString(item) + " ";
                }
            }

            listcount++;
        }
        public class Bubble
        {
            public static Form1 form1;
            public static SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            public static StreamWriter sw;
            public int[] BubbleSort(int[] mas)
            {
                sw = new StreamWriter(new FileStream("BubbleSort.txt", FileMode.Create, FileAccess.Write));

                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                int temp;
                for (int i = 0; i < mas.Length; i++)
                {
                    sw.Write(mas[i] + " ");
                }
                for (int i = 0; i < mas.Length; i++)
                {
                    for (int j = i + 1; j < mas.Length; j++)
                    {
                        iterationCount++;
                        comprasin++;
                        sw.Write("\t\n{0} Итерация:",iterationCount);
                        sw.Write("\t\nСравниваем {0} и {1}", mas[i], mas[j]);
                        if (mas[i] > mas[j])
                        {
                            sw.Write("\t\nПерестановка {0} и {1}", mas[i], mas[j]);
                            temp = mas[i];
                            mas[i] = mas[j];
                            mas[j] = temp;
                            NumberOfPermutations++;
                            form1.AddItemsListBox(mas, mas[i], mas[j]);
                            sw.Write("\t\n");
                            for (int v = 0; v < mas.Length; v++)
                            {
                                sw.Write(mas[v] + " ");
                            }
                        }
                    }
                }
                sw.Close();
                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed;
                string elapsedTime =
                String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);
                form1.label6.Text = elapsedTime.ToString();
                form2.Row("Bubble", form1.count, comprasin, NumberOfPermutations, elapsedTime.ToString());
                return mas;
            }
        }
        public class Shell
        {
            public static Form1 form1;
            public static SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            public static StreamWriter sw;
            public int[] ShellSort(int[] array)
            {
                sw = new StreamWriter(new FileStream("ShellSort.txt", FileMode.Create, FileAccess.Write));

                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                var d = array.Length / 2;
                for (int i = 0; i < array.Length; i++)
                {
                    sw.Write(array[i] + " ");
                }
                while (d >= 1)
                {
                    for (var i = d; i < array.Length; i++)
                    {
                        var j = i;
                        iterationCount++;
                        comprasin++;
                        sw.Write("\t\n{0} Итерация:", iterationCount);
                        while ((j >= d) && (array[j - d] > array[j]))
                        {
                            sw.Write("\t\nПерестановка {0} и {1}", array[j], array[j - d]);
                            Swap(ref array[j], ref array[j - d]);
                            j = j - d;
                            NumberOfPermutations++;
                            form1.AddItemsListBox(array);
                        }
                        sw.Write("\t\n");
                        for (int v = 0; v < array.Length; v++)
                        {
                            sw.Write(array[v] + " ");
                        }
                    }
                    d = d / 2;
                }
                sw.Close();
                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed;
                string elapsedTime =
                String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);
                form1.label6.Text = elapsedTime.ToString();
                form2.Row("Shell", form1.count, comprasin, NumberOfPermutations, elapsedTime.ToString());
                return array;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            count = trackBar1.Value;
            textBox1.Text = trackBar1.Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Bubble bubble = new Bubble();
                AddItemsListBox(mas);

                bubble.BubbleSort(mas);

                label2.Text = comprasin.ToString();
                label4.Text = NumberOfPermutations.ToString();
                iterationCount = 0;
                comprasin = 0;
                NumberOfPermutations = 0;
                button1.Enabled = false;
            }
            if (radioButton2.Checked)
            {
                Shell shell = new Shell();
                AddItemsListBox(mas);

                shell.ShellSort(mas);

                label2.Text = comprasin.ToString();
                label4.Text = NumberOfPermutations.ToString();
                iterationCount = 0;
                comprasin = 0;
                NumberOfPermutations = 0;
                button1.Enabled = false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            mas = Generate(count);
            button1.Enabled = true;
            listBox1.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Array.Clear(mas, 0, mas.Length);
            listcount = 0;
            listBox1.Items.Clear();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            file = "BubbleSort.txt";
            button1.Enabled = true;
            label7.Enabled = true;
            trackBar1.Enabled = true;
            button3.Enabled = true;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            file = "ShellSort.txt";
            button1.Enabled = true;
            label7.Enabled = true;
            trackBar1.Enabled = true;
            button3.Enabled = true;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        public class OpenFile
        {
            public static Form1 form1;
            public static OpenFileDialog openFileDialog1 = new OpenFileDialog();
            public int[] Open()
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return form1.mas;
                }
                form1.path = openFileDialog1.FileName;
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default))
                {
                    try
                    {
                        string str = sr.ReadToEnd();
                        form1.mas = str.Split(' ').Select(i => Convert.ToInt32(i)).ToArray();
                        form1.listBox1.Items[0] += "\tИсходный массив\n [";
                        form1.AddItemsListBox(form1.mas);
                        form1.listBox1.Items[0] += "]\n";
                        form1.button1.Enabled = true;
                    }
                    catch { MessageBox.Show("Ошибка"); }
                }
                return form1.mas;
            }
        }
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listcount = 0;
            OpenFile openFile = new OpenFile();
            openFile.Open();
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.ShowDialog();
            string sourcePath = @"";
            string sourceFile = Path.Combine(sourcePath,file);
            string destFile = saveFileDialog.FileName;
            File.Copy(sourceFile, destFile, true);         
        }
        private void анализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Bubble.form1 = this;
            Shell.form1 = this;
            OpenFile.form1 = this;
        }
    }
}
