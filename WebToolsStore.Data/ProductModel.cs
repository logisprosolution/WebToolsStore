using System.Collections.Generic;
using System.Data;

namespace WebToolsStore.Data
{
    public class ProductModel
    {
        private MAS_Product _product = new MAS_Product();

        public virtual MAS_Product MAS_Product
        {
            get { return _product; }
            set { _product = value; }
        }

        private MAS_Product_Price _product_price = new MAS_Product_Price();

        public virtual MAS_Product_Price MAS_Product_Price
        {
            get { return _product_price; }
            set { _product_price = value; }
        }

        private MAS_Ingredient _ingredient = new MAS_Ingredient();

        public virtual MAS_Ingredient MAS_Ingredient
        {
            get { return _ingredient; }
            set { _ingredient = value; }
        }

        //list Ingredient
        private List<MAS_Ingredient> _masIngredientList = new List<MAS_Ingredient>();
        public virtual List<MAS_Ingredient> MasIngredientList
        {
            get { return _masIngredientList; }
            set { _masIngredientList = value; }
        }

        private string _searchText;

        public virtual string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }

        private int _categories_id;

        public virtual int Categories_Id
        {
            get { return _categories_id; }
            set { _categories_id = value; }
        }

        private int _subCategories_id;

        public virtual int SubCategories_Id
        {
            get { return _subCategories_id; }
            set { _subCategories_id = value; }
        }
        private int? wareHouseID;
        public virtual int? WareHouseID
        {
            get { return wareHouseID; }
            set { wareHouseID = value; }
        }
        private int? productID;
        public virtual int? ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
    }
}