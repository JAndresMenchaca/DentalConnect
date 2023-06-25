<%@ Page Title="Empresas" Language="C#" MasterPageFile="~/CRUD.Master" AutoEventWireup="true" CodeBehind="CompanySite.aspx.cs" Inherits="dentalConnectWEB.CompanySite" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="part1" runat="server">




    <form ID="form1" runat="server">
        <div class="float-left">
            <div class="container mt-4 float-left" style="background-color: #7C9C90; border-radius: 10px; height: 735px; width: 1115px; margin-left: 15px; overflow-x: auto; overflow-y: auto;">
                <asp:DataGrid ID="gridData" runat="server" CssClass="grid-view-style" OnItemDataBound="gridData_ItemDataBound" OnItemCreated="gridData_ItemCreated" Width="100%">
                </asp:DataGrid>    
            </div>

        </div>

        <div class="float-right">
                <div class="container mt-4 float-left" style="background-color:#7C9C90; border-radius: 10px; height: 500px; width: 350px; margin-right: 15px; overflow-y: auto;">
        <h1 class="float-left">Ingresar Datos</h1>
            
                        <div class="form-group">
                            <asp:TextBox ID="nitC" runat="server" placeholder="Ingrese el NIT" class="form-control" style="resize: none;"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="nameC" runat="server" type="text" class="form-control" placeholder="Ingrese el nombre de empresa"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:TextBox ID="phoneC" runat="server" type="text" class="form-control" placeholder="Ingrese el telefono"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="searchInput" runat="server" type="text" class="form-control" placeholder="Ingrese el CI del contacto"></asp:TextBox>
                           
                            <br />
                            <asp:DropDownList ID="person" runat="server" class="form-control" style="display: none;"></asp:DropDownList>
 
                        </div>
                        <div id="map" style="width: 100%; height: 400px;"></div>                    
                       

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
                <asp:Label ID="idContact" runat="server" style="font-size:20px"></asp:Label>
              <div class="container mt-4 float-left" style="background-color: #7C9C90; border-radius: 10px; height: 210px; width: 350px; margin-right: 15px;">
                  <asp:Label ID="message" runat="server" style="font-size:20px"></asp:Label>

                  <div class="d-flex align-items-center justify-content-center" style="height: 100%;" >
                      <div class="text-center" runat="server" id="opt" >
                    <h1><p style="font-size:30px">¿Desea borrar la empresa seleccionada?</p></h1>

                    
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
                        ¿Estás seguro de que deseas eliminar la empresa?
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


    <script>
        initMap();
        var map;
        var marker;

        function initMap() {
            var myLatLng = { lat: -17.4099986092565, lng: -64.7585481494511 }; // Ubicación inicial del mapa (puede ser cualquier valor) -17.173978935567913, -64.80249346195107

            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 5,
                center: myLatLng
            });

            google.maps.event.addListener(map, 'dblclick', function (event) {
                addMarker(event.latLng);
            });
        }

        function addMarker(location) {
            if (marker) {
                marker.setMap(null); // Elimina el marcador existente si lo hay
            }

            marker = new google.maps.Marker({
                position: location,
                map: map,
                draggable: true // Permite arrastrar el marcador después de agregarlo
            });

            // Evento para capturar la ubicación seleccionada
            google.maps.event.addListener(marker, 'dragend', function (event) {
                var latitude = event.latLng.lat();
                var longitude = event.latLng.lng();
                // Aquí puedes hacer lo que desees con las coordenadas seleccionadas, como guardarlas en una base de datos o mostrarlas en pantalla
                console.log('Ubicación seleccionada - Latitud: ' + latitude + ', Longitud: ' + longitude);
                //Session("latitude") = parseFloat(latitude);
                //Session("longitude") = parseFloat(longitude);
            });

            // Imprimir coordenadas al hacer doble clic
            var latitude = location.lat();
            var longitude = location.lng();
            console.log('Ubicación seleccionada - Latitud: ' + latitude.toString() + ', Longitud: ' + longitude);
            //Session("latitude") = parseFloat(latitude);
            //Session("longitude") = parseFloat(longitude);

            $.ajax({
                type: "POST",
                url: "CompanySite.aspx/SetCoor",
                data: JSON.stringify({ lat1: latitude.toString(), lon1: longitude.toString() }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log("Valor seleccionado enviado al servidor: " + latitude + ", " + longitude);
                },
                error: function (xhr, status, error) {
                    console.log("Error al enviar el valor seleccionado al servidor.  " + xhr);
                }
            });
        }

        function getCoor(latitud, longitud) {
            var myLatLng = { lat: latitud, lng: longitud };

            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 10,
                center: myLatLng
            });

            var marker = new google.maps.Marker({
                position: myLatLng,
                map: map
            });
        }

    </script>



    
   <script>
       $.noConflict();
       jQuery(document).ready(function ($) {
           var dropdown = $("#<%= person.ClientID %>");
        var options = dropdown.find("option").map(function () {
            return {
                value: $(this).text(),
                tag: parseInt($(this).attr("value"))
            };
        }).get();

        $("[id*=searchInput]").autocomplete({
            source: options,
            select: function (event, ui) {
                var selectedValue = ui.item.tag;

                // Convertir el valor a entero
                var intValue = parseInt(selectedValue);

                console.log(selectedValue);
                // Guardar el valor como entero en el Label
                $("#<%= idContact.ClientID %>").text(intValue);

                // Realizar una llamada a servidor para asignar el valor seleccionado al código C#
                $.ajax({
                    type: "POST",
                    url: "CompanySite.aspx/SetSelectedValue",
                    data: JSON.stringify({ selectedValue: intValue }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        console.log("Valor seleccionado enviado al servidor." + intValue);
                    },
                    error: function (xhr, status, error) {
                        console.log("Error al enviar el valor seleccionado al servidor.");
                    }
                });
            }
        });
    });
   </script>














</asp:Content>

