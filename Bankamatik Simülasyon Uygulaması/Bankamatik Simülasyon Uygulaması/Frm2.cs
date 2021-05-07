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
    public partial class Frm2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DBBankamatik;Integrated Security=True");
        public Frm2()
        {
            InitializeComponent();
        }
        public string ad;
        public string hesap;
        public string tc;
        public string tel;
        FrmHareket f = new FrmHareket();
        int sayac = 0;
        private void Frm2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label5.Text = ad;
            label8.Text = hesap;
            label7.Text = tc;
            label6.Text = tel;
            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Para Artışı
            try
            {
                if (maskedTextBox1.Text == "")
                {
                    MessageBox.Show("Hesap No Alanı Doldurulmak Zorundadır", "Banka Bakiye Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    SqlCommand s = new SqlCommand("update Hesap set Bakiye=Bakiye+@p1 where Hesap=@p2", con);
                    s.Parameters.AddWithValue("@p1", decimal.Parse(textBox1.Text));
                    s.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
                    s.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("İşlem Başarıyla Gerçekleşti", "Banka Bakiye Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
            catch (Exception)
            {


            }
            // Para Azalışı
            try
            {
                if (maskedTextBox1.Text == "")
                {
                    MessageBox.Show("Hesap No Alanı Doldurulmak Zorundadır", "Banka Bakiye Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    SqlCommand s = new SqlCommand("update Hesap set Bakiye=Bakiye-@p1 where Hesap=@p2", con);
                    s.Parameters.AddWithValue("@p1", decimal.Parse(textBox1.Text));
                    s.Parameters.AddWithValue("@p2", hesap);
                    s.ExecuteNonQuery();
                    con.Close();
                   
                }

            }
            catch (Exception)
            {

             
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            f.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            if (sayac == 4)
            {
                FrmHareket f = new FrmHareket();
                f.gönder = label8.Text;
            }
            
        }
    }
}
