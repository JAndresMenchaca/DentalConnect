<%@ Page Title="CATEGORIAS" Language="C#" MasterPageFile="~/CRUD.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="dentalConnectWEB.Default" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .error-message {
            color: #cc0000;
        }
    </style>
</asp:Content>








<asp:Content ID="Content2" ContentPlaceHolderID="part1" runat="server">
    <form ID="form1" runat="server">
        <div class="float-left">
        <div class="container mt-4 float-left" style="background-color: #7C9C90; border-radius: 10px; height: 650px; width: 1000px; margin-left: 15px;">
           <asp:DataGrid ID="gridData" runat="server" CssClass="grid-view-style" OnItemDataBound="gridData_ItemDataBound" OnItemCreated="gridData_ItemCreated" >

           </asp:DataGrid>    
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
                            
                            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" CssClass="btn" Text="➕" Style="font-size: 25px; width: 100px; background-color: #386591; " />

                    
                            <div>
                                
                                <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" CssClass="btn" Text="💾" Style="font-size: 25px; width: 100px; background-color: #346955; " />

                                 <asp:Button ID="Button3" OnClick="Button3_Click" runat="server" CssClass="btn" Text="❌" Style="font-size: 25px; width: 100px; background-color: #346955; " />

                       
                            </div>
                        </div>
            
                </div>
        </div>
       

        <div class="float-right">
                <asp:Label ID="idLabel" runat="server" style="font-size:5px"></asp:Label>
              <div class="container mt-4 float-left" style="background-color: #7C9C90; border-radius: 10px; height: 325px; width: 550px; margin-right: 15px;">
                  <asp:Label ID="message" runat="server" style="font-size:20px"></asp:Label>

                  <div class="d-flex align-items-center justify-content-center" style="height: 100%;" >
                      <div class="text-center" runat="server" id="opt" >
                    <h1><p>¿Desea borrar la categoría seleccionada?</p></h1>

                    
                    <asp:Button ID="yes" OnClick="yes_Click" runat="server" CssClass="btn btn-success" Text="SI" onmouseover="this.style.backgroundColor='#4CAF50'" onmouseout="this.style.backgroundColor='green'" style="width: 20%;" />

                     <asp:Button ID="no" OnClick="no_Click" runat="server" CssClass="btn btn-danger" Text="NO" onmouseover="this.style.backgroundColor='#FF0000'" onmouseout="this.style.backgroundColor='red'" style="width: 20%;" />
                    
                  </div>
                  </div>
                  



              </div>
        </div>
    </form>
</asp:Content>






