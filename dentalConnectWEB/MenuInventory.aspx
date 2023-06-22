<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuInventory.aspx.cs" Inherits="dentalConnectWEB.MenuInventory" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> INVENTARIO - CODENSA</title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="shortcut icon" type="image/png" href="images/logo1.png"/>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>


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

    </style>

  <nav class="navbar navbar-expand-md navbar-light" style="background-color: #32403B;">
        <a class="navbar-brand" style="font-size: 24px; color: #C9FFEB;" href="MenuSite.aspx">
          <img src="images/functions/logo1.png" alt="" width="70px" height="60px">
        </a>

        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarCollapse">
            <ul class="navbar-nav">
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="vistasDropdown" role="button"
                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"
                        style="color: #C9FFEB; text-align: center;">
                       Gestión empresarial
                    </a>
                    <div class="dropdown-menu" aria-labelledby="vistasDropdown">
                        <a class="dropdown-item" href="CategorySite.aspx"> <img src="images/functions/aplicacion.png" alt="" width="15px" height="15px"> Categorías</a>
                        <a class="dropdown-item" href="SupplierSite.aspx"> <img src="images/functions/camion.png" alt="" width="15px" height="15px"> Proveedores</a>
                        <a class="dropdown-item" href="informes.html"><img src="images/functions/documento.png" alt="" width="15px" height="15px"> Informes</a>
                    </div>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="administrarDropdown" role="button"
                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"
                        style="color: #C9FFEB; text-align: center;">
                        Gestión Comercial
                    </a>
                    <div class="dropdown-menu" aria-labelledby="administrarDropdown">
                        <a class="dropdown-item" href="productos.html"><img src="images/functions/producto.png" alt="" width="15px" height="15px">Productos</a>
                    </div>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="detallesDropdown" role="button"
                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"
                        style="color: #C9FFEB; text-align: center;">
                        Gestión de Ventas y Logística
                    </a>
                    <div class="dropdown-menu dropdown-menu-left" aria-labelledby="detallesDropdown">
                        <a class="dropdown-item" href="pais-ciudad.html"><img src="images/functions/coronavirus.png" alt="" width="15px" height="15px"> País/Ciudad</a>
                        <a class="dropdown-item" href="pedidos.html"><img src="images/functions/pedidos.png" alt="" width="15px" height="15px"> Pedidos</a>
                    </div>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="detallesDropdown" role="button"
                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"
                        style="color: #C9FFEB; text-align: center;">
                        Funciones de Usuario
                    </a>
                    <div class="dropdown-menu dropdown-menu-left" aria-labelledby="detallesDropdown">
                        <a class="dropdown-item" href="CambioSite.aspx"><img src="images/functions/i3.png" alt="" width="25px" height="25px">Cambiar Contraseña</a>
                        <a class="dropdown-item" href="Default.aspx"><img src="images/functions/salir.png" alt="" width="25px" height="25px">Salir de la Cuenta</a>
                    </div>
                </li>
            </ul>
            <h1 class="float-right" style="margin-left: 500px; color:#C9FFEB; font-weight:bold; font-size: 30px">MENU</h1>
         
        </div>
    </nav>

    <style>
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
            background-color: #89ab92;
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
            border: 5px solid rgb(76, 130, 76);
          }


          .noticias-widget{
            border: 5px solid rgb(21, 122, 116);
            border-radius: 40px;
          }
          .recordatorio-widget{
            border: 5px solid rgb(142, 197, 142);
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
                <p style="font-size: 20px;"><b>ROL: GERENTE DE INVENTARIO</b></p>
                <div class="widget recordatorio-widget" style="border-radius: 10px; padding: 20px; height: 45%; width: 100%;">
                    <h3>Recordatorio 💡</h3>
                    <p style="font-size:20px" >Revisar las existencias del inventario de enjuagues bucales.</p>
                </div>           
            </div>

            <div class="col-md-8 mt-3" style="margin-left: -1%;">
                <div class="widget tareas-widget" style="background-color:#63a98f; border-radius: 50px; padding: 20px; height: 190px; width: 500px ; margin-right: 53% ">
                  <h3>Tareas Pendientes 📝</h3>
                  <ul style="font-size:20px">
                    <li>Revisar y actualizar el inventario de productos.</li>
                    <li>Enviar cotizaciones a los clientes interesados.</li>
                  </ul>
                </div>
                <br>
                <div class="widget asuntos-widget" style="background-color:#438d88; border-radius: 50px; padding: 20px; height: 190px; width: 500px; margin-top : -33.7%; margin-left: 80%">
                  <h3>Asuntos a Revisar 👁‍🗨</h3>
                  <ul style="font-size:20px">
                    <li>Organizar para el viernes los cepillos dentales por marca y tipo.</li>
                    <li>Resolver incidencias con productos que faltan en el inventario.</li>
                  </ul>
                </div>
                <br>
                <div class="widget comentarios-widget" style="background-color:#509ABB; border-radius: 50px; padding: 20px; height: 155px; width: 158%">
                  <h3>Informes de Inventario 🗃️</h3>
                  <ul style="font-size:20px">
                    <li>Supervisar la llegada de equipamientos mecanizados odontologicos</li>
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
  

<!-- Optional JavaScript -->
<!-- jQuery first, then Popper.js, then Bootstrap JS -->

<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>


</body>
</html>
