using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dgw1
{
    public partial class Form1 : Form
    {
        class dg
        {
            public DataGridView name;
            public enum values { integer, floating };
            public void init(int max_column, int max_row, int begin_num = 0, int off_auto_zagolovok = 0)
            {
                name.Rows.Clear();
                name.Columns.Clear();
                int stro = 0;
                if (off_auto_zagolovok == 0) for (int i = begin_num; i <= max_column; i++) name.Columns.Add("Column", i.ToString());
                for (int i = begin_num; i < max_row; i++) name.Rows.Add();
                for (int i = begin_num; i <= max_row; i++) name.Rows[stro++].HeaderCell.Value = i.ToString();
                name.AutoResizeColumns();
            }
            public void rando(values valu = values.integer, int min = 0, int max = 65535)
            {
                Random a = new Random();
                for (int i = 0; i < name.ColumnCount; i++)
                    for (int j = 0; j < name.RowCount; j++)
                        if (valu == values.integer) name.Rows[j].Cells[i].Value = a.Next(min, max);
                        else name.Rows[j].Cells[i].Value = a.NextDouble() * (max - min) + min;
                name.AutoResizeColumns();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        dg a1 = new dg();
        private void button1_Click(object sender, EventArgs e)
        {
            a1.name = dataGridView1;
            a1.init(10, 3, 1);
            a1.rando(dg.values.integer, -10, 10);

        }
    }
}
