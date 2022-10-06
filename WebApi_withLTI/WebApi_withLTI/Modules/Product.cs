using System.ComponentModel.DataAnnotations;

namespace WebApi_withLTI.Modules
{
    public class Product
    {
        [Key]
        public int Product_Id {  get; set; }

        public string Product_Name { get; set; }

        public decimal Product_Price { get; set; }
        public int Category_Id { get; internal set; }
    }
}
