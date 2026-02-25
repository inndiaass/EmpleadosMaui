# PracticaEmpleadosMaui

Aplicación .NET MAUI para gestionar empleados y departamentos, consumiendo una API REST local. Incluye vistas de listado, detalle, creación, edición y eliminación, además de una gráfica por departamentos.

## Funcionalidades
- CRUD de empleados (crear, editar, eliminar, ver detalle).
- CRUD de departamentos (crear, editar, eliminar, ver detalle).
- Gráfica circular con cantidad de empleados por departamento.
- Pantalla de configuración para cambiar el tema (Sistema/Claro/Oscuro).

## Stack
- .NET MAUI (proyecto único multi-plataforma).
- MVVM con CommunityToolkit.Mvvm.
- LiveChartsCore + SkiaSharp para gráficas.

## Requisitos
- .NET SDK compatible con `net10.0`.
- Workload de MAUI instalado.
- API REST disponible en `http://localhost:8085`.

## Configuración de API
Los endpoints se encuentran en:
- `PracticaEmpleadosMaui/Service/EmployeeService.cs` (`http://localhost:8085/employees`)
- `PracticaEmpleadosMaui/Service/DepartmentService.cs` (`http://localhost:8085/departments`)

Si tu API corre en otro host/puerto, actualiza `BaseUrl` en ambos servicios.

## Ejecutar en Windows
Desde la carpeta del proyecto:

```powershell
dotnet workload install maui
dotnet build
dotnet run -f net10.0-windows10.0.19041.0
```

## Estructura del proyecto
- `PracticaEmpleadosMaui/Models`: entidades `Employee` y `Department`.
- `PracticaEmpleadosMaui/Service`: servicios de consumo REST.
- `PracticaEmpleadosMaui/ViewModels`: lógica de presentación y comandos.
- `PracticaEmpleadosMaui/Views`: pantallas XAML.
- `PracticaEmpleadosMaui/Resources`: estilos, fuentes e imágenes.

## Notas
- La gráfica usa los datos de empleados y departamentos para agrupar por `DepartmentId`.
- La navegación principal está definida en `PracticaEmpleadosMaui/AppShell.xaml`.
