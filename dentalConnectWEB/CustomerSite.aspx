<%@ Page Title="Cliente" Language="C#" MasterPageFile="~/CRUD.Master" AutoEventWireup="true" CodeBehind="CustomerSite.aspx.cs" Inherits="dentalConnectWEB.CustomerSite" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="part1" runat="server">


    <form ID="form1" runat="server">
        <div class="float-left">
            <div class="container mt-4 float-left" style="background-color: #7C9C90; border-radius: 10px; height: 735px; width: 1150px; margin-left: 15px; overflow-x: auto; overflow-y: auto;">
                <asp:DataGrid ID="gridData" runat="server" CssClass="grid-view-style" OnItemDataBound="gridData_ItemDataBound" OnItemCreated="gridData_ItemCreated" Width="100%">
                </asp:DataGrid>    
            </div>

        </div>

        <div class="float-right">
                <div class="container mt-4 float-left" style="background-color:#7C9C90; border-radius: 10px; height: 510px; width: 400px; margin-right: 15px; overflow-y: auto;">
        <h1 class="float-left">Ingresar Datos</h1>
            
                        <div class="form-group">
                            <asp:TextBox ID="ci1" runat="server" placeholder="Ingrese el CI" class="form-control" style="resize: none;"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="name" runat="server" type="text" class="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:TextBox ID="a1" runat="server" type="text" class="form-control" placeholder="Ingrese el 1er apellido"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="a2" runat="server" type="text" class="form-control" placeholder="Ingrese el 2do apellido"></asp:TextBox>
                        </div>
                        <div class="form-group">
                              <asp:TextBox ID="fecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="sex" runat="server" class="form-control">
                                <asp:ListItem Text="M" Value="M">Masculino</asp:ListItem>
                                <asp:ListItem Text="F" Value="F">Femenino</asp:ListItem>
                            </asp:DropDownList>  
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="mail" runat="server" placeholder="Ingrese el email" class="form-control" style="resize: none;"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:TextBox ID="phone1" runat="server" placeholder="Ingrese el teléfono" class="form-control" style="resize: none;"></asp:TextBox>
                        </div>
                         
                        <div class="form-group">
                            <asp:TextBox ID="nit1" runat="server" placeholder="Ingrese el NIT" class="form-control" style="resize: none;"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="bn1" runat="server" type="text" class="form-control" placeholder="Ingrese el nombre de la empresa"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="br1" runat="server" type="text" class="form-control" placeholder="Ingrese la razon social"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="shipping1" runat="server" type="text" class="form-control" placeholder="Ingrese la direccion"></asp:TextBox>
                        </div>


                        <div class="form-group text-center">
                            
                            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" CssClass="btn" Text="➕" Style="font-size: 25px; width: 100px; background-color: #4277AB; " />

                    
                            <div>
                                
                                <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" CssClass="btn" Text="💾" Style="font-size: 25px; width: 100px; background-color: #346955; " />

                                 <asp:Button ID="Button3" OnClick="Button3_Click" runat="server" CssClass="btn" Text="❌" Style="font-size: 25px; width: 100px; background-color: #346955; " />

                       
                            </div>
                        </div>
            
                </div>
        </div>
       

        <div class="float-right" ID="idDiv" runat="server" >
                <asp:Label ID="idLabel" runat="server" style="font-size:5px"></asp:Label>
              <div class="container mt-4 float-left" style="background-color: #7C9C90; border-radius: 10px; height: 210px; width: 400px; margin-right: 15px;">
                  <asp:Label ID="message" runat="server" style="font-size:20px"></asp:Label>

                  <div class="d-flex align-items-center justify-content-center" style="height: 100%;" >
                      <div class="text-center" runat="server" id="opt" >
                    <h1><p style="font-size:30px">¿Desea borrar la categoría seleccionada?</p></h1>

                    
                    <%--<asp:Button ID="yes" OnClick="yes_Click" runat="server" CssClass="btn btn-success" Text="SI" onmouseover="this.style.backgroundColor='#4CAF50'" onmouseout="this.style.backgroundColor='green'" style="width: 20%;" />--%>

                     <%--<asp:Button ID="no" OnClick="no_Click" runat="server" CssClass="btn btn-danger" Text="NO" onmouseover="this.style.backgroundColor='#FF0000'" onmouseout="this.style.backgroundColor='red'" style="width: 20%;" />
                   --%>
                  </div>
                  </div>
                  



              </div>
        </div>

        <div class="modal fade" id="confirmacionModal" tabindex="-1" aria-labelledby="confirmacionModalLabel" aria-hidden="true" >
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="confirmacionModalLabel" style="font-size:20px">Confirmación</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body" style="font-size:20px">
                        ¿Estás seguro de que deseas eliminar el registro?
                    </div>
                    <div class="modal-footer">
                        <asp:Button Text="Aceptar" ID="yes" OnClick="yes_Click" CssClass="btn btn-success" runat="server"/>
                        <asp:Button Text="Cancelar" ID="no" OnClick="no_Click" CssClass="btn btn-danger" runat="server"/>
                       
                    </div>
                </div>
            </div>
        </div>
    </form>
    

    <script>
        function mostrarModalConfirmacion() {
            $('#confirmacionModal').modal('show');
        }
    </script>



</asp:Content>
