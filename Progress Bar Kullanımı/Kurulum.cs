using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Progress_Bar_Kullanımı
{
    public partial class Kurulum : Form
    {
        public Kurulum()
        {
            InitializeComponent();
        }

        

        private void Kurulum_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100; /* Prgressbar ın alabileceği maximum değeri belirledim.
                                         * Bunun üzerinde progressbara atanacak değer sonucunda
                                         * hata alırız.
                                        */
            progressBar1.Minimum = 0; // progressbar ın minimum alabileceği değer.

            label2.Text = "Program Dosyaları Çıkartılıyor...%"+progressBar1.Value.ToString();

            timer1.Start(); // Timer ı başlattık.


        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 10; // progresbar a değer ataması value ile yapılır. 

            if (progressBar1.Value <= 30) 
                label2.Text = "Program Dosyaları Çıkartılıyor...%"+progressBar1.Value.ToString();
            else if (progressBar1.Value <= 80)
                label2.Text = "Program Dosyaları Kuruluyor...%" + progressBar1.Value.ToString();
            else if(progressBar1.Value<100)
                label2.Text = "Program Kurulumu Bir Kaç Saniye İçinde Sonlanacak...%" + progressBar1.Value.ToString();


            DialogResult a = new DialogResult(); 

            /* Şimdi burada DialogResult nesnesinden bahsedeyim.
             * Dialog result nesnesini kullanabilmek için öncelikle nesnemizi oluşturuyoruz
             * yukarıdaki kod ile. 
             * Peki dialog result bizim ne işimize yarar. Dİalog result bir takım girdiler sonucunda 
             * alınan sonuçları bünyesinde tutup bu tutlan değere göre işlem yapmamıza olanak sağlar.
             * buradaki örnek üzerinden yola çıkalım. messagebox ile bir mesaj verdik ve kullanıcıya
             * messagebox üzerinde bir takım seçenekler sunarız. evet hayır çıkış gibi seçenekler. 
             * işte dialogresult nesnemiz bizim burada tıkladığımız değeri bünyesinde tutar.
             * */

            if (progressBar1.Value == 100)
            {
                label2.Text = "Kurulum Tamamlandı...%" + progressBar1.Value.ToString();

                timer1.Stop();  // timer ı durdurduk.

                this.Close();   // Formu kapattık.

                a = MessageBox.Show("Programınız Başarılı Bir Şekilde Kuruldu.", "Kurulum", MessageBoxButtons.OK); 
                

                if (a == DialogResult.OK)
                    Application.ExitThread();  /* Normalde exit metodu ilede uygulamadan çıkabilirdik ama 
                                                * Exitthread metodu altta çalışan tüm programları kapatmaya zorlar 
                                                * yani kesin sonuç almamıza yardımcı olan bir metoddur.*/
            }
           
        }
       
    }
}
