<%@ Page Title="CAMBIO DE CONTRASEÑA" Language="C#" MasterPageFile="~/CRUD.Master" AutoEventWireup="true" CodeBehind="cambioSite.aspx.cs" Inherits="dentalConnectWEB.cambioSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="part1" runat="server">
    <form ID="form2" runat="server">

        <asp:TextBox ID="oldP" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>

        <asp:TextBox ID="p1" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>

        <asp:TextBox ID="p2" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>

        <asp:Button Text="Cambiar" runat="server" ID="btn" class="form-control btn btn-primary" OnClick="Button1_Click" />

        <div class="float-right">
                <asp:Label ID="idLabel" runat="server" style="font-size:5px"></asp:Label>
              <div class="container mt-4 float-left" style="background-color: #7C9C90; border-radius: 10px; height: 305px; width: 500px; margin-right: 15px;">
                  <asp:Label ID="message" runat="server" style="font-size:20px"></asp:Label>

                 
                  </div>
                  



              </div>
        </div>
    </form>
</asp:Content>
