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
            try
            {
                if (Users.IsChecked == true)
                {
                    User user = new User() { Name = UserName.Text, Email = Email.Text };
                    userRepository.AddNew(user);
                    MessageBox.Show("Пользователь внесён!");
                }
                if (Users.IsChecked == false)
                {
                    if (Books.IsChecked == true)
                    {
                        Book book = new Book() { Title = Title.Text, Author = Author.Text, Genre = Genre.Text, Year = int.Parse(Year.Text) };
                        bookRepository.AddNew(book);
                        MessageBox.Show("Книга внесена!");
                    }
                    else
                        MessageBox.Show("Ничего не выбрано!");

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Users.IsChecked == true)
                {
                    userRepository.DeleteUser(int.Parse( IdBox.Text));
                    MessageBox.Show("Пользователь удалён!");
                }
                if (Users.IsChecked == false)
                {
                    if (Books.IsChecked == true)
                    {

                        bookRepository.DeleteBook(int.Parse(IdBox.Text));
                        MessageBox.Show("Книга удалена!");
                    }
                    else
                        MessageBox.Show("Ничего не выбрано!");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Users.IsChecked == true)
                {
                    userRepository.UpdateName(int.Parse(IdBox.Text), UserName.Text);
                    MessageBox.Show("Имя изменено!");
                }
                if (Users.IsChecked == false)
                {
                    if (Books.IsChecked == true)
                    {

                        bookRepository.UpdateYear(int.Parse(IdBox.Text), int.Parse(Year.Text));
                        MessageBox.Show("Год изменен!");
                    }
                    else
                        MessageBox.Show("Ничего не выбрано!");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void Belong_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bookRepository.Belong(int.Parse(UserId.Text), int.Parse(BookId.Text));
                MessageBox.Show("Дали пользователю книгу на руки!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
