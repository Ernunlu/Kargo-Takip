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

namespace KargoTakipSistemi
{
    public partial class ekle : Form
    {
        SqlConnection baglanti;
        SqlDataAdapter verial;
        DataSet ds = new DataSet();
        SqlCommand komut;
       

        public ekle()
        {
            InitializeComponent();
        }

        private void ekle_Load(object sender, EventArgs e)
        {

            verileriCekekle();

            dataGridView1.ClearSelection();

            Kno.Clear();
            Gadsoyad.Clear();
            Gadres.Clear();
            Gtel.Clear();
            textBox5.Clear();
            textBox6.Clear();
            Atel.Clear();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool a = false;                        //hata 
                bool bosalank = false;
                if (dolubos(Gadres.Text) == true)
                {                                       //kaydederken boş alan kontrolu
                    if (dolubos(Gadsoyad.Text) == true)
                    {
                        if (dolubos(textBox5.Text) == true)
                        {
                            if (dolubos(textBox6.Text) == true)
                            {
                                bosalank = true;
                            }
                         
                        }
                       
                    }
                   
                }
               
                if (kontrol(Gtel.Text) ==  true)              // telefon kontrol
                {
                    if (kontrol(Atel.Text) == true)
                    {
                        if (kontroltel(Atel.Text) == true)
                        {
                            if (kontroltel(Gtel.Text) == true)
                            {
                                a = true;                          
                            }
                        }
                    }
                }
                if (a == true)
                {
                    if (bosalank == true)
                    { 
                    if (kontrol(Kno.Text) == true)
                    {
                        if (aynıkontrol(Kno.Text) == true)             //ekleme
                        {

                            int kargonumarasi = Convert.ToInt32(Kno.Text);
                            string Gadsoyadi = Gadsoyad.Text;
                            string GAdresi = Gadres.Text;
                            string Gtelefono = Gtel.Text;
                            string Aadisoyadi = textBox5.Text;
                            string Aadresi = textBox6.Text;
                            string Atelefon = Atel.Text;




                            baglanti = new SqlConnection("Data Source=PC\\DSADASDASDASD; Initial Catalog=kargotakipsistemi; Integrated Security=true");
                            baglanti.Open();
                            komut = new SqlCommand("insert into kargo values('" + kargonumarasi + "' , '" + Gadsoyadi + "' , '" + GAdresi + "', '" + Gtelefono + "'  , '" + Aadisoyadi + "' , '" + Aadresi + "', '" + Atelefon + "')", baglanti);
                            komut.ExecuteNonQuery();
                            MessageBox.Show("Öğrenci Eklendi");
                            baglanti.Close();
                            Kno.Clear();
                            Gadsoyad.Clear();
                            Gadres.Clear();
                            Gtel.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            Atel.Clear();

                            verileriCekekle();

                            dataGridView1.ClearSelection();

                            Kno.Clear();
                            Gadsoyad.Clear();
                            Gadres.Clear();
                            Gtel.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            Atel.Clear();
                        }
                        else             // güncelleme
                        {
                            int kargonumarasi = Convert.ToInt32(Kno.Text);
                            string Gadsoyadi = Gadsoyad.Text;
                            string GAdresi = Gadres.Text;
                            string Gtelefono = Gtel.Text;
                            string Aadisoyadi = textBox5.Text;
                            string Aadresi = textBox6.Text;
                            string Atelefon = Atel.Text;




                            baglanti = new SqlConnection("Data Source=PC\\DSADASDASDASD; Initial Catalog=kargotakipsistemi; Integrated Security=true");
                            baglanti.Open();
                            komut = new SqlCommand("UPDATE kargo SET KargoNo='" + kargonumarasi + "' , Gadsoyad='" + Gadsoyadi + "' , Gadres='" + GAdresi + "', Gtel='" + Gtelefono + "'  , Aadsoyad='" + Aadisoyadi + "' , Aadres='" + Aadresi + "', Atel='" + Atelefon + "' WHERE KargoNo='" + kargonumarasi + "'", baglanti);
                            komut.ExecuteNonQuery();
                            MessageBox.Show("Ögrenci güncellendi");
                            baglanti.Close();
                            Kno.Clear();
                            Gadsoyad.Clear();
                            Gadres.Clear();
                            Gtel.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            Atel.Clear();

                            verileriCekekle();

                            dataGridView1.ClearSelection();

                            Kno.Clear();
                            Gadsoyad.Clear();
                            Gadres.Clear();
                            Gtel.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            Atel.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kargo Numarası sayılardan oluşmalıdır");
                    }
                }
                    else
                    {
                        MessageBox.Show("Boş alan olamaz");
                    }
                }
                else
                {
                    MessageBox.Show("Eklemek istediginiz Telefon numarası veya verilerde geçersiz birşey var Telefon numaraları 11 sayı'dan oluşmalıdır.");
                }
               }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                baglanti.Close();
            }
        }
    bool aynıkontrol(string text)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (text == dataGridView1.Rows[i].Cells[0].Value.ToString())
                {
                    return false;
                }
             
            }
            return true;
        }

    bool kontrol(string text)
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }

        bool kontroltel(string text)
        {
            int sayac = 0;
            foreach (char chr in text)
            {
                sayac++;
            }
            if (sayac == 11)
                return true;
            else
                return false;
        }

        bool dolubos(string text)
        {
            if (text == "")
            {
                
                return false;
            }
            else {
                return true;
                    }
                    
        }

        private void ekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            ekle ea = new ekle();
            ea.Hide();
            ea.Close();
        }

        private void ekle_FormClosing(object sender, FormClosingEventArgs e)
        {
            ekle ea = new ekle();
            ea.Hide();
            ea.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
             


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void verileriCekekle()
        {
            try
            {
                dataGridView1.ClearSelection();
                baglanti = new SqlConnection("Data Source=PC\\DSADASDASDASD; Initial Catalog=kargotakipsistemi; Integrated Security=true");

                verial = new SqlDataAdapter("Select * from kargo ", baglanti);
                ds.Clear();
                verial.Fill(ds);


                dataGridView1.DataSource = ds.Tables[0];

                dataGridView1.Columns[0].HeaderText = "Kargo No";
                dataGridView1.Columns[1].HeaderText = "Gönderici Ad Soyad";
                dataGridView1.Columns[2].HeaderText = "Gönderici Adres";
                dataGridView1.Columns[3].HeaderText = "Gönderici Telefon";
                dataGridView1.Columns[4].HeaderText = "Alıcı Ad Soyadı";
                dataGridView1.Columns[5].HeaderText = "Alıcı Adres";
                dataGridView1.Columns[6].HeaderText = "Alıcı Telefon";
                dataGridView1.AllowUserToAddRows = false;

                dataGridView1.ClearSelection();

            }
            catch (Exception exc)
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                MessageBox.Show(exc.Message);
            }
        }

        private void t(object sender, HelpEventArgs hlpevent)
        {

        }

        private void dataGridView1_TabIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)          // kopyala
        {

            Kno.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Gadsoyad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Gadres.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Gtel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Atel.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }
    }
}
