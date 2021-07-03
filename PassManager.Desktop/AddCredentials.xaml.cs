using PassMenager.Logic.Model;
using PassMenager.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace PassManager.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy AddCredentials.xaml
    /// </summary>
    public partial class AddCredentials : Window
    {
        public AddCredentials()
        {
            InitializeComponent();
        }

        public bool RefreshFlag { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RefreshFlag = false;

            PassCryptor passCryptor = new PassCryptor();

            using (var context = new JippDBContext())
            {
                var pass = new Passwords
                {

                    Title = titleBox.Text,
                    LoginName = loginBox.Text,
                    Email = emailBox.Text,
                    Password = passCryptor.Encipher(passBox.Text,passCryptor.Key),
                    URL = urlBox.Text,
                    Details = detBox.Text

                };
                context.Passwords.Add(pass);
              
                context.SaveChanges();
                reload();
               
                
            }
        }


        private static void reload()
        {
            foreach(Window window in Application.Current.Windows)
            {
                if(window.GetType()==typeof(AppWindow))
                {
                    (window as AppWindow).Load();
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
