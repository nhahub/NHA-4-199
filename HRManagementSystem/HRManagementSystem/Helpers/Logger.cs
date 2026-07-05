using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Helpers
{
   public static class Logger
        {
            // ميثود ستاتيك نقدر نناديها من أي مكان في البروجيكت فوراً
            // حساب وقت حدوث اي عملية
            public static void Log(string message)
            {
                Console.WriteLine($"[LOG - {DateTime.Now:yyyy-MM-dd HH:mm}]: {message}");
            }
   }
}


