<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="dentalConnectWEB.Default" %>

<!DOCTYPE html>
<html>

<head>
  <title>Iniciar Sesión - CODENSA</title>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
  <link rel="shortcut icon" type="image/png" href="images/logo1.png"/>
  <style>
    .button-style {
              display: inline-block;
              padding: 10px 20px;
              background-color: #112c52;
              color: white;
              text-decoration: none;
              border-radius: 4px;
              border: none;
              cursor: pointer;
              font-size:25px;
              width:140px;
            }

    body {
      font-family: Arial, sans-serif;
      margin: 0;
      padding: 0;
      background-color: #C9FFEB;
    }

    .header {
      background-color: #32403B;
      color: #C9FFEB;
      padding: 20px;
      text-align: center;
    }

    .header h1 {
      font-size: 60px;
      line-height: 1.2;
    }

    .container {
      margin-top: 100px;
    }

    .card {
      background-color: #FFFFFF;
      border-radius: 20px;
      overflow: hidden; /* Agregamos esto para que los bordes suavizados sean visibles */
    }

    .card-header {
      background-color: #32403B;
      color: #C9FFEB;
      border-radius: 20px 20px 0 0;
    }

    .btn-primary {
      background-color: #52726C;
      border-color: #52726C;
    }

    .btn-primary:hover,
    .btn-primary:focus {
      background-color: #32403B;
      border-color: #32403B;
    }

    .transparent-cyan-text {
      color: rgba(57, 136, 136, 0.7); /* Color cian semi transparente */
    }
    

  </style>
</head>

<body>
  <div class="header">
    <h1 class="display-1">CODENSA</h1>
  </div>

  <div class="container">
    <div class="row justify-content-center">
      <div class="col-md-6">
        <div class="card">
          <div class="card-header">
            <h4>Iniciar sesión</h4>
          </div>
          <div class="card-body">
            <div class="row">
              <div class="col-md-4">
                <img src="images/logo1.png" width="100%" height="auto">
              </div>
              <div class="col-md-8">
                <form action="index.html">
                  <div class="form-group">
                    <label for="username">Nombre de usuario:</label>
                    <input type="text" class="form-control" id="username" required>
                  </div>
                  <div class="form-group">
                    <label for="password">Contraseña:</label>
                    <input type="password" class="form-control" id="password" required>
                  </div>
                    <p id="message" style="color:red"> </p>
                  <a class="dropdown-item button-style" href="#" onclick="verificarDatos()">Ingresar</a>

                <script>
                    function verificarDatos() {
                        var username = document.getElementById("username").value;
                        var password = document.getElementById("password").value;

                        // Envía los datos al servidor utilizando AJAX para realizar la verificación
                        $.ajax({
                            type: "POST",
                            url: "Default.aspx/VerificarDatos",
                            data: JSON.stringify({ username: username, password: password }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                if (response.d) {
                                    // Los datos son válidos, determina la página de inicio según el tipo de usuario
                                    switch (response.d) {
                                        case "Administrador":
                                            window.location.href = "MenuSite.aspx";
                                            break;
                                        case "Gerente de ventas":
                                            window.location.href = "MenuSales.aspx";
                                            break;
                                        case "Gerente de inventario":
                                            window.location.href = "MenuInventory.aspx";
                                            break;
                                        default:
                                            // Tipo de usuario no válido, muestra un mensaje de error o realiza otra acción
                                            document.getElementById("message").textContent = "Tipo de usuario no válido";
                                            break;
                                    }
                                } else {
                                    // Los datos son inválidos, muestra un mensaje de error o realiza otra acción
                                    document.getElementById("message").textContent = "Los datos no son correctos";

                                }
                            }

                        });
                    }
                </script>




                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <script>
    // Lógica de autenticación
  </script>
  
  <footer class="footer">
    <div class="container" style="margin-top: 400px;">
      <p class="text-center transparent-cyan-text">POWERED BY QUANTUMBYTE</p>
    </div>
  </footer>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

</body>

</html>
