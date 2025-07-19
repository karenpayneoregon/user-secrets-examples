using System.ComponentModel;
using System.Runtime.CompilerServices;
using SecretsLibrary1;
using SecretsModelsLibrary.Models;

namespace SampleApp3.Classes;

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
        set => SetField(ref _defaultConnection, value);
    }

    private string _fromAddress;
    public string FromAddress
    {
        get => _fromAddress;
        set => SetField(ref _fromAddress, value);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}