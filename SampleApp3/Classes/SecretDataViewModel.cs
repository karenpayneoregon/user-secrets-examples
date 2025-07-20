using System.ComponentModel;
using System.Runtime.CompilerServices;
using SecretsLibrary1;
using SecretsModelsLibrary.Models;

namespace SampleApp3.Classes;

/// <summary>
/// Represents a view model that provides access to secret application settings, 
/// including connection strings and mail settings, while implementing 
/// <see cref="INotifyPropertyChanged"/> to support data binding.
/// </summary>
/// <remarks>
/// This class retrieves and manages sensitive application settings such as 
/// default connection strings and email configuration. It ensures that changes 
/// to these properties are notified to the UI or other subscribers.
/// </remarks>
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

    /// <summary>
    /// Updates the specified field with a new value and raises the <see cref="INotifyPropertyChanged.PropertyChanged"/> event
    /// if the value has changed.
    /// </summary>
    /// <typeparam name="T">The type of the field.</typeparam>
    /// <param name="field">A reference to the field to be updated.</param>
    /// <param name="value">The new value to assign to the field.</param>
    /// <param name="propertyName">
    /// The name of the property that changed. This is optional and automatically provided by the compiler
    /// when called from a property setter.
    /// </param>
    /// <returns>
    /// <c>true</c> if the field value was updated and the <see cref="INotifyPropertyChanged.PropertyChanged"/> event was raised;
    /// otherwise, <c>false</c> if the value was unchanged.
    /// </returns>
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}