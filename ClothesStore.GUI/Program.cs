using ClothesStore.DAL.Context;
using ClothesStore.DAL.Repository;
using ClothesStore.GUI.StaffForms;
using Helper;
using System.Diagnostics;

namespace ClothesStore.GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new SaleMainForm());
        }
    }
}