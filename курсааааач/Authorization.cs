using System;
using System.Windows.Forms;

namespace КурсоваяОП
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        static public string AuthUser;

        private void Registration_Button_Click(object sender, EventArgs e)
        {
            DialogResult authDialogResult = new Registration().ShowDialog();


        }

        private void Login_textBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Password_textBox_TextChanged(object sender, EventArgs e)
        {
            Password_textBox.UseSystemPasswordChar = true;

        }

        private void Input_button_Click(object sender, EventArgs e)
        {
            AuthUser = Login_textBox.Text;
            if (userAuthSucceess())
                this.DialogResult = DialogResult.OK;
            else
                return;
        }
        private bool userAuthSucceess()
        {
            if (incorrectFiledsOnForm())
            {
                MessageBox.Show("Не корректные поля на форме");
                return false;
            }
            if (hasUser(Login_textBox.Text, Password_textBox.Text))
                return true;
            else
            {
                MessageBox.Show("Не верный логин или пароль");
                return false;
            }
        }

        private bool incorrectFiledsOnForm()
        {
            if (isUnCorrectField(Login_textBox.Text) || isUnCorrectField(Password_textBox.Text))
                return true;


            return false;
        }

        private bool isUnCorrectField(string field)
        {
            if (String.IsNullOrWhiteSpace(field))
                return true;
            return false;
        }

        private bool hasUser(string login, string password)
        {
            User user = new User(login, password);

            return user.IsCorrect();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                Password_textBox.UseSystemPasswordChar = false;
            }
            else
            {
                Password_textBox.UseSystemPasswordChar = true;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
