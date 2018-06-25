using Lykke.Service.Sequence.Sign.Core.Settings.ServiceSettings;
using Lykke.Service.Sequence.Sign.Core.Settings.SlackNotifications;

namespace Lykke.Service.Sequence.Sign.Core.Settings
{
    public class AppSettings
    {
        public SequenceSignSettings SequenceSignService { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
}
