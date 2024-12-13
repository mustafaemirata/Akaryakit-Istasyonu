using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AkaryakitOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=EMIR\SQLEXPRESS;Initial Catalog=DbAkaryakit;Integrated Security=True;Encrypt=False");

        void fiyatListesi()
        {
            try
            {
                baglanti.Open();

                // Kursunsuz95
                SqlCommand komut1 = new SqlCommand("SELECT SATISFIYAT, STOK FROM Tbl_Benzin WHERE PETROLTUR = 'Kursunsuz95'", baglanti);
                SqlDataReader oku1 = komut1.ExecuteReader();
                if (oku1.Read())
                {
                    lblkursunsuz95.Text = oku1["SATISFIYAT"].ToString();
                    kursunsuz95Bar.Value = int.Parse(oku1["STOK"].ToString());
                    kursunsuz95Litre.Text = oku1["STOK"].ToString();
                }
                oku1.Close();

                // Kursunsuz97
                SqlCommand komut2 = new SqlCommand("SELECT SATISFIYAT, STOK FROM Tbl_Benzin WHERE PETROLTUR = 'Kursunsuz97'", baglanti);
                SqlDataReader oku2 = komut2.ExecuteReader();
                if (oku2.Read())
                {
                    lblkursunsuz7.Text = oku2["SATISFIYAT"].ToString();
                    Bar97.Value = int.Parse(oku2["STOK"].ToString());
                    kursunsuz97Litre.Text = oku2["STOK"].ToString();
                }
                oku2.Close();

                // EuroDizel10
                SqlCommand komut3 = new SqlCommand("SELECT SATISFIYAT, STOK FROM Tbl_Benzin WHERE PETROLTUR = 'EuroDizel'", baglanti);
                SqlDataReader oku3 = komut3.ExecuteReader();
                if (oku3.Read())
                {
                    lbleurodizel.Text = oku3["SATISFIYAT"].ToString();
                    EuroDizelBar.Value = int.Parse(oku3["STOK"].ToString());
                    euroDizelLitre.Text = oku3["STOK"].ToString();
                }
                oku3.Close();

                // YeniProDizel
                SqlCommand komut4 = new SqlCommand("SELECT SATISFIYAT, STOK FROM Tbl_Benzin WHERE PETROLTUR = 'YeniProDizel'", baglanti);
                SqlDataReader oku4 = komut4.ExecuteReader();
                if (oku4.Read())
                {
                    lblprodizel.Text = oku4["SATISFIYAT"].ToString();
                    yeniProDizelBar.Value = int.Parse(oku4["STOK"].ToString());
                    yeniProDizelLitre.Text = oku4["STOK"].ToString();
                }
                oku4.Close();

                // Gaz
                SqlCommand komut5 = new SqlCommand("SELECT SATISFIYAT, STOK FROM Tbl_Benzin WHERE PETROLTUR = 'Gaz'", baglanti);
                SqlDataReader oku5 = komut5.ExecuteReader();
                if (oku5.Read())
                {
                    lblgaz.Text = oku5["SATISFIYAT"].ToString();
                    gazBar.Value = int.Parse(oku5["STOK"].ToString());
                    gazLitre.Text = oku5["STOK"].ToString();
                }
                oku5.Close();

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("SELECT * FROM Tbl_Kasa",baglanti);
            SqlDataReader dr6=komut6.ExecuteReader();
            while(dr6.Read())
            {
                kasa.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fiyatListesi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                try
                {
                    // Open connection using 'using' statement to ensure it is closed after use
                    using (SqlConnection baglanti = new SqlConnection(@"Data Source=EMIR\SQLEXPRESS;Initial Catalog=DbAkaryakit;Integrated Security=True;Encrypt=False"))
                    {
                        baglanti.Open();

                        // Insert into Tbl_Hareket
                        SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Hareket (PLAKA, BENZINTURU, LITRE, FIYAT) VALUES (@P1,@P2,@P3,@P4)", baglanti);
                        komut.Parameters.AddWithValue("@P1", txtPlaka.Text);
                        komut.Parameters.AddWithValue("@P2", "Kursunsuz 95");
                        komut.Parameters.AddWithValue("@P3", numericUpDown1.Value);
                        komut.Parameters.AddWithValue("@P4", decimal.Parse(kursunsuzF.Text));
                        komut.ExecuteNonQuery();

                        // Update Tbl_Kasa
                        SqlCommand komut2 = new SqlCommand("UPDATE Tbl_Kasa SET MIKTAR = MIKTAR + @p1", baglanti);
                        komut2.Parameters.AddWithValue("@p1", decimal.Parse(kursunsuzF.Text));
                        komut2.ExecuteNonQuery();

                        // Update Tbl_Benzin
                        SqlCommand komut3 = new SqlCommand("UPDATE Tbl_Benzin SET STOK = STOK - @P1 WHERE PETROLTUR = 'Kursunsuz95'", baglanti);
                        komut3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                        komut3.ExecuteNonQuery();

                        // Commit changes and close the connection automatically due to 'using'
                        MessageBox.Show("Satış Yapıldı.");
                        fiyatListesi();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }

            if (numericUpDown2.Value != 0)
            {
                try
                {
                    // Open connection using 'using' statement to ensure it is closed after use
                    using (SqlConnection baglanti = new SqlConnection(@"Data Source=EMIR\SQLEXPRESS;Initial Catalog=DbAkaryakit;Integrated Security=True;Encrypt=False"))
                    {
                        baglanti.Open();

                        // Insert into Tbl_Hareket
                        SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Hareket (PLAKA, BENZINTURU, LITRE, FIYAT) VALUES (@P1,@P2,@P3,@P4)", baglanti);
                        komut.Parameters.AddWithValue("@P1", txtPlaka.Text);
                        komut.Parameters.AddWithValue("@P2", "Kursunsuz 97");
                        komut.Parameters.AddWithValue("@P3", numericUpDown2.Value);
                        komut.Parameters.AddWithValue("@P4", decimal.Parse(kursunsuz97F.Text));
                        komut.ExecuteNonQuery();

                        // Update Tbl_Kasa
                        SqlCommand komut2 = new SqlCommand("UPDATE Tbl_Kasa SET MIKTAR = MIKTAR + @p1", baglanti);
                        komut2.Parameters.AddWithValue("@p1", decimal.Parse(kursunsuz97F.Text));
                        komut2.ExecuteNonQuery();

                        // Update Tbl_Benzin
                        SqlCommand komut3 = new SqlCommand("UPDATE Tbl_Benzin SET STOK = STOK - @P1 WHERE PETROLTUR = 'Kursunsuz97'", baglanti);
                        komut3.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                        komut3.ExecuteNonQuery();

                        // Commit changes and close the connection automatically due to 'using'
                        MessageBox.Show("Satış Yapıldı.");
                        fiyatListesi();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
            if (numericUpDown3.Value != 0)
            {
                try
                {
                    // Open connection using 'using' statement to ensure it is closed after use
                    using (SqlConnection baglanti = new SqlConnection(@"Data Source=EMIR\SQLEXPRESS;Initial Catalog=DbAkaryakit;Integrated Security=True;Encrypt=False"))
                    {
                        baglanti.Open();

                        // Insert into Tbl_Hareket
                        SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Hareket (PLAKA, BENZINTURU, LITRE, FIYAT) VALUES (@P1,@P2,@P3,@P4)", baglanti);
                        komut.Parameters.AddWithValue("@P1", txtPlaka.Text);
                        komut.Parameters.AddWithValue("@P2", "Euro Dizel 10");
                        komut.Parameters.AddWithValue("@P3", numericUpDown3.Value);
                        komut.Parameters.AddWithValue("@P4", decimal.Parse(euroDizelF.Text));
                        komut.ExecuteNonQuery();

                        // Update Tbl_Kasa
                        SqlCommand komut2 = new SqlCommand("UPDATE Tbl_Kasa SET MIKTAR = MIKTAR + @p1", baglanti);
                        komut2.Parameters.AddWithValue("@p1", decimal.Parse(kursunsuz97F.Text));
                        komut2.ExecuteNonQuery();

                        // Update Tbl_Benzin
                        SqlCommand komut3 = new SqlCommand("UPDATE Tbl_Benzin SET STOK = STOK - @P1 WHERE PETROLTUR = 'EuroDizel'", baglanti);
                        komut3.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                        komut3.ExecuteNonQuery();

                        // Commit changes and close the connection automatically due to 'using'
                        MessageBox.Show("Satış Yapıldı.");
                        fiyatListesi();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;

            if (double.TryParse(lblkursunsuz95.Text, out kursunsuz95))
            {
                litre = Convert.ToDouble(numericUpDown1.Value);
                tutar = kursunsuz95 * litre;
                kursunsuzF.Text = tutar.ToString();
            }
            else
            {
                MessageBox.Show("Kursunsuz95'in fiyatı geçerli bir sayı değil.");
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, litre, tutar;

            if (double.TryParse(lblkursunsuz7.Text, out kursunsuz97))
            {
                litre = Convert.ToDouble(numericUpDown2.Value);
                tutar = kursunsuz97 * litre;
                kursunsuz97F.Text = tutar.ToString();
            }
            else
            {
                MessageBox.Show("Kursunsuz97'in fiyatı geçerli bir sayı değil.");
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double euroDizel, litre, tutar;

            if (double.TryParse(lbleurodizel.Text, out euroDizel))
            {
                litre = Convert.ToDouble(numericUpDown3.Value);
                tutar = euroDizel * litre;
                euroDizelF.Text = tutar.ToString();
            }
            else
            {
                MessageBox.Show("EuroDizel'in fiyatı geçerli bir sayı değil.");
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double yeniPro, litre, tutar;

            if (double.TryParse(lblprodizel.Text, out yeniPro))
            {
                litre = Convert.ToDouble(numericUpDown4.Value);
                tutar = yeniPro * litre;
                YeniProDizelF.Text = tutar.ToString();
            }
            else
            {
                MessageBox.Show("YeniProDizel'in fiyatı geçerli bir sayı değil.");
            }
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;

            if (double.TryParse(lblgaz.Text, out gaz))
            {
                litre = Convert.ToDouble(numericUpDown5.Value); // Corrected: Use numericUpDown5 instead of numericUpDown4
                tutar = gaz * litre;
                gazF.Text = tutar.ToString();
            }
            else
            {
                MessageBox.Show("Gaz'ın fiyatı geçerli bir sayı değil.");
            }
        }

        private void istasyonDoldur_Click(object sender, EventArgs e)
        {
            BenzinYukle frm = new BenzinYukle();
            frm.ShowDialog();

        }
    }
}
