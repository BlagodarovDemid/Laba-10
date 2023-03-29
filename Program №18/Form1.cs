using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            label6.Text = ("00:00:000");
            button1.Enabled = false;
            label7.Enabled = false;
            trackBar1.Enabled = false;
            textBox1.Enabled = false;
            button3.Enabled = false;
        }
        DateTime date1 = new DateTime(0,0);
        public int[] mas = {0};
        int[] result;
        int listcount = 0;
        int count = 0;
        bool flag = false;
        static int[] BubbleSort(int[] mas, DateTime date1)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                date1 = date1.AddMilliseconds(1);
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        public static void Swap(int array, int array1)
        {
            array = array1;
            array1 = array;
        }
        static int[] ShellSort(int[] array, DateTime date1)
        {
            //расстояние между элементами, которые сравниваются
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i<array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(array[j], array[j - d]);
                        j = j - d;
                    }
                }
                d = d / 2;
            }
            return array;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label7.Enabled = true;
            trackBar1.Enabled = true;
            button3.Enabled = true;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label7.Enabled = true;
            trackBar1.Enabled = true;
            button3.Enabled = true;
        }
        public void AddItemsListBox(int[] mas,int first = -1, int second = -1)
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
        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = date1.ToString("mm:ss:fff");
            if (radioButton1.Checked)
            {
                result = BubbleSort(mas, date1);
                this.AddItemsListBox(result);
            }
            if (radioButton2.Checked)
            {
                result = ShellSort(mas, date1);
                this.AddItemsListBox(result);
            }
        }
        /*            if (Context.array != null)
                    {
                        if (radioButton1.Checked == true)
                        {
                            this.context = new Context(new BubbleSort());
                            context.ExecuteAlgorithm();
                            this.AddItemsListBox();
                            IOFile.SaveData();
                            buttonSort.Enabled = false;
                        }
                        if (radioButton2.Checked == true)
                        {
                            this.context = new Context(new ShellSort());
                            context.ExecuteAlgorithm();
                            this.AddItemsListBox();
                            IOFile.SaveData();
                            buttonSort.Enabled = false;
                        }
                            IOFile.content = "";
                    }
                    else
                    {
                        MessageBox.Show("Массив пуст, сортировка невозможна");
                    }*/
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            mas = Generate(count);
            button1.Enabled = true;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            count = trackBar1.Value;
            textBox1.Text = trackBar1.Value.ToString();
        }
    }
}
