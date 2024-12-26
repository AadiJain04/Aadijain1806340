using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{

    public partial class WebForms1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = ""; // Clear the label message when page loads
        }

        // This method is for the button click event
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string familyName = txtFamilyName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string city = txtCity.Text.Trim();
            string zip = txtZip.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            string validationMessage = ValidateFields(name, familyName, address, city, zip, phone, email);

            // Check if there are validation errors
            if (string.IsNullOrEmpty(validationMessage))
            {
                lblMessage.Text = "Form Submitted Successfully!";
                lblMessage.CssClass = "success"; // Use CSS class for success
            }
            else
            {
                lblMessage.Text = validationMessage; // Show the validation message
                lblMessage.CssClass = "error"; // Use CSS class for error
            }
        }

        // Method to validate form fields
        private string ValidateFields(string name, string familyName, string address, string city, string zip, string phone, string email)
        {
            if (name.ToLower() == familyName.ToLower())
                return "Name must be different from Family Name.";

            if (address.Length < 2)
                return "Address must be at least 2 characters.";

            if (city.Length < 2)
                return "City must be at least 2 characters.";

            if (zip.Length != 5 || !IsAllDigits(zip))
                return "Zip Code must be 5 digits.";

            if (!IsValidPhoneFormat(phone))
                return "Phone must be in the format XX-XXXXXXX or XXX-XXXXXXX.";

            if (!IsValidEmail(email))
                return "E-mail is not valid.";

            return string.Empty; // Return empty if all validations pass
        }

        // Helper method to check if a string contains all digits
        private bool IsAllDigits(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        // Method to validate phone format (XX-XXXXXXX or XXX-XXXXXXX)
        private bool IsValidPhoneFormat(string phone)
        {
            return (phone.Length == 10 && phone[2] == '-' && IsAllDigits(phone.Substring(0, 2)) && IsAllDigits(phone.Substring(3))) ||
                   (phone.Length == 11 && phone[3] == '-' && IsAllDigits(phone.Substring(0, 3)) && IsAllDigits(phone.Substring(4)));
        }

        // Method to validate the email format
        private bool IsValidEmail(string email)
        {
            int atTheRate = email.IndexOf('@');
            int dotMark = email.LastIndexOf('.');
            return (atTheRate > 0 && dotMark > atTheRate + 1 && dotMark < email.Length - 1);
        }
    }
}