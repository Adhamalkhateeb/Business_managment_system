
using BMS.BAL;
using BMS.BAL.Interface;
using BMS.DAL;
using BMS.DAL.Interfaces;
using BMS.DTOs;
using BMS.GUI.HR_System.POS;
using BMS.InfraStructure;
using BMS.InfraStructure.Core.Interfaces;
using BMS.InfraStructure.InfraStructure.interfaces;
using BMS.InfraStructure.Logging;
using BMS.Interfaces;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BMS.UI
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                ApplicationConfiguration.Initialize();

                // Resolve the main form with dependencies
                var mainForm = provider.GetRequiredService<frmMain>();
                Application.Run(mainForm);
            }

        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Infrastructure
            services.AddSingleton<IConfigReader, ConfigReader>();
            services.AddSingleton<ICryptoHelper, CryptoHelper>();
            services.AddSingleton<IStoredProcedureRunner,StoredProcedureRunner>();
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

            // Loggers
            services.AddSingleton<FileLogger>();
            services.AddSingleton<EventLogLogger>(provider =>
            {
                var fallback = provider.GetRequiredService<FileLogger>();
                return new EventLogLogger(fallback);
            });
            services.AddSingleton<DbLogger>(provider =>
            {
                var runner = provider.GetRequiredService<IStoredProcedureRunner>();
                var fallback = provider.GetRequiredService<FileLogger>();
                return new DbLogger(runner, fallback);
            });
            services.AddSingleton<ILogger>(provider =>
            {
                var db = provider.GetRequiredService<DbLogger>();
                var file = provider.GetRequiredService<FileLogger>();
                var evnt = provider.GetRequiredService<EventLogLogger>();
                IEnumerable<ILogger> loggers = new List<ILogger> { db, file, evnt };
                return new CompositeLogger(loggers);
            });


             services.AddSingleton<IFormManager, FormManager>();

            //// Repository & Services

            services.AddScoped<IDepartmentService, DepartmentService>();
       

            //DAL
           services.AddScoped<IRepository<DepartmentDTO>, DepartmentRepository>();
            services.AddScoped<IRepository<PosDTO>, PosRepository>();



            //BAL
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IPosServices, PosServices>();

            //// Forms
            services.AddTransient<frmMain>();
            services.AddTransient<frmDepartmentList>();
            services.AddTransient<frmAddEditDepartments>();
            services.AddTransient<frmPOSList>();
        }
    }
}