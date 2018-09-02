namespace SimplificationExercise.Exercise2
{
    public class Product
    {
        public enum ProductName { Grams, Bottle, Bag }

        public decimal Price(ProductName name, int quantity)
        {
            switch (name)
            {
                case ProductName.Grams:
                    return quantity * 6m / 100;

                case ProductName.Bottle:
                    return quantity * 3m;

                case ProductName.Bag:
                    return quantity * .2m - GetDiscount(quantity);

                default:
                    return 0m;
            }
        }

        private decimal GetDiscount(int quantity)
        {
            return quantity / 4 * .15m;
        }
    }
}
