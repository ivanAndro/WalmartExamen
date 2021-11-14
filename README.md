# Walmart
_Repositorio de exámen_
## Construido con
* SQL Server
* .Net Core 5
* Swagger 
### Despliegue
1.- Importar la base de datos incluida en _/Database_

2.- Abrir la solución _Api.CRUDPersonas_

3.- Cambiar la cadena de conexión _defaultConnection_ del _appsettings.json_ para apuntar al servidor en el que se haya importado la base de datos

4.- Ejecutar

### Uso del api
El uso del api se encuentra documentado dentro de _[HOST]/Api/swagger/index.html_

### Api
El api es un CRUD para el registro de personas.
Cuenta con 4 endpoints 
* **GET**   /api/Persona: Recupera un listado de todos los registros
* **GET**   /api/Persona/{id}: Recupera un registro de persona por id
* **POST**  /api/Persona: Agrega un registro nuevo de persona
* **PUT**   /api/Persona/{id}: Actualiza la información completa de un registro de persona por id
* **DELETE**/api/Persona/{id}: Elimina un registro de persona por id
* **GET**   /api/Persona/Buscar: Recupera los registros de personas en base a la busqueda por los siguientes parametros
  + City
  + Code Country



---
⌨️ [Héctor Iván Villa Hernández](https://github.com/ivanAndro)
