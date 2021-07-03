using PassMenager.Logic;
using PassMenager.Logic.Model;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PassManager.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        JippDBContext _db = new JippDBContext();
        public static DataGrid datagrid;
     

        public AppWindow()
        {
            InitializeComponent();
        
            Load();
            //FillDataGrid();
        }

        

        public void Load()
        {
            PasswordsDB.ItemsSource = _db.Passwords.ToList();
            datagrid = PasswordsDB;
        }

        public ICipherTool cipherTool()
        {
            

            return new PassCryptor();
        }
        
        /*public void FillDataGrid()
        {

            string ConString = "Data Source=localhost;Initial Catalog=JippDB;Integrated Security=True";
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {

                CmdString = "SELECT * FROM [JippDB].[dbo].[Passwords]";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                PasswordsDB.ItemsSource = dt.DefaultView;
                cmd.Dispose();
                con.Close();
            }
        }*/
        
        public void AddingCredentials(bool doRefresh, AddCredentials addCredentials)
        {
            while(addCredentials.IsActive == true)
            {
                if(addCredentials.RefreshFlag == true)
                {
                    MessageBox.Show("Reload");
                    Load();

                }
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e) //ADD NEW RECORD
        {
           
            AddCredentials addCredentials = new AddCredentials();
            addCredentials.Show();
       
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // REFRESH
        {
            Load();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //REMOVE
        {
            int Id = (PasswordsDB.SelectedItem as Passwords).ID;
            var deletePassword = _db.Passwords.Where(p=>p.ID == Id).Single();
            _db.Passwords.Remove(deletePassword);
            _db.SaveChanges();
            PasswordsDB.ItemsSource = _db.Passwords.ToList();
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PassCryptor passCryptor = new PassCryptor();
            string encryptedPass = (PasswordsDB.SelectedItem as Passwords).Password;
            Clipboard.SetText(passCryptor.Decipher(encryptedPass, passCryptor.Key));
        }

        

    }

   
}
