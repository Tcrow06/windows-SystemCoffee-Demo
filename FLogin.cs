using System.Data;
using System.Data.SqlClient;
namespace SystemManagemntCofffe_Demo
{
    public partial class FLogin : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);

        public FLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sqlString = string.Format("select count(*) from accountusers where username = '{0}' and pass = '{1}'", txtUser.Text, txtPass.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlString, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    FUser? fus = new FUser();
                    this.Hide();
                    fus.ShowDialog();
                    fus = null;
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai " + ex);
            }
            finally { conn.Close(); }
        }

        private void btnLoginadmin_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sqlString = string.Format("select count(*) from accountadmin where username = '{0}' and pass = '{1}'", txtUser.Text, txtPass.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlString, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    FAdmin? fad = new FAdmin();
                    this.Hide();
                    fad.ShowDialog();
                    fad = null;
                    this.Show();

                }
                else
                {
                    MessageBox.Show("Tai khoan khong ton tai");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai " + ex);
            }
            finally { conn.Close(); }
        }

        private void btnLogin_Enter(object sender, EventArgs e)
        {

        }

        private void lblCrtacc_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
