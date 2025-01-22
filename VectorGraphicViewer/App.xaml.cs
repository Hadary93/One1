using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Microsoft.Extensions.DependencyInjection;
using VectorGraphicViewer.Model.Converters;
using VectorGraphicViewer.Model.Repositories;
using VectorGraphicViewer.ModelView;

namespace VectorGraphicViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider? ServiceProvider { get; private set; }

        public App()
        {
            var services = new ServiceCollection();

            services.AddSingleton<JsonRepository>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>(); 
            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = ServiceProvider?.GetRequiredService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
