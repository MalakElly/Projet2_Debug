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
        // Field to store cart lines
        private List<CartLine> cartLines = new List<CartLine>();

        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => cartLines;

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            return cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increments its quantity in the cart if already added
        /// </summary>
        public void AddItem(Product product, int quantity)
        {
            // Search if the product is already in the cart
            var existingLine = cartLines.FirstOrDefault(l => l.Product.Id == product.Id);

            if (existingLine != null)
            {
                existingLine.Quantity += quantity;
            }
            else
            {
                // Add a new line to the cart
                cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }

            System.Diagnostics.Debug.WriteLine(cartLines);
        }

        /// <summary>
        /// Removes a product from the cart
        /// </summary>
        public void RemoveLine(Product product)
        {
            cartLines.RemoveAll(l => l.Product.Id == product.Id);
        }

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO: Implement logic to calculate the total value of the cart
            double totalValue = 0.0;

            foreach (var cartLine in cartLines)
            {
                totalValue += cartLine.Product.Price * cartLine.Quantity;
            }

            return totalValue;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO: Implement logic to calculate the average value of the cart
            double averageValue = 0.0;

            if (cartLines.Count > 0)
            {
                double totalValue = GetTotalValue();
                averageValue = totalValue / cartLines.Count;
            }

            return averageValue;
        }

        /// <summary>
        /// Looks for a given product in the cart and returns it if found
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
             var cartLine = cartLines.FirstOrDefault(l => l.Product.Id == productId);

             return cartLine?.Product;
            
            //if it is not null
           /* List<CartLine> cartLines = GetCartLineList();
            foreach (var cartLine in cartLines) {
                if (cartLine.Product.Id == productId)
                {
                    return cartLine.Product;
                }
                else {
                    return null;
                }*/
            }
                    
           
       

        /// <summary>
        /// Get a specified cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears the cart of all added products
        /// </summary>
        public void Clear()
        {
            cartLines.Clear();
        }
    }

    /// <summary>
    /// Represents a line in the cart
    /// </summary>
    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
