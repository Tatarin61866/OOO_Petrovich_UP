using OOO_Petrovich.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace OOO_Petrovich
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Classes.Helper.DB_OOO_PetrovichEntities = new Model.DB_OOO_PetrovichEntities();
            
        }

        private void getGuest() {
            this.Hide();
            View.Catalog catalpg = new View.Catalog();
            catalpg.Show();
        }

        private void getUser() {
            List<Model.user> users = new List<Model.user>();
            users = Helper.DB_OOO_PetrovichEntities.user.ToList();
            Model.user user = Helper.DB_OOO_PetrovichEntities.user.Where(u => u.userLogin == tbLogin.Text && u.userPassword == tbPass.Text).FirstOrDefault();

            if (user != null)
            {
                App.fullName = user.userFullName.ToString();
                App.userRole = user.role.roleName.ToString();
                this.Hide();
                View.Catalog catalpg = new View.Catalog();
                catalpg.Show();

            }
            else
            {
                MessageBox.Show("Не верный логин или пароль.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            getUser();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            getGuest();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
