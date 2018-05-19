using Main_Project;

namespace Main_Project
{
    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CalculateDiscount(TProduct product)
        {
            return product.Price;
        }

        public static void Demo()
        {
            //since book inherits from product we our generic type can be a book
            var calc1 = new DiscountCalculator<Product>();
            var calc2 = new DiscountCalculator<Book>();   
        }
    }
}