using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Project.Delegates
{
    public class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Photo photo);

        public void Process(string photoPath, PhotoFilterHandler filterHandler)
        {
            var photo = new Photo(photoPath);
            filterHandler(photo); //this executes the group of functions pointed to by the delegate on the photo
            //so long as they have the signature defined above
        }

        public static void Demo()
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            PhotoFilterHandler handler;
            handler = filters.ApplyContrast;
            handler += filters.AdjustBrightness;
            handler += SomeOtherFilter;
            processor.Process("123.jpg", handler);
        }

        public static void SomeOtherFilter(Photo photo)
        {
            Console.WriteLine("Do something else to the photo");
        }
    }
}
