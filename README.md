# Calendario de Festivos - Herramientas de Programación III

API en .NET 8 con Entity Framework Core para consultar los días festivos de un país.

## Trabajo Desarrollado por
- Johnatan Andres Lopez

## Proyectos de la solución

- **apiFestivos.dominio (Core)**: entidades y las interfaces, tanto de los repositorios (Pais, Tipo, Festivo) como del servicio de calendario.
- **Apifestivos.infraestructura**: implementación de los repositorios con Entity Framework.
- **Taller_1_Herramientas**: proyecto Web API, controladores, implementación del servicio de calendario y configuración.

## Base de datos

Los scripts están en la carpeta `Scripts`:
1. Ejecutar `DDL_Festivos.sql` (crea la base de datos y las tablas).
2. Ejecutar `DML_Festivos.sql` (inserta los tipos, países y festivos).

Luego configurar la cadena de conexión en `Taller_1_Herramientas/appsettings.json`.

## Tipos de festivo

- 1: Fijo, no cambia de fecha.
- 2: Se traslada al lunes siguiente si no cae lunes.
- 3: Se calcula a partir del domingo de pascua.
- 4: Se calcula a partir del domingo de pascua y luego se traslada al lunes.
- 5: Se traslada al viernes siguiente si no cae viernes.

## Endpoints

CRUD normal para Pais, Tipo y Festivo:
```
GET/POST/PUT/DELETE  api/pais
GET/POST/PUT/DELETE  api/tipo
GET/POST/PUT/DELETE  api/festivo
GET  api/festivo/pais/{idPais}
```

Verificar si una fecha es festiva:
```
GET api/calendario/verificar/{idPais}/{anio}/{mes}/{dia}
```

Listar los festivos de un país en un año:
```
GET api/calendario/festivos/{idPais}/{anio}
```

## Cómo correr el proyecto

```
dotnet restore
dotnet build
dotnet run --project Taller_1_Herramientas
```

Con Swagger se puede probar en `https://localhost:7080/swagger`.
