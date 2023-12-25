using System;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        private List<CartLine> cartLines = new List<CartLine>();

        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => cartLines;

        /// <summary>
        /// Adds a product in the cart or increments its quantity in the cart if already added
        /// </summary>
        public void AddItem(Product product, int quantity)
        {
            CartLine existingLine = cartLines.FirstOrDefault(l => l.Product.Id == product.Id);

            if (existingLine == null)
            {
                // Product not in cart, add a new CartLine
                cartLines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                // Product already in cart, increment quantity
                existingLine.Quantity += quantity;
            }
        }
        /// <summary>
        /// Removes a product from the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            cartLines.RemoveAll(l => l.Product.Id == product.Id);

        public void RemoveSingleProduct(Product product, int quantity)
        {
            CartLine existingLine = cartLines.FirstOrDefault(l => l.Product.Id == product.Id);
            if (existingLine.Quantity == 1)
            {

                cartLines.RemoveAll(l => l.Product.Id == product.Id);
            } 
            if (existingLine != null && existingLine.Quantity>1)
            {
                // Product not in cart, add a new CartLine
                existingLine.Quantity -= quantity;
            }
           
        }
     
        
        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            return cartLines.Sum(l => l.Product.Price * l.Quantity);
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {   
            double priceTotal=0.0;
            int quantity = 0;
            foreach (CartLine line in Lines) {
                quantity += line.Quantity;
                priceTotal += line.Product.Price * line.Quantity;
            }
           
            return priceTotal/ quantity;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            return cartLines.FirstOrDefault(l => l.Product.Id == productId)?.Product;
        }

        /// <summary>
        /// Get a specified cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return index >= 0 && index < cartLines.Count ? cartLines[index] : null;
        }

        /// <summary>
        /// Clears the cart of all added products
        /// </summary>
        public void Clear()
        {
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }


}