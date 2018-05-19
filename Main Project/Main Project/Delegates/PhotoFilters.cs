using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Project.Delegates
{
    public class PhotoFilters
    {
        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Applied Contrast");
        }

        public void AdjustBrightness(Photo photo)
        {
            Console.WriteLine("Adjusted Brigtness");
        }
    }
}
