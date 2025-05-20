using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp1.ViewModels;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using WpfApp1.Workers;
using WpfApp1.Views;
using WpfApp1.Views.Communication;
using WpfApp1.ViewModels.Communication;
using WpfApp1.Services;
using SqlSugar;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    private IHost _host;

    public static IContainerProvider Provider { get; private set; }

    protected override Window CreateShell()
    {
        Provider = Container;
        return Container.Resolve<MainWindow>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
    }

    protected override IContainerExtension CreateContainerExtension()
    {
        var hostBuilder = Host.CreateApplicationBuilder();
        var services = hostBuilder.Services
             .AddSingleton<IEventAggregator, EventAggregator>()
             .AddHostedService<ReceiveWorker>()
             .AddHostedService<SendWorker>();

        services.AddSingleton<ISqlSugarClient>((pro) => new SqlSugarScope(new ConnectionConfig()
        {
            DbType = SqlSugar.DbType.MySql,
            ConnectionString = "server=39.106.54.114;port=3306;database=sakila;user id=stark;password=260963hzw.;",
            IsAutoCloseConnection = true,
        }));

        services.AddDbContext<MySqlDbContext>(options =>
        {
            options.UseMySQL("server=39.106.54.114;port=3306;database=sakila;user id=stark;password=260963hzw.;");
        });

        _host = hostBuilder.Build();

        _host.StartAsync();
        //使用DI
        var container = new Container(CreateContainerRules());
        container.WithDependencyInjectionAdapter(services);
        var rs = new DryIocContainerExtension(container);
        return rs;
    }
    protected override Rules CreateContainerRules()
    {
        return Rules.Default.WithConcreteTypeDynamicRegistrations(reuse: Reuse.Transient)
                            .With(Made.Of(FactoryMethod.ConstructorWithResolvableArguments))
                            .WithFuncAndLazyWithoutRegistration()
                            .WithTrackingDisposableTransients()
                            //.WithoutFastExpressionCompiler()
                            .WithFactorySelector(Rules.SelectLastRegisteredFactory());
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<SharedDataView, SharedDataViewModel>();
        containerRegistry.RegisterForNavigation<MessageQueueView, MessageQueueViewModel>();
        containerRegistry.RegisterForNavigation<PipeStreamView, PipeStreamViewModel>();
        containerRegistry.RegisterForNavigation<DelegateView, DelegateViewModel>();
        containerRegistry.RegisterForNavigation<RefreshDataView, RefreshDataViewModel>();
        containerRegistry.RegisterForNavigation<SqlSugarStageView, SqlSugarStageViewModel>();
        containerRegistry.RegisterForNavigation<EFCoreView, EFCoreViewModel>();
        containerRegistry.RegisterForNavigation<HandyControlView, HandyControlViewModel>();

        containerRegistry.RegisterSingleton<IConsoleStrategy, HelloConsoleStrategy>("hellow");
        containerRegistry.RegisterSingleton<IConsoleStrategy, HiConsoleStrategy>("hi");
    }

}
