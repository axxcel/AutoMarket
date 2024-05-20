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
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;
using Image = System.Windows.Controls.Image;
using Microsoft.Data.Sqlite;
using ClassLibrary;
using System.Diagnostics.PerformanceData;
using System.Data;
using DLLForWriteLogs;

namespace car
{
    /// <summary>
    /// Логика взаимодействия для MainCar.xaml
    /// </summary>
    public partial class MainCar : Page
    {
        public Button StyleForCard(int id, string mark, string kuzov, int price, int oldPrice, int have)
        {
            var bc = new BrushConverter();
            Image img = new Image()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Source = new BitmapImage(new Uri("/img/lada-granta.png", UriKind.Relative)),
                Margin = new Thickness(0, 0, 0, 20)
            };

            TextBlock Brand = new TextBlock
            {
                FontSize = 20,
                Text = mark,
                FontFamily = new FontFamily("Segoe UI Semibold")
            };

            TextBlock bodyCar = new TextBlock
            {
                FontSize = 20,
                Text = kuzov,
                Margin = new Thickness(5, 0, 0, 0),
                FontFamily = new FontFamily("Segoe UI Semibold")
            };
            StackPanel title = new StackPanel();
            title.Orientation = Orientation.Horizontal;
            title.Children.Add(Brand);
            title.Children.Add(bodyCar);

            TextBlock Price = new TextBlock
            {
                FontSize = 18,
                Text = "от " + price.ToString() + "р",
                FontFamily = new FontFamily("Arial"),
                FontWeight = FontWeights.Bold,
                Foreground = (Brush)bc.ConvertFrom("#FF5E54E0")
            };
            TextBlock OldPrice = new TextBlock
            {
                FontFamily = new FontFamily("Arial"),
                Foreground = Brushes.DimGray,
                FontSize = 12,
                Text = "Старая цена от " + oldPrice.ToString() + "р"
            };

            TextBlock Have = new TextBlock
            {
                Margin = new Thickness(0,5,0,0),
                FontFamily = new FontFamily("Arial"),
                FontSize = 18,
            };

            if(have == 1)
            {
                Have.Text = "В наличии";
            }
            else
            {
                Have.Text = "Нет в наличии";
            }

            StackPanel card = new StackPanel();
            card.Margin = new Thickness(10, 10, 10, 10);
            card.Children.Add(img);
            card.Children.Add(title);
            card.Children.Add(Price);
            card.Children.Add(OldPrice);
            card.Children.Add(Have);

            Button button = new Button
            {
                Content = card,
                Background = (Brush)bc.ConvertFrom("#FFDDDDDD"),
                Width = 215,
                BorderBrush = null,
                Padding = new Thickness(5, 0, 5, 0),
                Tag = id,
            };
            button.Click += ShowFullCart;
            ListCars.Children.Add(button);
            return button;
        }

        private void ShowFullCart(object sender, RoutedEventArgs e)
        {
            var Button = (Button)sender;

            WriteLogs writeLogs = new WriteLogs();
            writeLogs.Logs("карточка товара " + Button.Tag.ToString());

            MainWindow main = Application.Current.MainWindow as MainWindow;
            if (main != null)
            {
                using (var con = new SqliteConnection("Data Source=db.db;"))
                {
                    con.Open();
                    SqliteCommand cmd = new SqliteCommand("SELECT Car.id,(SELECT Brands.name FROM Brands WHERE Brands.idBrand = Car.idBrand) AS brand, Car.idBody, Car.price, Car.oldPrice, Car.have FROM [Car]", con);

                    using (SqliteDataReader read = cmd.ExecuteReader())
                    {
                        if (read.HasRows)
                        {
                            int i = 1;
                            while (read.Read())
                            {
                                if(i == int.Parse(Button.Tag.ToString()))
                                {
                                    Bodies _item = (Bodies)read.GetInt32(2);
                                    main.MainFrame.Content = new BuildCar(read.GetString(1), _item.ToString(), read.GetInt32(3), read.GetInt32(4), read.GetInt32(5));
                                    break;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                        }
                    }
                    con.Close();
                }
            }
        }

        public MainCar()
        {
            InitializeComponent();
            using (var con = new SqliteConnection("Data Source=db.db;"))
            {
                con.Open();
                SqliteCommand cmd = new SqliteCommand("SELECT Car.id,(SELECT Brands.name FROM Brands WHERE Brands.idBrand = Car.idBrand) AS brand, Car.idBody, Car.price, Car.oldPrice, Car.have FROM [Car]", con);

                using(SqliteDataReader read = cmd.ExecuteReader())
                {
                    if (read.HasRows)
                    {
                        int i = 1;
                        while (read.Read())
                        {
                            Bodies _item = (Bodies)read.GetInt32(2);
                            Button btn = StyleForCard(i, read.GetString(1), _item.ToString(), read.GetInt32(3), read.GetInt32(4), read.GetInt32(5));
                            i++;
                        }
                    }
                }
                con.Close();
            }
        }
    }
}
