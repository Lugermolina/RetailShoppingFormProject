/*  Product category of the Retail Shopping System, iteration 3
    Stored in the Categories table. The category ID is also the first digit of the product codes
    of the category (block sequence code): P1004 belongs to category 1, Groceries.
*/
namespace RetailShoppingFormProject
{
    public class Category
    {
        private int categoryId;
        private String categoryName;

        public Category(int categoryId, String categoryName)
        {
            this.categoryId = categoryId;
            this.categoryName = categoryName;
        }

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        public String CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        // Code block of the category, shown to the user, for example P1xxx
        public String GetCodeBlock()
        {
            return "P" + categoryId + "xxx";
        }
    }
}
