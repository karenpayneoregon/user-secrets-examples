
using SecretsLibrary1;
using SecretsModelsLibrary.Models;

namespace SampleApp2;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        var connectionString = SecretApplicationSettingReader
            .Instance.ReadProperty<string>(nameof(Connectionstrings), nameof(Connectionstrings.DefaultConnection));

        var mailSettings = SecretApplicationSettingReader
            .Instance.ReadSection<MailSettings>(nameof(MailSettings));
    }

}
