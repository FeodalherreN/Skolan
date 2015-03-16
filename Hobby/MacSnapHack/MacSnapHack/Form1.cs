using MacSnapHack.Models;
using System;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MacSnapHack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPassword.KeyDown += (sender, args) =>
            {
                if (args.KeyCode == Keys.Return)
                {
                    btnLogin.PerformClick();
                }
            };
        }
        private void SetDefault(System.Windows.Forms.Button myDefaultBtn)
        {
            this.AcceptButton = btnLogin;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login(txtUsername.Text, txtPassword.Text);
        }
        private async void login(string username, string password)
        {
            Tuple<TempEnumHolder.LoginStatus, Account> logintuple;
            logintuple = await Methods.Login(username, password);
            if(logintuple.Item1 == TempEnumHolder.LoginStatus.Success)
            {
                MainForm mainform = new MainForm();
                mainform.LoginForm = this;
                mainform.User = logintuple;
                mainform.Text = logintuple.Item2.UserName;
                mainform.StartAutoUpdating();
                this.Visible = false;
                mainform.Show();
            }
            else
            {
                MessageBox.Show(logintuple.Item1.ToString());
            }
        }
    }
}
