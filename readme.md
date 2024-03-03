# Documentación de la API de Libros


## Descripción
Este proyecto es una API de gestión de libros que permite a los usuarios autenticados realizar operaciones CRUD sobre una colección de libros. 
La API está construida con ASP.NET Core y utiliza autenticación JWT para proteger los endpoints.


## Requisitos Previos
Para ejecutar este proyecto necesitas tener instalado:
-.NET 8 SDK
-Un editor de código o IDE, como Visual Studio, VS Code con la extensión C#, o Rider.


## Configuración y Ejecución
-Primero, clona el repositorio a tu máquina local usando Git:
-Navega al directorio del proyecto y ejecuta el siguiente comando para iniciar la API:  dotnet run 
-Encontrás una breve descripción de los endpoints en: http://localhost:5042/swagger/index.html
-Podrás realizar llamads a la Api en: http://localhost:5042


## Uso de la API
Para interactuar con la API, puedes usar herramientas como Postman. 
En la carpeta Postman del repositorio puedes encontrar la colección con todas las request posibles para interactucar con la Api. 
Recuerda copiar el Token obtenido en el login en el resto de solicitudes como encabezado de autorización: Bearer token


