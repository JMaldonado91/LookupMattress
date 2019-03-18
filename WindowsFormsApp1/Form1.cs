using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;
using Dapper;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<mattress> mattress_lookup = new List<mattress>();

        string cs = "Data Source=mattress.db;Version=3;";
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapt;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();

        }

        private void LoadMattressList()
        {
            mattress_lookup = DataAccess.LoadMattress();

            WiredUpMattressList();
        }

        private void WiredUpMattressList()
        {
            MattressLookupdataGridView1.DataSource = null;
            MattressLookupdataGridView1.DataSource = mattress_lookup;

        }


        //Text Boxes for Form, user will select one box to search data

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            con = new SQLiteConnection(cs);
            con.Open();
            adapt = new SQLiteDataAdapter("select * from mattress_lookup where mattress LIKE '" + NameTextBox.Text + "%'",con);
            dt = new DataTable();
            adapt.Fill(dt); 
            MattressLookupdataGridView1.DataSource = dt;
            con.Close();
        }

        private void FeelTextBox_TextChanged(object sender, EventArgs e)
        {
            con = new SQLiteConnection(cs);
            con.Open();
            adapt = new SQLiteDataAdapter("select * from mattress_lookup where feel LIKE '" + FeelTextBox.Text + "%'", con);
            dt = new DataTable();
            adapt.Fill(dt);
            MattressLookupdataGridView1.DataSource = dt;
            con.Close();
        }

        private void ProfileTextBox_TextChanged(object sender, EventArgs e)
        {
            con = new SQLiteConnection(cs);
            con.Open();
            adapt = new SQLiteDataAdapter("select * from mattress_lookup where profile LIKE '" + ProfileTextBox.Text + "%'", con);
            dt = new DataTable();
            adapt.Fill(dt);
            MattressLookupdataGridView1.DataSource = dt;
            con.Close();
        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {
            con = new SQLiteConnection(cs);
            con.Open();
            adapt = new SQLiteDataAdapter("select * from mattress_lookup where year LIKE '" + YearTextBox.Text + "%'", con);
            dt = new DataTable();
            adapt.Fill(dt);
            MattressLookupdataGridView1.DataSource = dt;
            con.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //When user wants to close form, they will click on Close
            this.Close();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //When user wants to reset form, they will click on Reset

            NameTextBox.Clear();
            FeelTextBox.Clear();
            YearTextBox.Clear();
            ProfileTextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert button will create new row of data
            mattress m = new mattress();

            m.Mattress = NameTextBox.Text;
            m.feel = FeelTextBox.Text;
            m.year = YearTextBox.Text;
            m.profile = ProfileTextBox.Text;

            DataAccess.InsertMattress(m);

            NameTextBox.Text = "";
            FeelTextBox.Text = "";
            YearTextBox.Text = "";
            ProfileTextBox.Text = "";

            MessageBox.Show("Record inserted successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //refresh button will load data table
            LoadMattressList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SQLiteConnection(cs);
            con.Open();
            adapt = new SQLiteDataAdapter("select * from mattress_lookup", con);
            dt = new DataTable();
            adapt.Fill(dt);
            MattressLookupdataGridView1.DataSource = dt;
            con.Close();
        }

    }
}



    


