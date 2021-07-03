using System.Windows;

namespace PassManager.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PassBox.Password == "pass")
            {
                AppWindow appWindow = new AppWindow();
                appWindow.Show();
                this.Close();
            } else
            {
                ErrorLabel.Content = "Wrong password!";
            }
        }

        
    }
}
