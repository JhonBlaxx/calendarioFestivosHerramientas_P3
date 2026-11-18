# Calendario de Festivos - Aplicación Angular

Aplicación web hecha con Angular CLI que consume la API REST del proyecto `apiFestivos.presentacion`.

## Funcionalidades

- **Consulta**: validar si una fecha es festiva en un país y ver la lista de festivos de un año.
- **Festivos**: crear, listar, editar y eliminar festivos (con filtro por país).
- **Países**: crear, listar, editar y eliminar países.
- **Tipos**: crear, listar, editar y eliminar los tipos de festivo.

## Requisitos

- Node.js 20.19 o superior (también sirven 22.12+ y 24+).
- La API en ejecución en `https://localhost:7041` y la base de datos creada con los scripts de la carpeta `Scripts`.
- Certificado de desarrollo de .NET confiable en el navegador. Si el navegador no deja conectar con la API, ejecutar una vez:
  ```
  dotnet dev-certs https --trust
  ```

## Cómo ejecutar

```
cd festivos-app
npm install
npm start
```

Luego abrir http://localhost:4200

## Configuración

- La dirección de la API está en `src/app/config.ts`.
- La API tiene habilitado CORS para `http://localhost:4200`.

## Estructura

```
src/app
├── consulta/   página de consulta de festivos
├── festivos/   CRUD de festivos
├── paises/     CRUD de países
├── tipos/      CRUD de tipos de festivo
├── services/   servicios que llaman a la API
├── models.ts   interfaces (Pais, Tipo, Festivo)
└── config.ts   URL de la API
```
