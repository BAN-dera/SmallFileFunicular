using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;

namespace Client.Forms
{
    public partial class LoginForm : Form
    {
        IFirebaseConfig fConfig = new FirebaseConfig()
        {
            BasePath = "https://smallfilefunicular-default-rtdb.firebaseio.com/",
            AuthSecret = "zy45dOIje35M51x1eBa7QB3kVxphfBcchSMvrnyP"
        };

        IFirebaseClient client;


        MainForm Parent;

        public LoginForm(MainForm parent)
        {
            InitializeComponent();

            Parent = parent;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fConfig);
            }
            catch (Exception) { MessageBox.Show("Problem with internet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.Account account = client.GetAsync("Accounts/" + textBox1.Text).Result.ResultAs<Data.Account>();

            if (account != null && textBox2.Text == Data.Account.Password)
            {
                Data.Account.IP = GetGlobalIP();
                Data.Account.IsActive = "YES";
                client.SetAsync("Accounts/" + Data.Account.Login, account);

                Data.AuthorizedAccount.Login = Data.Account.Login;
                Data.AuthorizedAccount.Password = Data.Account.Password;
                Data.AuthorizedAccount.ID = Data.Account.ID;
                Data.AuthorizedAccount.IP = Data.Account.IP;
                Data.AuthorizedAccount.IsActive = Data.Account.IsActive;

                Parent.Opacity = 100;
                Parent.ShowInTaskbar = true;

                Close();
            }
            else
            {
                MessageBox.Show("No such account exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetGlobalIP()
        {
            using (WebClient wc = new WebClient())
            {
                wc.Proxy = null;

                string ip = wc.DownloadString("http://icanhazip.com").Split('\n')[0];

                return ip;
            }
        }
    }
}
