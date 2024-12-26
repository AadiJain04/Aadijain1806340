using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Assignment1Ques2
{
    public partial class WebForm2 : Page
    {
        // Sample product data with product name, price, and image URL.
        private class Product
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public string ImageUrl { get; set; }
        }

        // Product data dictionary
        private static readonly Dictionary<string, Product> Products = new Dictionary<string, Product>
        {
            { "product1", new Product { Name = "Pen", Price = "$599", ImageUrl = "~/images/pen.jpg" } },
            { "product2", new Product { Name = "Pencil", Price = "$999", ImageUrl = "~/images/Pencil.jpg" } },
            { "product3", new Product { Name = "Sharpener", Price = "$199", ImageUrl = "~/images/sharpner.jpg" } },
            { "product4", new Product { Name = "Eraser", Price = "$249", ImageUrl = "~/images/eraser.jpg" } }
        };

        // On product selection change, update the image
        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProductKey = ddlProducts.SelectedValue;

            if (!string.IsNullOrEmpty(selectedProductKey) && Products.ContainsKey(selectedProductKey))
            {
                var product = Products[selectedProductKey];
                imgProduct.ImageUrl = product.ImageUrl;
                imgProduct.Visible = true; // Show the product image
            }
            else
            {
                imgProduct.Visible = false; // Hide image if no product is selected
            }
        }

        // On button click, display the product price
        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selectedProductKey = ddlProducts.SelectedValue;

            if (!string.IsNullOrEmpty(selectedProductKey) && Products.ContainsKey(selectedProductKey))
            {
                var product = Products[selectedProductKey];
                lblPrice.Text = $"Price: {product.Price}";
            }
            else
            {
                lblPrice.Text = "Please select a product.";
            }
        }
    }
}
