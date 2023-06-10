<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/CRUD.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="dentalConnectWEB.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>








<asp:Content ID="Content2" ContentPlaceHolderID="part1" runat="server">
    <form ID="form1" runat="server">
        <div class="float-left">
        <div class="container mt-4 float-left" style="background-color: #7C9C90; border-radius: 10px; height: 650px; width: 1000px; margin-left: 15px;">
           <asp:GridView ID="gridData" runat="server" CssClass="grid-view-style" OnRowCreated="gridData_RowCreated">
                
           </asp:GridView>
        </div>
</div>

        <div class="float-right">
                <div class="container mt-4 float-left" style="background-color:#7C9C90; border-radius: 10px; height: 300px; width: 550px; margin-right: 15px;">

                  <h1 class="float-left" >Ingresar Datos</h1>
            
                        <div class="form-group">
                            <asp:TextBox ID="TextBox1" runat="server" type="text" class="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
                        </div>
                        <div class="form-group">

                            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Rows="4" placeholder="Ingrese el descripcion" class="form-control" style="resize: none;"></asp:TextBox>

              
                    
                        </div>
                        <div class="form-group text-center">
                            <aspButton ID="Button1" runat="server" class="btn" onmousedown="showHiddenButtons()" style="font-size: 25px; width: 100px; background-color:#386591"  >➕</aspButton>
                    
                            <div>
                        
                                <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" CssClass="btn btn-secondary hidden-button" OnClientClick="hideHiddenButtons()" Text="💾" Style="font-size: 25px; width: 100px; background-color: #346955; display: none;" />

                                 <aspButton ID="Button3" runat="server" class="btn btn-secondary hidden-button" onmousedown="hideHiddenButtons()" style="font-size: 25px; width: 100px; background-color:#3C6162; display: none;">❌</aspButton>

                       
                            </div>
                        </div>
            
                </div>
        </div>

        <div class="float-right">
              <div class="container mt-4 float-left" style="background-color: #7C9C90; border-radius: 10px; height: 325px; width: 550px; margin-right: 15px;">
                  <asp:Label ID="Label1" runat="server" style="color:red; font-size:30px">Error</asp:Label>
              </div>
        </div>
    </form>
</asp:Content>






