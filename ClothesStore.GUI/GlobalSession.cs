using ClothesStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.GUI
{
    public class GlobalSession
    {
        public static User? CurrentUser { get; set; }

        public static void Clear()
        {
            CurrentUser = null;
        }
    }
}
