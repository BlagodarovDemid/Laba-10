using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program__18
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static int count;
        public static int comprasin;
        public static int NumberOfPermutations;
        public static string elapsedTime;
        public void Row(string ColumnName,int count,int comprasin, int NumberOfPermutations,string elapsedTime)
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Метод","");
                dataGridView1.Columns.Add("Объём выборки","");
                dataGridView1.Columns.Add("Данные","");
            }
            if (ColumnName == "Bubble")
            {
                dataGridView1.Rows.Add("Bubble",count, "С: " + comprasin.ToString() + " П: " + NumberOfPermutations.ToString() + " t: " + elapsedTime);
            }
            if (ColumnName == "Shell")
            {
                dataGridView1.Rows.Add("Shell", count, "С: " + comprasin.ToString() + " П: " + NumberOfPermutations.ToString() + " t: " + elapsedTime);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}