using pushistin.Core.Repositories;
using NuGet.Protocol.Core.Types;

namespace pushistin.Models
{

    public class Cart
    {

        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product) =>
            Lines.RemoveAll(l => l.Product.ProductID == product.ProductID);
        public virtual void IncQuantityLine(Product product)
        {
            CartLine? line = Lines
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();
            line.Quantity++;

        }
        public virtual void DecQuantityLine(Product product)
        {
            CartLine? line = Lines
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();
            if (line.Quantity <= 1)
            {
                RemoveLine(product);
            }
            line.Quantity--;

        }
        public decimal ComputePriceValue() => Lines.Sum(e => e.Product.Price * e.Quantity);
        public decimal? ComputeDiscountValue() => Lines.Sum(e => e.Product.DiscountPrice * e.Quantity);
        public decimal? ComputeTotalValue()
        {
            decimal? sum = 0.0m;
            foreach(var line in Lines)
            {
                if(line.Product.DiscountPrice != null)
                {
                    sum += line.Product.DiscountPrice * line.Quantity;
                }
                else
                {
                    sum += line.Product.Price * line.Quantity;
                }
            }
            return sum;
        }
        public decimal? ComputeDiscount() => ComputePriceValue() - ComputeTotalValue();
        public virtual void Clear() => Lines.Clear();
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}
