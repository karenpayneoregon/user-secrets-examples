using System.ComponentModel;
using SecretsLibrary1;
using SecretsModelsLibrary.Models;

namespace SampleApp3;

public class SecretDataViewModel : INotifyPropertyChanged
{
    public SecretDataViewModel()
    {
        
        
        _defaultConnection = SecretApplicationSettingReader.Instance.ReadProperty<string>(nameof(Connectionstrings), nameof(Connectionstrings.DefaultConnection));

        var mailSettings = SecretApplicationSettingReader.Instance.ReadSection<MailSettings>(nameof(MailSettings));
        _fromAddress = mailSettings.FromAddress;
    }

    private string _defaultConnection;
    public string DefaultConnection
    {
        get => _defaultConnection;
        set
        {
            if (_defaultConnection == value) return;
            _defaultConnection = value;
            OnPropertyChanged(nameof(DefaultConnection));
        }
    }

    private string _fromAddress;
    public string FromAddress
    {
        get => _fromAddress;
        set
        {
            if (_fromAddress == value) return;
            _fromAddress = value;
            OnPropertyChanged(nameof(FromAddress));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}