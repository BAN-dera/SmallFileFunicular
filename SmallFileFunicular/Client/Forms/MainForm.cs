using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;

namespace Client
{
    public partial class MainForm : Form
    {
        private string fileName = "";

        IFirebaseConfig fConfig = new FirebaseConfig()
        {
            BasePath = "https://smallfilefunicular-default-rtdb.firebaseio.com/",
            AuthSecret = "zy45dOIje35M51x1eBa7QB3kVxphfBcchSMvrnyP"
        };

        IFirebaseClient client;


        private Thread fileReceiverThread = new Thread(() =>
        {
            Network.Client.Connect();
            Network.Client.StartRequestLoop();
        });


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            ShowInTaskbar = false;
            Forms.LoginForm login = new Forms.LoginForm(this);
            login.Show();

            fileReceiverThread.Start();

            try
            {
                client = new FireSharp.FirebaseClient(fConfig);

                Data.Server.IP = "192.168.1.100";
                client.SetAsync("Server/IP", Data.Server.IP);

                Data.Account.Login = "AdmAsmCpp";
                Data.Account.Password = "PySharpKali";
                Data.Account.ID = "000001";
                Data.Account.IP = "192.168.1.100";
                Data.Account.IsActive = "YES";
                client.SetAsync("Accounts/AdmAsmCpp", new Data.Account());
            } catch (Exception) { MessageBox.Show("Problem with internet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonChoseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
                fileName = ofd.SafeFileName;
            }
        }

        private void buttonSendFile_Click(object sender, EventArgs e)
        {
            if (txtReceiverID.Text == "")
            {
                MessageBox.Show("You didn't enter receiver id!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtFilePath.Text == "")
            {
                MessageBox.Show("You didn't chose file for sending", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("Such file not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Network.Client.Send("sfile$" + txtReceiverID.Text + "$" + fileName + "$" + Encoding.Unicode.GetString(File.ReadAllBytes(txtFilePath.Text)));
            }
        }
    }
}
