using System;
using System.Windows.Forms;

namespace КурсоваяОП
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        { }
        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            textBoxLogin.Text = textBoxLogin.Text.Trim();
            textBoxPassword.Text = textBoxPassword.Text.Trim();
            textBoxConfirm.Text = textBoxConfirm.Text.Trim();
            try
            {
                var user = new User(textBoxLogin.Text, textBoxPassword.Text,
               textBoxConfirm.Text);
                if (!user.Exist())
                {
                    if (user.CorrectUser())
                    {
                        new Database("Data Source=dataBase.db;Version=3;").createUser(user);

                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Имя пользователя уже занято", "Ошибка регистрации",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка регистрации", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                return;
            }             
        }
        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        { }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
        }

        private void textBoxPassword2_TextChanged(object sender, EventArgs e)
        { 
            textBoxConfirm.UseSystemPasswordChar = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBoxConfirm.UseSystemPasswordChar = false;
            }
            else

            {
                textBoxConfirm.UseSystemPasswordChar = true;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else

            {
                textBoxPassword.UseSystemPasswordChar = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
