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
            SortOption.ItemsSource = new List<string>() {"Без сортировки", "По названию", "По дате выхода" };
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

        private void GenreFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (GenreFilter.Text == "Жанр")
            { 
                GenreFilter.Text = String.Empty;
                GenreFilter.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void GenreFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            if (GenreFilter.Text == String.Empty)
            {
                GenreFilter.Foreground = new SolidColorBrush(Colors.Gray);
                GenreFilter.Text = "Жанр";
            }
                
        }

        private void Year1Filter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Year1Filter.Text == "Год (начало)")
            {
                Year1Filter.Text = String.Empty;
                Year1Filter.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void Year1Filter_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Year1Filter.Text == String.Empty)
            {
                Year1Filter.Foreground = new SolidColorBrush(Colors.Gray);
                Year1Filter.Text = "Год (начало)";
            }
        }

        private void Year2Filter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Year2Filter.Text == "Год (конец)")
            {
                Year2Filter.Text = String.Empty;
                Year2Filter.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void Year2Filter_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Year2Filter.Text == String.Empty)
            {
                Year2Filter.Foreground = new SolidColorBrush(Colors.Gray);
                Year2Filter.Text = "Год (конец)";
            }
        }

        private void AuthorFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AuthorFilter.Text == "Автор")
            {
                AuthorFilter.Text = String.Empty;
                AuthorFilter.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void AuthorFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AuthorFilter.Text == String.Empty)
            {
                AuthorFilter.Foreground = new SolidColorBrush(Colors.Gray);
                AuthorFilter.Text = "Автор";
            }
        }

        private void TitleFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TitleFilter.Text == "Название")
            {
                TitleFilter.Text = String.Empty;
                TitleFilter.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TitleFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TitleFilter.Text == String.Empty)
            {
                TitleFilter.Foreground = new SolidColorBrush(Colors.Gray);
                TitleFilter.Text = "Название";
            }
        }

        private void UserIdFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UserIdFilter.Text == "Id пользователя")
            {
                UserIdFilter.Text = String.Empty;
                UserIdFilter.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void UserIdFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UserIdFilter.Text == String.Empty)
            {
                UserIdFilter.Foreground = new SolidColorBrush(Colors.Gray);
                UserIdFilter.Text = "Id пользователя";
            }
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            int parseResult;
            try
            {
                // создание набора фильтров
                BookFiltersModel bookFiltersModel = new BookFiltersModel();
                if(AuthorFilter.Text!="Автор")
                    bookFiltersModel.Author = AuthorFilter.Text;
                if (int.TryParse(Year1Filter.Text, out parseResult))
                    bookFiltersModel.YearValue1 = parseResult;
                if (int.TryParse(Year2Filter.Text, out parseResult))
                    bookFiltersModel.YearValue2 = parseResult;
                if (GenreFilter.Text != "Жанр")
                    bookFiltersModel.Genre = GenreFilter.Text;
                if (TitleFilter.Text != "Название")
                    bookFiltersModel.Title = TitleFilter.Text;
                if (int.TryParse(UserIdFilter.Text, out parseResult))
                    bookFiltersModel.UserId = parseResult;

                //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
                //Получение списка всех книг, отсортированного в порядке убывания года их выхода.
                switch (SortOption.Text)
                {
                    //"По названию", "По дате выхода" Без сортировки
                    case "По названию":
                        DataBaseView.ItemsSource = bookRepository.Filter(bookFiltersModel).OrderBy(b => b.Title);
                        break;
                    case "По дате выхода":
                        DataBaseView.ItemsSource = bookRepository.Filter(bookFiltersModel).OrderByDescending(b => b.Year);
                        break;
                    case "Без сортировки":
                        DataBaseView.ItemsSource = bookRepository.Filter(bookFiltersModel);
                        break;
                    default:
                        DataBaseView.ItemsSource = bookRepository.Filter(bookFiltersModel);
                        break;
                }                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
