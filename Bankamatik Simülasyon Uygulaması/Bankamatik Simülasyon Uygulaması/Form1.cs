using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.
    Data.SqlClient;

namespace Bankamatik_Simülasyon_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DBBankamatik;Integrated Security=True");
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmKayıt f = new FrmKayıt();
                f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand d = new SqlCommand("Select Ad,Soyad,Tc,Telefon,Hesap,Şifre from Kişiler where Hesap=@p1 and Şifre=@p2",con);
            d.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            d.Parameters.AddWithValue("@p2",textBox2.Text);
            SqlDataReader dr = d.ExecuteReader();           
            if (dr.Read())
            {

                
                Frm2 f = new Frm2();
                f.ad = dr[0].ToString() + " " + dr[1].ToString();
                f.hesap = dr[4].ToString();
                f.tc = dr[2].ToString();
                f.tel = dr[3].ToString();
                f.Show();
            
            }
            else
            {
                MessageBox.Show("Kullanıcı Bilgilerinde Hata", "Banka Giriş Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            FrmHareket w = new FrmHareket();
            w.gönder = maskedTextBox1.Text;
        }
    }
}
