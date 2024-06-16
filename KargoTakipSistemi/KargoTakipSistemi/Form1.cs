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



namespace KargoTakipSistemi                                  //Eren Ünlü 16220049
{
    public partial class Form1 : Form
    {
        ekle ek = new ekle();
        guncelle guncel = new guncelle();
        sil sil = new sil();
        SqlConnection baglanti;
        SqlDataAdapter verial;
        DataSet ds = new DataSet();
        SqlCommand komut;
        
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            verileriCek();
            timer1.Interval = 30000;
            timer1.Start();
        }

        private void knoSorgula_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ek.ShowDialog();
            }
            catch
            {
                ekle ekleww = (ekle)Application.OpenForms["ekle"];
                ekleww.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            guncel.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //sil
            try
            {
                verileriCek();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (kontrol(knoSorgula.Text) == true)
                {
                    baglanti = new SqlConnection("Data Source=PC\\DSADASDASDASD; Initial Catalog=kargotakipsistemi; Integrated Security=true");
                    baglanti.Open();
                    String sql = "SELECT * FROM kargo WHERE KargoNo LIKE '" + knoSorgula.Text + "%'";
                    
                    SqlDataAdapter da = new SqlDataAdapter(sql, baglanti);

                    ds.Clear();

                    da.Fill(ds);
                   
                    sorgulaGrid.DataSource = ds.Tables[0];

                    baglanti.Close();
                }
                else
                    MessageBox.Show("Buraya sayı değeri girilmeli");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
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

        private void sorgulaGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
               

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void verileriCek()
        {
            try
            {
                
                baglanti = new SqlConnection("Data Source=PC\\DSADASDASDASD; Initial Catalog=kargotakipsistemi; Integrated Security=true");

                verial = new SqlDataAdapter("Select * from kargo ", baglanti);
                ds.Clear();
                verial.Fill(ds);


                sorgulaGrid.DataSource = ds.Tables[0];
             
                sorgulaGrid.Columns[0].HeaderText = "Kargo No";
                sorgulaGrid.Columns[1].HeaderText = "Gönderici Ad Soyad";
                sorgulaGrid.Columns[2].HeaderText = "Gönderici Adres";
                sorgulaGrid.Columns[3].HeaderText = "Gönderici Telefon";
                sorgulaGrid.Columns[4].HeaderText = "Alıcı Ad Soyadı";
                sorgulaGrid.Columns[5].HeaderText = "Alıcı Adres";
                sorgulaGrid.Columns[6].HeaderText = "Alıcı Telefon";
                DataGridViewColumn uzunluk0 = sorgulaGrid.Columns[0];
                uzunluk0.Width = 75;
                DataGridViewColumn uzunluk1 = sorgulaGrid.Columns[1];
                uzunluk1.Width = 125;
                DataGridViewColumn uzunluk2 = sorgulaGrid.Columns[2];
                uzunluk2.Width = 157;
                DataGridViewColumn uzunluk3 = sorgulaGrid.Columns[3];
                uzunluk3.Width = 115;
                DataGridViewColumn uzunluk4 = sorgulaGrid.Columns[4];
                uzunluk4.Width = 125;
                DataGridViewColumn uzunluk5 = sorgulaGrid.Columns[5];
                uzunluk5.Width = 157;
                DataGridViewColumn uzunluk6 = sorgulaGrid.Columns[6];
                uzunluk1.Width = 130;
                bosil();

            }
            catch (Exception exc)
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                MessageBox.Show(exc.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
             try
            {


                baglanti.Open();


                string deger = knoSorgula.Text;


                SqlDataAdapter komut = new SqlDataAdapter("DELETE FROM kargo WHERE KargoNo = '" + deger + "'", baglanti);
                


                var sonuc = MessageBox.Show("Silmek istiyor musunuz?", "Silme onayı", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {

                    ds.Clear();

                    komut.Fill(ds);
                }
               
               

                baglanti.Close();
                verileriCek();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();


            //var secili = sorgulaGrid.SelectedRows;

            string deger = sorgulaGrid.CurrentRow.Cells[0].Value.ToString();

            SqlDataAdapter komut = new SqlDataAdapter("DELETE FROM kargo WHERE KargoNo = '" + deger + "'", baglanti);



            var sonuc = MessageBox.Show("Silmek istiyor musunuz?", "Silme onayı", MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
            {

                ds.Clear();

                komut.Fill(ds);
            }



            baglanti.Close();
            verileriCek();
        }
        public void bosil()  
        {

            sorgulaGrid.AllowUserToAddRows = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(knoSorgula.Text == "")
            verileriCek();
        }

        private void sorgulaGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
