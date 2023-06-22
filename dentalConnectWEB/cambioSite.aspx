<%@ Page Title="Usuario" Language="C#" MasterPageFile="~/CRUD.Master" AutoEventWireup="true" CodeBehind="cambioSite.aspx.cs" Inherits="dentalConnectWEB.cambioSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="part1" runat="server">
    <style>
    .text-center {
        text-align: center;
    }
    .error-message {
        color: red;
    }
    .succes-message {
        color: green;
    }
    .grid-view-style {
        font-family: Segoe UI Emoji, NotoColorEmoji, Arial, sans-serif;
        border-collapse: collapse;
        width: 100%;
    }
    .grid-view-style th,
    .grid-view-style td {
        border: 1px solid #ccc;
        padding: 8px;
        text-align: left;
    }
    .grid-view-style th {
        background-color: #f2f2f2;
        font-weight: bold;
    }
    .grid-view-style tr:nth-child(even) {
        background-color: #f9f9f9;
    }
    .grid-view-style tr:hover {
        background-color: #e6e6e6;
        transition: background-color 0.3s ease;
    }
    .grid-view-style .grid-header {
        background-color: #f2f2f2;
        color: #333;
        padding: 12px;
        font-weight: bold;
        border-bottom: 2px solid #ccc;
    }
    .grid-view-style .grid-row {
        background-color: #fff;
        color: #333;
        transition: background-color 0.3s ease;
    }
    .grid-view-style .grid-row:hover {
        background-color: #f9f9f9;
    }
    .grid-view-style .grid-alternate-row {
        background-color: #f9f9f9;
        color: #333;
        transition: background-color 0.3s ease;
    }
    .grid-view-style .grid-alternate-row:hover {
        background-color: #e6e6e6;
    }
</style>


    <form ID="form2" runat="server">

             
         <div class="container">
    <div class="row justify-content-center mt-5">
        <div class="col-md-6">
            <h2 class="text-center">Cambio de Contraseña🔒</h2>
            <br>
            <form method="post" action="#">
                <div class="form-group">
                    <label for="currentPassword">Contraseña Actual</label>
                    <asp:TextBox ID="oldP" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="newPassword">Contraseña Nueva🔑</label>
                    <asp:TextBox ID="p1" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="confirmPassword">Confirmar Contraseña🔑</label>
                    <asp:TextBox ID="p2" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="message" runat="server" style="font-size:20px"></asp:Label>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Button Text="Cambiar" runat="server" ID="btn" class="form-control btn btn-primary" OnClick="Button1_Click" />
                    </div>
                    <div class="col-md-6">
                        <asp:Button Text="Cancelar" runat="server" ID="btn1" class="form-control btn btn-danger" OnClick="Button2_Click" />
                    </div>
                </div>

            </form>
        </div>
    </div>
</div>         



        
    </form>
</asp:Content>
