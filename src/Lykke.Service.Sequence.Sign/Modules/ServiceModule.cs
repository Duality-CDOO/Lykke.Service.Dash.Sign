using Autofac;
using Common.Log;
using Lykke.Service.Sequence.Sign.Core.Services;
using Lykke.Service.Sequence.Sign.Core.Settings.ServiceSettings;
using Lykke.Service.Sequence.Sign.Services;
using Lykke.SettingsReader;

namespace Lykke.Service.Sequence.Sign.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<SequenceSignSettings> _settings;
        private readonly ILog _log;

        public ServiceModule(IReloadingManager<SequenceSignSettings> settings, ILog log)
        {
            _settings = settings;
            _log = log;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_log)
                .As<ILog>()
                .SingleInstance();

            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();

            builder.RegisterType<SequenceService>()
                .As<ISequenceService>()
                .SingleInstance()
                .WithParameter("network", _settings.CurrentValue.Network);
        }
    }
}
