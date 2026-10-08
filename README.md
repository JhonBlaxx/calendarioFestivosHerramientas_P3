# Calendario de Festivos - Herramientas de Programación III

API REST en .NET 9 con Entity Framework Core y SQL Server para consultar los días festivos de un país.

## Trabajo realizado por
- Johnatan Andres Lopez

## Arquitectura

La solución (`apiFestivos.sln`) tiene 5 proyectos:

| Proyecto | Qué contiene |
|---|---|
| `apiFestivos.dominio` | Entidades (Pais, Tipo, Festivo) y DTO |
| `apiFestivos.core` | Interfaces de los repositorios y de los servicios |
| `Apifestivos.infraestructura` | DbContext y repositorios con Entity Framework |
| `apiFestivos.aplicacion` | Servicios con la lógica (CRUD, cálculo de fechas, `ServicioFechas`) |
| `apiFestivos.presentacion` | Controladores, Swagger y configuración |

## Base de datos

En la carpeta `Scripts`:
1. Ejecutar `DDL_Festivos.sql` (crea la base de datos y las tablas).
2. Ejecutar `DML_Festivos.sql` (inserta tipos, países y festivos).

La cadena de conexión está en `apiFestivos.presentacion/appsettings.json` (`FestivosConnection`).

## Cómo ejecutar

1. Abrir `apiFestivos.sln` en Visual Studio.
2. Dejar `apiFestivos.presentacion` como proyecto de inicio y ejecutar.
3. Swagger: https://localhost:7041/swagger/index.html

## Tipos de festivo

1. Fijo.
2. Se traslada al siguiente lunes.
3. Basado en el domingo de pascua.
4. Basado en el domingo de pascua y trasladado al siguiente lunes.
5. Se traslada al siguiente viernes.

## Endpoints

- CRUD: `api/pais`, `api/tipo`, `api/festivo` (además `api/festivo/pais/{idPais}`)
- Verificar fecha: `GET api/calendario/verificar/{idPais}/{anio}/{mes}/{dia}`
  - Responde `Es Festivo`, `No es festivo` o `Fecha No valida`
- Festivos de un año: `GET api/calendario/festivos/{idPais}/{anio}`
