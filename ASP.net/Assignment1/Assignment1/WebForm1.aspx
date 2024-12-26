<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm1.aspx.cs" Inherits="Validator" %>
 
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Validator</title>
<style>
 
        body {
 
            font-family: Arial, sans-serif;
 
            margin: 0;
 
            padding: 0;
 
        }
 
        .container {
 
            width: 400px;
 
            margin: 50px auto;
 
            border: 1px solid #ddd;
 
            padding: 20px;
 
            border-radius: 5px;
 
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
 
        }
 
        h2 {
 
            text-align: center;
 
            margin-bottom: 20px;
 
        }
 
        .form-group {
 
            margin-bottom: 15px;
 
        }
 
        .form-group label {
 
            display: block;
 
            margin-bottom: 5px;
 
        }
 
        .form-group input[type="text"] {
 
            width: 100%;
 
            padding: 10px;
 
            border: 1px solid #ccc;
 
            border-radius: 3px;
 
        }
 
        .btn-check {
 
            background-color: #4CAF50;
 
            color: white;
 
            padding: 10px 20px;
 
            text-align: center;
 
            text-decoration: none;
 
            font-size: 16px;
 
            cursor: pointer;
 
            border-radius: 5px;
 
            margin-top: 10px;
 
            border: none;
 
        }
 
        .btn-check:hover {
 
            background-color: #45A049;
 
        }
 
        .error {
 
            color: red;
 
            font-size: 12px;
 
        }
 
        .message {
 
            margin-top: 15px;
 
            font-weight: bold;
 
        }
</style>
</head>
<body>
<div class="container">
<h2>Insert your details</h2>
<form id="form1" runat="server">
 
<div class="form-group">
<asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
</div>
<!-- Name -->
<div class="form-group">
<label for="txtName">Name: *</label>
<asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." CssClass="error" />
</div>
<!-- Family Name -->
<div class="form-group">
<label for="txtFamilyName">Family Name: * (differs from name)</label>
<asp:TextBox ID="txtFamilyName" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvFamilyName" runat="server" ControlToValidate="txtFamilyName" ErrorMessage="Family Name is required." CssClass="error" />
<asp:CompareValidator ID="cvFamilyName" runat="server" ControlToValidate="txtFamilyName" ControlToCompare="txtName" Operator="NotEqual" ErrorMessage="Family Name must differ from Name." CssClass="error" />
</div>
<!-- Address -->
<div class="form-group">
<label for="txtAddress">Address: * (at least 2 chars)</label>
<asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required." CssClass="error" />
<asp:RegularExpressionValidator ID="revAddress" runat="server" ControlToValidate="txtAddress" ValidationExpression=".{2,}" ErrorMessage="Address must be at least 2 characters." CssClass="error" />
</div>
<!-- City -->
<div class="form-group">
<label for="txtCity">City: * (at least 2 chars)</label>
<asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity" ErrorMessage="City is required." CssClass="error" />
<asp:RegularExpressionValidator ID="revCity" runat="server" ControlToValidate="txtCity" ValidationExpression=".{2,}" ErrorMessage="City must be at least 2 characters." CssClass="error" />
</div>
<!-- Zip Code -->
<div class="form-group">
<label for="txtZip">Zip Code: * (5 digits)</label>
<asp:TextBox ID="txtZip" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="txtZip" ErrorMessage="Zip Code is required." CssClass="error" />
<asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip" ValidationExpression="^\d{5}$" ErrorMessage="Zip Code must be 5 digits." CssClass="error" />
</div>
<!-- Phone -->
<div class="form-group">
<label for="txtPhone">Phone: * (xx-xxxxxxxx / xxx-xxxxxxxx)</label>
<asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone number is required." CssClass="error" />
<asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone" ValidationExpression="^\d{2}-\d{8}$|^\d{3}-\d{8}$" ErrorMessage="Invalid phone format." CssClass="error" />
</div>
<!-- Email -->
<div class="form-group">
<label for="txtEmail">E-Mail: *</label>
<asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="E-mail is required." CssClass="error" />
<asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" ErrorMessage="Invalid email format." CssClass="error" />
</div>
<!-- Validation Summary -->
<asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Validation Errors:" CssClass="error" />
<!-- Submit Button -->
<asp:Button ID="btnCheck" runat="server" Text="Check" CssClass="btn-check" OnClick="btnCheck_Click" />
 
</form>
</div>
</body>
</html>