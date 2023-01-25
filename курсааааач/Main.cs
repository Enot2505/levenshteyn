using System;
using System.Windows.Forms;

namespace КурсоваяОП
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult authDialogResult = new FormAuth().ShowDialog();

            if (authDialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("Вы не авторизовались!");
                Close();
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {   }
        private void buttonCalc_Click(object sender, EventArgs e)
        {
            string user = FormAuth.AuthUser;
            var distance = new LevenshteinDistance(first.Text,second.Text);
           dist.Text=Convert.ToString(distance.Levenshtein());
            new Database("Data Source=dataBase.db;Version=3;").createDisnanse(user ,distance);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void first_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
