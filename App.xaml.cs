using ERPConsumeAPI.Services;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ERPConsumeAPI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DataServices DataService { get; } = new DataServices();
    }

}
