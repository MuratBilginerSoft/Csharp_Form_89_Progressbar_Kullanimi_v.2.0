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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false; // form açıldığında next buttonunun erişimini engelledik
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  ÇIKIŞ BUTONU

            Application.Exit(); // Programdan çıkacak
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) 
                button1.Enabled = true; // checbox değeri true ise next butonu aktif yaptık.
            else 
                button1.Enabled = false; // checkbox değeri false ise next butonunu inaktif yaptık.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // NEXT BUTONU

            Kurulum kur = new Kurulum(); // yeni bir form oluşturduk.
            this.Hide(); // üzerinde çalıştığımız formu gizledik.
            kur.ShowDialog(); // Yeni sayfamızı showdialog ile açtık ki kapattığımızda yapacağımız işlemi bir altına yazdık çalışsın diye.
            this.Show(); // İkinci form kapatılırsa bu form tekrar açılacak.

            //  Burada karşılaşabileceğiniz olası bir problemden bahsedeyim sizlere.
            /*  Diğer formumuzu açma işlemi yaparken çalıştığımız formu Hide metodu ile gizliyoruz
             *  ve diğer formumuzu Showdialog metodu ile açıyoruz eğer biz burada Showdialog yerine 
             *  sadece Show metodunu kullanmış olsaydık açtığımız formu kapattığımızda gizlemiş olduğumuz 
             *  ana formu eğer açtığımız form içinde kodlarla açılmasını sağlamadıysak görünür yapamıyacaktık
             *  ve program altta sürekli çalışacaktı ve görünmeyen bu formu normal yollarla kapatma şansımız
             *  olmayacaktı. O yüzden Showdialog kullandıkki açtığımız formu kapattığımızda kapandı bilgisini geri 
             *  döndürüp bir altına yazmış olduğumuz this.show(); metodunu çalıştırabildik.
             *  Bu olası hata ne gibi problemlere neden olabilir kısaca ondanda bahsedeyim. şimdi biz gizlediğimiz
             *  formu açamaz ve programı 2. form üzerinden kapattığımızda tamamen kapandı zannedebiliriz.
             *  ama program altta çalışmaktadır. Bu ise yazdığımız programı derlediğimizde bize 10 kere derlenmeye çalışıldı
             *  ama başarısız olundu çünkü program çalışmakta hatasını döndürür. Programımızı tekrar derleyebilmemiz için
             *  açık programı kapatmamız gerekir.
             */
        }
    }
}
