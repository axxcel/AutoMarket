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

using ClassLibrary;

namespace car
{
    /// <summary>
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Window
    {
        public void NewTextBlock(string name)
        {
            TextBlock textBlock = new();
            textBlock.Text = name;
            textBlock.FontSize = 18;
            textBlock.FontFamily = new FontFamily("Arial");
            addServices.Children.Add(textBlock);
        }

        public Check(Car car, AssemblyCar assemblyCar)
        {
            InitializeComponent();
            TextBrand.Text = car.brand;
            TextBody.Text = car.body;

            if(assemblyCar.Computer.name != null)
                NewTextBlock(assemblyCar.Computer.name + " " + " " + assemblyCar.Computer.price.ToString() + "р");

            if (assemblyCar.Tinting.name != null)
                NewTextBlock(assemblyCar.Tinting.name + " " + " " + assemblyCar.Tinting.price.ToString() + "р");

            if (assemblyCar.GlassHeating.name != null)
                NewTextBlock(assemblyCar.GlassHeating.name + " " + " " + assemblyCar.GlassHeating.price.ToString() + "р");

            oldPrice.Text = assemblyCar.OldPrice.ToString() +".00р";
            price.Text = assemblyCar.Price.ToString() +".00р";
            discount.Text = assemblyCar.Discount.ToString() +".00р";
        }
    }
}
