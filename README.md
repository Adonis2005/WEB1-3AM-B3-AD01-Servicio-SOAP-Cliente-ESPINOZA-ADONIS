# TiendaAdonis

## Descripción del Proyecto
TiendaAdonis es un servicio web basado en SOAP desarrollado con ASP.NET Core utilizando CoreWCF. El propósito del proyecto es proporcionar operaciones a través de servicios SOAP para gestionar las operaciones de una tienda, conectado a una base de datos SQL Server mediante Entity Framework Core. 

## Tecnologías Utilizadas
* **Backend:** C#, .NET 5.0, ASP.NET Core
* **Servicios SOAP:** CoreWCF
* **ORM:** Entity Framework Core 5.0
* **Base de Datos:** Microsoft SQL Server
* **Herramientas de Pruebas:** Postman (colección SOAP incluida)
* **IDE Recomendado:** Visual Studio 2019/2022 o VS Code

## Estructura del Repositorio
El proyecto está estructurado de la siguiente manera:

```text
TiendaAdonis/
├── Posman/           # Contiene la colección de Postman para probar los servicios SOAP.
├── SQL/              # Script(s) de base de datos (Basedonis.sql) para inicializar el esquema.
├── TiendaAdonis/     # Proyecto principal de ASP.NET Core / CoreWCF.
│   ├── Data/         # Contexto de base de datos (DbContext) para Entity Framework.
│   ├── Models/       # Modelos y entidades de dominio que representan las tablas de la BD.
│   ├── Services/     # Contratos e implementaciones de los servicios web (WCF/SOAP).
│   ├── appsettings.json # Archivo de configuración (Cadenas de conexión a la BD).
│   ├── Program.cs    # Punto de entrada principal de la aplicación.
│   └── Startup.cs    # Configuración de servicios e inyección de dependencias (DI).
└── TiendaAdonis.sln  # Archivo de la solución de Visual Studio.
```

## Instrucciones de Uso

Sigue estos pasos para configurar y ejecutar el proyecto localmente:

### 1. Configuración de la Base de Datos
1. Abre tu gestor de base de datos SQL Server (por ejemplo, SQL Server Management Studio).
2. Ejecuta el script `Basedonis.sql` que se encuentra en la carpeta `SQL/` para crear la base de datos y sus respectivas tablas.

### 2. Configurar la Cadena de Conexión
1. Dirígete a la carpeta `TiendaAdonis/`.
2. Abre el archivo `appsettings.json` o `appsettings.Development.json`.
3. Actualiza la cadena de conexión (Connection String) para que apunte a tu servidor de base de datos SQL Server local y a la base de datos recién creada.

### 3. Compilación y Ejecución
**Con Visual Studio:**
1. Abre el archivo `TiendaAdonis.sln` o usa el archivo `TiendaAdonis.csproj` con Visual Studio.
2. Compila la solución (`Ctrl + Shift + B`).
3. Ejecuta el proyecto presionando `F5` (con depuración) o `Ctrl + F5` (sin depuración).

**Por línea de comandos (.NET CLI):**
1. Abre una terminal y navega a la carpeta principal `TiendaAdonis/TiendaAdonis`.
2. Ejecuta el comando para instalar dependencias y levantar el servidor:
   ```bash
   dotnet build
   dotnet run
   ```

### 4. Probar los Servicios Web (SOAP)
1. Descarga e instala [Postman](https://www.postman.com/downloads/) si no lo tienes.
2. Abre Postman y ve a `File > Import`.
3. Selecciona el archivo `TiendaAdonis SOAP.postman_collection.json` ubicado en la carpeta `Posman/` del repositorio.
4. Con el proyecto en ejecución, utiliza las peticiones importadas en Postman para probar los endpoints SOAP disponibles (asegúrate de que los puertos configurados en Postman coincidan con los de tu ejecución local).
