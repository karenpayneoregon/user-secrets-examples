using System.Windows;
using SampleApp3.Classes;

// ReSharper disable ConvertConstructorToMemberInitializers

namespace SampleApp3;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        
        InitializeComponent();

        DataContext = new SecretDataViewModel(); ;

    }
}