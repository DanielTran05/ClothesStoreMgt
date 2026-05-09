using ClothesStore.DAL.Context;
using ClothesStore.DAL.Repository;
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

            //MOCK DATA USER
            //var userRepo = new UserRepository(new ClothesStoreContext());
            //try
            //{
            //    userRepo.MockDataUser();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Du lieu co san hoac khong the tao do bi connectionString cua DB: " + ex.Message);
            //}

            Application.Run(new LoginForm());
        }
    }
}