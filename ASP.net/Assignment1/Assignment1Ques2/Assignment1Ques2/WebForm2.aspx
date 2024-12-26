<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Assignment1Ques2.WebForm2" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Catalog</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f0f0f0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }
        .container {
            background-color: white;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 20px;
            text-align: center;
            width: 300px;
        }
        select {
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 4px;
            width: 100%;
            margin: 10px 0;
        }
        img {
            max-width: 100%;
            height: auto;
            border-radius: 8px;
            margin: 20px 0;
            transition: transform 0.3s ease;
        }
        img:hover {
            transform: scale(1.1);
        }
        button {
            padding: 12px 20px;
            font-size: 16px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        button:hover {
            background-color: #45a049;
        }
        .price-label {
            font-size: 18px;
            font-weight: bold;
            margin-top: 20px;
            color: #333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Product Catalog</h2>
            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                <asp:ListItem Text="Select a product" Value="" />
                <asp:ListItem Text="Pen" Value="product1" />
                <asp:ListItem Text="Pencil" Value="product2" />
                <asp:ListItem Text="Sharpner" Value="product3" />
                <asp:ListItem Text="Eraser" Value="product4" />
            </asp:DropDownList>

            <asp:Image ID="imgProduct" runat="server" Visible="false" Width="100%" />
            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" />
            
            <asp:Label ID="lblPrice" runat="server" CssClass="price-label" Text="" />
        </div>
    </form>
</body>
</html>

