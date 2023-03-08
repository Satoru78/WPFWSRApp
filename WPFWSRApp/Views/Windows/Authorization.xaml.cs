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
using System.Windows.Shapes;
using WPFWSRApp.Context;
using WPFWSRApp.Model;

namespace WPFWSRApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Employees Employees { get; set; }
        public List<Departament> Departaments { get; set; }
        public Authorization()
        {
            InitializeComponent();
            Departaments = DataApp.db.Departament.ToList();
            this.DataContext = this;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmdDepartament.Text == "" && txbCode.Text == "")
                {
                    throw new Exception("Заполните все поля!");
                }
                else
                {
                    var currentEmployee = DataApp.db.Employees.FirstOrDefault(item => item.Code == txbCode.Text);
                    if (currentEmployee != null && cmdDepartament.Text == cmdDepartament.Text)
                    {
                        switch (currentEmployee.IDDepartment)
                        {
                            case 1:
                                MainWindow mainWindow = new MainWindow(currentEmployee);
                                mainWindow.ShowDialog();
                                break;                        
                        }
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
