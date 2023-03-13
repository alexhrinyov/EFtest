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
using EFtest.Entities;
using EFtest.Repositories;

namespace DBVisualisation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserRepository userRepository;
        BookRepository bookRepository;
        public MainWindow()
        {
            InitializeComponent();
            userRepository = new UserRepository();
            bookRepository = new BookRepository();
        }

        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (Users.IsChecked == true)
            {
                DataBaseView.ItemsSource = userRepository.SelectAll();
            }
            if (Users.IsChecked == false)
            {
                if (Books.IsChecked == true)
                    DataBaseView.ItemsSource = bookRepository.SelectAll();
                else
                    MessageBox.Show("Ничего не выбрано!");
            }
            
        }

        private void SelectById_Click(object sender, RoutedEventArgs e)
        {
            if (Users.IsChecked == true)
            {
                DataBaseView.ItemsSource = userRepository.SelectById(int.Parse(IdBox.Text));
            }
            if (Users.IsChecked == false)
            {
                if (Books.IsChecked == true)
                    DataBaseView.ItemsSource = bookRepository.SelectById(int.Parse(IdBox.Text));
                else
                    MessageBox.Show("Ничего не выбрано!");
            }
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
