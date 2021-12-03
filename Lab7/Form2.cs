using System;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void linkLabel_AES_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.microsoft.com/ru-ru/dotnet/api/system.security.cryptography.aes?redirectedfrom=MSDN&view=net-6.0");
        }

        private void linkLabel_Rijndael_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.microsoft.com/ru-ru/dotnet/api/system.security.cryptography.rijndael?redirectedfrom=MSDN&view=net-6.0");
        }

        private void linkLabel_DES_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.microsoft.com/ru-ru/dotnet/api/system.security.cryptography.des?redirectedfrom=MSDN&view=net-6.0");
        }

        private void linkLabel_TriplDES_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.microsoft.com/ru-ru/dotnet/api/system.security.cryptography.tripledes?redirectedfrom=MSDN&view=net-6.0");
        }

        private void linkLabel_RC2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.microsoft.com/ru-ru/dotnet/api/system.security.cryptography.rc2?redirectedfrom=MSDN&view=net-6.0");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
