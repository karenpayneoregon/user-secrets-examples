using SecretsLibrary1;
using SecretsModelsLibrary.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

        DataContext = new SecretDataViewModel();

    }
}

public class SecretData
{
    public string DefaultConnection => SecretApplicationSettingReader
        .Instance.ReadProperty<string>(nameof(Connectionstrings), nameof(Connectionstrings.DefaultConnection));
    public MailSettings MailSettings => SecretApplicationSettingReader
        .Instance.ReadSection<MailSettings>(nameof(MailSettings));
}

public class SecretDataViewModel : INotifyPropertyChanged
{
    private readonly SecretData _secretData;

    public SecretDataViewModel() => _secretData = new SecretData();

    public string DefaultConnection => _secretData.DefaultConnection;

    // Optional: Raise PropertyChanged if needed in future
    public event PropertyChangedEventHandler PropertyChanged;
}

