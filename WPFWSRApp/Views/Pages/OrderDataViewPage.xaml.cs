using Microsoft.Win32;
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
using WPFWSRApp.Context;
using WPFWSRApp.Model;

namespace WPFWSRApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderDataViewPage.xaml
    /// </summary>
    public partial class OrderDataViewPage : Page
    {
        public Visitor Visitor { get; set; }

        public OrderDataViewPage(Visitor visitor)
        {
            InitializeComponent();
            Visitor = visitor;
            this.DataContext = this;
        }

        OpenFileDialog open = new OpenFileDialog();
        //Метод добавления файла
        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            open.ShowDialog();
        }
        //Метод добавления фото
        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            open.ShowDialog();
        }
        //Метод очистки формы
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {        
            Page_Loaded(null, null);
        }

        private void btnOrderAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Visitor.ID == 0)
                {
                    DataApp.db.Visitor.Add(Visitor);
                }
                DataApp.db.SaveChanges();
                MessageBox.Show("Данные успешно сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }      
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
