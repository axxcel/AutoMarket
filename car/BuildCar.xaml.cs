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
using ClassLibrary;
using DLLForWriteLogs;
namespace car
{
    /// <summary>
    /// Логика взаимодействия для BuildCar.xaml
    /// </summary>
    public partial class BuildCar : Page
    {
        int SumPrice;

        Check check;
        static Car car = new();
        AssemblyCarBuilder assemblyCarBuilder = new(car);

        public BuildCar(string brand, string body, int price, int oldPrice, int have)
        {
            InitializeComponent();

            TextBrand.Text = brand;
            TextBody.Text = body;
            TextPrice.Text = "от "+ price.ToString() +"р";
            TextOldPrice.Text = "старая цена от " + oldPrice.ToString() + "р";
            SumPrice = price;
            if (have == 1)
            {
                TextHave.Text = "В наличии";
            }
            else
            {
                TextHave.Text = "Нет в наличии";
                Reg.Visibility = Visibility.Collapsed;
                TextAlert.Visibility = Visibility.Visible;
            }
            Sum.Text = SumPrice.ToString() + "р";
            car.brand = brand;
            car.body = body;
            car.price = price;
            car.oldPrice = oldPrice;
            car.discount = oldPrice - price;

            assemblyCarBuilder.SetupPrice();
        }
        private void BtnBack(object sender, RoutedEventArgs e)
        {
            WriteLogs write = new WriteLogs();
            write.Logs(ButtonBack.Content.ToString());

            MainWindow main = Application.Current.MainWindow as MainWindow;
            if (main != null)
            {
                main.MainFrame.Content = new MainCar();
            }
        }

        private void GetCheck(object sender, RoutedEventArgs e)
        {
            WriteLogs write = new WriteLogs();
            write.Logs(Reg.Content.ToString());

            AssemblyCar assemblyCar = assemblyCarBuilder.GetCar();
            check = new Check(car, assemblyCar);
            check.Show();
        }
        private void AddComputer_Checked(object sender, RoutedEventArgs e)
        {
            SumPrice += 5000;
            Sum.Text = SumPrice.ToString() + "р";
            assemblyCarBuilder.BuildComputer();
        }

        private void AddComputer_Unchecked(object sender, RoutedEventArgs e)
        {
            SumPrice -= 5000;
            Sum.Text = SumPrice.ToString() + "р";
        }

        private void AddTinting_Checked(object sender, RoutedEventArgs e)
        {
            SumPrice += 5000;
            Sum.Text = SumPrice.ToString() + "р";
            assemblyCarBuilder.BuildTinting();
        }

        private void AddTinting_Unchecked(object sender, RoutedEventArgs e)
        {
            SumPrice -= 5000;
            Sum.Text = SumPrice.ToString() + "р";
        }

        private void AddGlassHeating_Checked(object sender, RoutedEventArgs e)
        {
            SumPrice += 50000;
            Sum.Text = SumPrice.ToString() + "р";
            assemblyCarBuilder.BuildGlassHeating();
        }

        private void AddGlassHeating_Unchecked(object sender, RoutedEventArgs e)
        {
            SumPrice -= 50000;
            Sum.Text = SumPrice.ToString() + "р";
        }
    }
}
