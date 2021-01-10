using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Collections;

namespace Covid_Aplication
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent(); 
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.inovaprudente.com.br/coronavirus");
            foreach (var curados in doc.DocumentNode.SelectNodes("//*[@id='wrapper']/section[2]/div/div[1]/div[1]/div/div[1]/div[2]"))
            {
                txtNumeroCurados.Text = curados.InnerText;
            }
            foreach (var notificacoes in doc.DocumentNode.SelectNodes("//*[@id='wrapper']/section[2]/div/div[1]/div[2]/div/div[1]/div[2]"))
            {
                txtNumeroNotificados.Text = notificacoes.InnerText;
            }
            foreach (var descartados in doc.DocumentNode.SelectNodes("//*[@id='wrapper']/section[2]/div/div[1]/div[3]/div/div[1]/div[2]"))
            {
                txtNumeroDescartados.Text = descartados.InnerText;
            }
            foreach (var aguardando in doc.DocumentNode.SelectNodes("//*[@id='wrapper']/section[2]/div/div[1]/div[4]/div/div[1]/div[2]"))
            {
                txtNumeroArguandoResultado.Text = aguardando.InnerText;
            }
            foreach (var hospitalizados in doc.DocumentNode.SelectNodes("//*[@id='wrapper']/section[2]/div/div[1]/div[5]/div/div[1]/div[2]"))
            {
                txtNumeroHospitalizados.Text = hospitalizados.InnerText;
            }
            foreach (var confirmados in doc.DocumentNode.SelectNodes("//*[@id='wrapper']/section[2]/div/div[1]/div[6]/div/div[1]/div[2]"))
            {
                txtNumeroConfirmados.Text = confirmados.InnerText;
            }
            foreach (var obitos in doc.DocumentNode.SelectNodes("//*[@id='wrapper']/section[2]/div/div[1]/div[7]/div/div[1]/div[2]"))
            {
                txtNumeroÓbitos.Text = obitos.InnerText;
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] // Permite mover o sistema pela tela
        private extern static void ReleaseCapture();// Permite mover o sistema pela tela
        [DllImport("user32.DLL", EntryPoint = "SendMessage")] // Permite mover o sistema pela tela
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);// Permite mover o sistema pela tela

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();// Permite mover o sistema pela tela
            SendMessage(this.Handle, 0x112, 0xf012, 0);// Permite mover o sistema pela tela
        }
    }
}
