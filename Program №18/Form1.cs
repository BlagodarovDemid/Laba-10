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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Program__18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label6.Text = ("00:00:00:000");
        }
        DateTime date1 = new DateTime(0,0);
        int[] mas = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] result;
        int count = 0;
        bool flag = false;
        static int[] BubbleSort(int[] mas, DateTime date1, bool flag)
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
            flag = true;
            return mas;
        }
        public static void Swap(int array, int array1)
        {
            array = array1;
            array1 = array;
        }
        static int[] ShellSort(int[] array)
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

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void AddItemsListBox(int first = -1, int second = -1)
        {
            listBox1.Items.Add("");
            foreach (var item in mas)
            {
                if (item == first || item == second)
                {
                    listBox1.Items[count] += '[' + Convert.ToString(item) + ']' + " ";
                }
                else
                {
                    listBox1.Items[count] += Convert.ToString(item) + " ";
                }
            }
            count++;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                result = BubbleSort(mas, date1, flag);
                this.AddItemsListBox();
                listBox1.Text += Convert.ToString(result) + "\n";
                //label6.Text = date1.ToString("hh:mm:ss:fff");
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
    }
}
