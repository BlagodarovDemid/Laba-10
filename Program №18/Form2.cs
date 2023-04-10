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
        string ColumnName;
        public static int count;
        public static int comprasin;
        public static int NumberOfPermutations;
        public static string elapsedTime;
        public void Row(string ColumnName,int count,int comprasin, int NumberOfPermutations,string elapsedTime)
        {
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
    }
}
