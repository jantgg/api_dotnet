# Documentación de la API de Libros


## Descripción
Este proyecto es una API de gestión de libros que permite a los usuarios autenticados realizar operaciones CRUD sobre una colección de libros. 
La API está construida con ASP.NET Core y utiliza autenticación JWT para proteger los endpoints.


## Requisitos Previos
Para ejecutar este proyecto necesitas tener instalado:<br>
-.NET 8 SDK<br>
-Un editor de código o IDE, como Visual Studio, VS Code con la extensión C#, o Rider.<br>


## Configuración y Ejecución
-Primero, clona el repositorio a tu máquina local usando Git:<br>
-Navega al directorio del proyecto y ejecuta el siguiente comando para iniciar la API:  dotnet run <br>
-Encontrás una breve descripción de los endpoints en: http://localhost:5042/swagger/index.html<br>
-Podrás realizar llamads a la Api en: http://localhost:5042<br>


## Uso de la API
Para interactuar con la API, puedes usar herramientas como Postman. <br>
En la carpeta Postman del repositorio puedes encontrar la colección con todas las request posibles para interactucar con la Api. <br>
Recuerda copiar el Token obtenido en el login en el resto de solicitudes como encabezado de autorización: Bearer token


