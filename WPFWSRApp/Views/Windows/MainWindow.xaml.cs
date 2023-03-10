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
using WPFWSRApp.Model;
using WPFWSRApp.Views.Pages;

namespace WPFWSRApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Employees Employees { get; set; }
        public Departament Departament { get; set; }
        public MainWindow(Employees employees)
        {
            InitializeComponent();
            MainFrame.Navigate(new OrderDataViewPage(new Visitor()));
            this.Employees = employees;
            tblNameUser.Text = $"Пользователь: {employees.FirstName} {employees.LastName} {employees.Patronymic}";
        }
    }
}
