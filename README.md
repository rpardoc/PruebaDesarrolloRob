# Prueba Técnica - Gestión de Regiones y Comunas

## Descripción

Aplicación desarrollada como prueba técnica para la gestión de información geográfica de regiones y comunas.

La solución está compuesta por:

* Una API REST desarrollada con **ASP.NET Web API 2**
* Una aplicación web desarrollada con **ASP.NET MVC 5**
* Acceso a datos mediante **SQL Server**
* Arquitectura separada por capas

La aplicación permite:

* Consultar regiones.
* Consultar comunas asociadas a una región.
* Consultar el detalle de una comuna.
* Editar y actualizar información de una comuna.

---

# Tecnologías utilizadas

## Backend API

* .NET Framework 4.8
* ASP.NET Web API 2
* C#
* Swagger para documentación y pruebas de endpoints

## Frontend Web

* ASP.NET MVC 5
* Razor Views
* HTML
* Bootstrap

## Datos

* SQL Server
* Stored Procedures
* ADO.NET

---

# Estructura de la solución

```
Solución
│
├── PruebaWebApi
│   ├── Controllers
│   ├── DTO
│   ├── Services
│   └── Interfaces
│
├── PruebaWebMvc
│   ├── Controllers
│   ├── Views
│   ├── DTO
│   └── Services
│
└── DATOS
    ├── DataAccess
    ├── Entities
    ├── Interfaces
    └── Repositories
```

---

# Requisitos

Para ejecutar la solución se requiere:

* Visual Studio 2022
* .NET Framework 4.8
* SQL Server
* IIS Express

---

# Configuración Base de Datos

Configurar la cadena de conexión en:

```
Web.config
```

Ejemplo:

```xml
<connectionStrings>
  <add 
    name="BD"
    connectionString="Data Source=SERVIDOR;Initial Catalog=BASE_DATOS;Integrated Security=True"
    providerName="System.Data.SqlClient"/>
</connectionStrings>
```

---

# Ejecución del proyecto

## 1. Ejecutar API

Iniciar el proyecto:

```
PruebaWebApi
```

La API quedará disponible en:

```
https://localhost:44359/
```

Swagger:

```
https://localhost:44359/swagger
```

---

## 2. Ejecutar aplicación MVC

Iniciar el proyecto:

```
PruebaWebMvc
```

La aplicación web quedará disponible en:

```
https://localhost:44398/
```

---

# Endpoints API

## Obtener regiones

```
GET /api/region
```

Ejemplo:

```
https://localhost:44359/api/region
```

---

## Obtener comunas por región

```
GET /api/region/{idRegion}/comuna
```

Ejemplo:

```
GET /api/region/1/comuna
```

---

## Obtener detalle de comuna

```
GET /api/region/{idRegion}/comuna/{idComuna}
```

Ejemplo:

```
GET /api/region/1/comuna/2
```

Respuesta ejemplo:

```json
{
  "IdComuna": 2,
  "IdRegion": 1,
  "NombreComuna": "Maipú",
  "Superficie": 133,
  "Poblacion": 521627,
  "Densidad": 3921.25
}
```

---

## Actualizar comuna

```
POST /api/region/{idRegion}/comuna
```

Ejemplo:

```
POST /api/region/1/comuna
```

Body:

```json
{
  "IdComuna": 1,
  "NombreComuna": "Santiago Centro",
  "Superficie": 500.50,
  "Poblacion": 600000,
  "Densidad": 1200.30
}
```

---

# Funcionalidades MVC

## Regiones

Permite visualizar el listado de regiones disponibles.

Ruta:

```
/Region
```

---

## Comunas

Permite visualizar las comunas asociadas a una región.

Ruta:

```
/Region/Comunas?idRegion=1
```

---

## Edición de comuna

Permite modificar:

* Nombre
* Superficie
* Población
* Densidad

Ruta:

```
/Region/EditarComuna?idRegion=1&idComuna=1
```

---

# Validaciones implementadas

La aplicación valida:

* Nombre de comuna obligatorio.
* Superficie entre 0 y 99.999.999,99.
* Población no negativa.
* Densidad entre 0 y 99.999.999,99.

---

# Manejo de errores

La API implementa:

* Registro de eventos mediante log4net.
* Manejo de excepciones.
* Respuestas HTTP según resultado de operación.

La aplicación MVC captura errores provenientes del consumo de la API.

---

# Autor
ROBERTO PARDO CANCINO 
Prueba técnica desarrollada en C# utilizando arquitectura por capas y consumo de servicios REST.
