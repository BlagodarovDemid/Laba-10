using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program__18
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            trackBar1.Value = 0;
        }
        int count = 0;
        public int[] array = {1, 65, 23, 61, 5, 7, 10, 0};

        private void label1_Click(object sender, EventArgs e)
        {
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Font = new Font(label1.Font, label1.Font.Style | FontStyle.Bold);
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
            Form1 form1 = new Form1();
            //array = Generate(count);

            array = new int[count];
            int seed = unchecked(DateTime.Now.Ticks.GetHashCode());
            Random rand = new Random(seed);
            for (int i = 0; i < count; i++)
            {
                array[i] = rand.Next(0, 999);
            }
            
            //form1.mas = array;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            count = Convert.ToInt32(textBox1.Text);
            trackBar1.Value = Convert.ToInt32(textBox1.Text);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            count = trackBar1.Value;
            textBox1.Text = Convert.ToString(trackBar1.Value);
        }
    }
}
