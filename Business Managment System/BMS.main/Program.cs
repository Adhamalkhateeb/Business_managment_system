using BAL;
using BMS;
using DAL;

namespace BMS.main
{
    internal static class Program
    {

        public static IDepartmentService DepartmentService { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {

            DepartmentService = new DepartmentService(new DepartmentRepositiry(new DataBaseExecuter(new SqlConnectionFactory())));

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());

        }
    }
}