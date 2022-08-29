using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hareket_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-K0C08G8;Initial Catalog=Hareket;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Execute Proje6",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;

            //ÜRÜN ALANI
            SqlCommand komut1 = new SqlCommand("Select * from Tbl_URUNLER", baglanti);
            SqlDataAdapter da1 = new SqlDataAdapter(komut1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = dt1;

            //MÜŞTERİ ALANI
            SqlCommand komut2 = new SqlCommand("Select * from Tbl_MUSTERILER", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            comboBox2.ValueMember = "ID";
            comboBox2.DisplayMember = "ADSOYAD";
            comboBox2.DataSource = dt2;

            //PERSONEL ALANI
            SqlCommand komut3 = new SqlCommand("Select * from PERSONEL", baglanti);
            SqlDataAdapter da3 = new SqlDataAdapter(komut3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            comboBox4.ValueMember = "ID";
            comboBox4.DisplayMember = "AD";
            comboBox4.DataSource = dt3;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into HAREKETLER(URUN,MUSTERI,PERSONEL,FIYAT) VALUES (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1",comboBox3.SelectedValue ?? DBNull.Value);
            komut.Parameters.AddWithValue("@p2",comboBox5.SelectedValue ?? DBNull.Value);
            komut.Parameters.AddWithValue("@p3",comboBox4.SelectedValue ?? DBNull.Value);
            komut.Parameters.AddWithValue("@p4",textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni Satış Eklendi. Tebrikler.");
        }
    }
}
