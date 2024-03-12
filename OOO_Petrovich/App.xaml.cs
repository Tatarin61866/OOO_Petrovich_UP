using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OOO_Petrovich
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string fullName = "Гость";
        public static string userRole = "Гость";

        public static int userClear()
        {
            fullName = "Гость";
            userRole = "Гость";
            return 0;
        }
    }
}
