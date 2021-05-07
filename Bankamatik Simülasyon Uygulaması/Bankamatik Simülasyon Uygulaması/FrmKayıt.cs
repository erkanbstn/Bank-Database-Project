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

namespace Bankamatik_Simülasyon_Uygulaması
{
    public partial class FrmKayıt : Form
    {
        public FrmKayıt()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DBBankamatik;Integrated Security=True");        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox2.Text == "")
                {
                    MessageBox.Show("Hesap Numarası Kısmını Doldurmanız Gerekmektedir", "Banka Kayıt Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    SqlCommand s = new SqlCommand("insert into Kişiler (Ad,Soyad,Tc,Telefon,Hesap,Şifre) values (@p1,@p2,@p3,@p4,@p5,@p6)", con);
                    s.Parameters.AddWithValue("@p1", textBox1.Text);
                    s.Parameters.AddWithValue("@p2", textBox2.Text);
                    s.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
                    s.Parameters.AddWithValue("@p4", maskedTextBox3.Text);
                    s.Parameters.AddWithValue("@p5", maskedTextBox2.Text);
                    s.Parameters.AddWithValue("@p6", textBox3.Text);
                    s.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kayıt Başarılı", "Banka Kayıt Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Hatası Lütfen Kontrol Edin", "Banka Kayıt Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            int sayı = rd.Next(100000,1000000);
            maskedTextBox2.Text = sayı.ToString();
        }
    }
}
