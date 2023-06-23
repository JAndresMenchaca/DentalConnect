<%@ Page Title="MENU" Language="C#" MasterPageFile="~/CRUD.Master" AutoEventWireup="true" CodeBehind="MenuSite.aspx.cs" Inherits="dentalConnectWEB.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="part1" runat="server">

    <style>
        body {
            background-color: #C9FFEB;
            font-family: Arial, sans-serif;
        }
    
        .container {
            margin-top: 50px;
            
        }
    
        h1 {
            margin-top: 15px;
            text-align: center;
            color: #333;
            font-size: 30px
        }
    
        .navbar-brand {
            font-weight: bold;
            color: whitesmoke;
        }
    
        .navbar-nav .nav-link {
            color: whitesmoke;
        }
    
        .navbar-nav .nav-link:hover {
            color: whitesmoke;
        }
    
        #image1{
            margin-top: 90px;
        }
    
        .sub{
            margin: 15px;
            font-size: 25px;
            
        }

        .btn-primary {
            background-color: #52726C;
            border-color: #52726C;
        }

        .btn-primary:hover,
        .btn-primary:focus {
            background-color: #3e574e;
            border-color: #426458;
        }

        .content {
            background-color: #FFFFFF;
            padding: 20px;
        }

        .col-md-4 {
            width: 100%;
        }

        .noticias-widget {
            height: calc(100vh - 140px);
            background-color: #6c9a89;
            border-radius: 10px;
            padding: 20px;
        }
        

        .noticias-widget h3 {
            margin-top: 0;
        }

        .noticias-widget ul {
            height: calc(100% - 50px); /* Ajusta la altura del contenido */
            overflow-y: auto;
            margin-bottom: 0;
        }
        .recordatorio-widget {
            background-color: #A2C8B9;
            border-radius: 10px;
            padding: 20px;
            
        }
      
          .asuntos-widget{
            border: 5px solid rgb(31, 97, 96);
          }
          .comentarios-widget {
            border: 5px solid #317c9e;
          }

          .tareas-widget{
            border: 5px solid rgb(30, 84, 30);
          }


          .noticias-widget{
            border: 5px solid rgb(21, 122, 116);
            border-radius: 40px;
          }
          .recordatorio-widget{
            border: 5px solid rgb(145, 184, 145);
          }
        
    </style>

    <div class="row justify-content-center">
        <div class="col-md-3 mt-4">
            <div class="widget noticias-widget" style="height: 618px;">
                <h3 style="font-size: 40px;">Noticias 📰</h3>
                <ul style="font-size:20px">
                    <li style="margin-bottom:20px" >¡Lanzamiento de nuestro nuevo kit de blanqueamiento dental!</li>
                    <li style="margin-bottom:20px" >Participación en la Feria Internacional de Odontología.</li>
                    <li style="margin-bottom:20px" >Contratación de nuevos empleados</li>
                    <li style="margin-bottom:20px" >Llegada de nuevos equipos tecnicos odontologicos</li>
                    <!-- Agrega más noticias o novedades si es necesario -->
                </ul>
            </div>
        </div>
        <div class="col-md-8 mt-4">
            <div class="widget saludo-widget">
                <h2 style="font-size: 35px;"></h2>
                <p style="font-size: 20px;"><b>ROL: Administrador</b></p>
                <div class="widget recordatorio-widget" style="border-radius: 10px; padding: 20px; height: 45%; width: 100%;">
                    <h3>Recordatorio 💡</h3>
                    <p style="font-size:20px" >No olvides asistir a la reunión de equipo mañana a las 10:00 a.m. en la sala de conferencias.</p>
                </div>           
            </div>

            <div class="col-md-8 mt-3" style="margin-left: -1%;">
                <div class="widget tareas-widget" style="background-color:#3E8068; border-radius: 50px; padding: 20px; height: 190px; width: 500px ; margin-right: 53% ">
                  <h3>Tareas Pendientes 📝</h3>
                  <ul style="font-size:20px">
                    <li>Revisar y actualizar el inventario de productos.</li>
                    <li>Enviar cotizaciones a los clientes interesados.</li>
                  </ul>
                </div>
                <br>
                <div class="widget asuntos-widget" style="background-color:#578B8D; border-radius: 50px; padding: 20px; height: 190px; width: 500px; margin-top : -33.7%; margin-left: 80%">
                  <h3>Asuntos a Revisar 👁‍🗨</h3>
                  <ul style="font-size:20px">
                    <li>Verificar la calidad de los últimos lotes de productos recibidos.</li>
                    <li>Resolver incidencias con los proveedores de materiales.</li>
                  </ul>
                </div>
                <br>
                <div class="widget comentarios-widget" style="background-color:#509ABB; border-radius: 50px; padding: 20px; height: 155px; width: 158%">
                  <h3>Comentarios de empleados 💬</h3>
                  <ul style="font-size:20px">
                    <li>Solicitud de aumento de salario.</li>
                    <li>Petición de aumento del plazo de entrega del siguiente informe.</li>
                    <br>                 
                  </ul>
                </div>              
              </div>
              
              
        </div>
        
    </div>


    <script>
        function getSaludo() {
            var hora = new Date().getHours();
            var saludo = '';

            if (hora >= 6 && hora < 12) {
                saludo = '¡Buenos días! ⛅';
            } else if (hora >= 12 && hora < 18) {
                saludo = '¡Buenas tardes! 🌇';
            } else {
                saludo = '¡Buenas noches! 🌔';
            }

            return saludo;
        }

        document.addEventListener('DOMContentLoaded', function () {
            var saludo = getSaludo();
            var saludoWidget = document.querySelector('.saludo-widget h2');
            saludoWidget.textContent = saludo;
        });

    </script>
    <script>
        history.pushState(null, null, location.href);
        window.onpopstate = function () {
            history.go(1);
        };
    </script>
</asp:Content>
