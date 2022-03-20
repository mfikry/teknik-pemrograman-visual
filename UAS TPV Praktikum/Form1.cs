using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace UAS_TPV_Praktikum
{
    public partial class Form1 : Form
    {
        OleDbConnection vcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= E:/databaseUASTPV/data.accdb");
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            vcon.Open();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            string vsql = string.Format("insert into databus values('{0}','{1}','{2}','{3}','{4}','{5}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            OleDbCommand vcom = new OleDbCommand(vsql, vcon);
            if (vcon.State == ConnectionState.Closed)
            {
                vcon.Open();
                vcom.ExecuteNonQuery();

            }
            else if (vcon.State == ConnectionState.Open)
            {
                vcom.ExecuteNonQuery();

            }
            //vcom.ExecuteNonQuery();
            MessageBox.Show("Data stored successfully");
            vcom.Dispose();
        }

        private void showallbutton_Click(object sender, EventArgs e)
        {
            string vsql = "select * from QueryBus";

            OleDbCommand vcom = new OleDbCommand(vsql, vcon);
            DataSet vds = new DataSet();
            OleDbDataAdapter vda = new OleDbDataAdapter(vcom);
            vda.Fill(vds, "res");
            dataGridView1.DataSource = vds.Tables["res"];
            vda.Dispose();
            vcom.Dispose();
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            label5.Text = "";
            label9.Text = "";
            label13.Text = "";
            label14.Text = "";
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vsql = string.Format("select * from QueryBus where [Nama Bus] = '{0}'", textBox7.Text);
            OleDbCommand vcom = new OleDbCommand(vsql, vcon);
            DataSet vds = new DataSet();
            OleDbDataAdapter vda = new OleDbDataAdapter(vcom);
            vda.Fill(vds, "res");
            dataGridView1.DataSource = vds.Tables["res"];
            try
            {
                label5.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                label5.Text = "kosong";
            }
            vda.Dispose();
            vcom.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string vsql = string.Format("select * from QueryBus where [Tipe Bus] = '{0}'", textBox8.Text);
            OleDbCommand vcom = new OleDbCommand(vsql, vcon);
            DataSet vds = new DataSet();
            OleDbDataAdapter vda = new OleDbDataAdapter(vcom);
            vda.Fill(vds, "res");
            dataGridView1.DataSource = vds.Tables["res"];
            try
            {
                label9.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                label9.Text = "kosong";
            }
            vda.Dispose();
            vcom.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string vsql = string.Format("select * from QueryBus where Tujuan = '{0}'", textBox10.Text);
            OleDbCommand vcom = new OleDbCommand(vsql, vcon);
            DataSet vds = new DataSet();
            OleDbDataAdapter vda = new OleDbDataAdapter(vcom);
            vda.Fill(vds, "res");
            dataGridView1.DataSource = vds.Tables["res"];
            try
            {
                label13.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                label13.Text = "kosong";
            }
            vda.Dispose();
            vcom.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string vsql = string.Format("select * from QueryBus where [Harga tiket] = {0}", textBox9.Text);
            OleDbCommand vcom = new OleDbCommand(vsql, vcon);
            DataSet vds = new DataSet();
            OleDbDataAdapter vda = new OleDbDataAdapter(vcom);
            vda.Fill(vds, "res");
            dataGridView1.DataSource = vds.Tables["res"];
            try
            {
                label14.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                label14.Text = "kosong";
            }
            vda.Dispose();
            vcom.Dispose();
        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            string vsql = string.Format("UPDATE databus set [Harga Tiket] = '{0}' where [Kode Bus] = '{1}'", textBox5.Text, textBox1.Text);
            OleDbCommand vcom = new OleDbCommand(vsql, vcon);
            if (vcon.State == ConnectionState.Closed)
            {
                vcon.Open();
                vcom.ExecuteNonQuery();

            }
            else if (vcon.State == ConnectionState.Open)
            {
                vcom.ExecuteNonQuery();

            }
            //vcom.ExecuteNonQuery();
            MessageBox.Show("Data Updated successfully");
            vcom.Dispose();
        }
    }
}
