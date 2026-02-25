# PracticaEmpleadosMaui

Aplicacion .NET MAUI para gestionar empleados y departamentos, consumiendo una API REST local. Incluye vistas de listado, detalle, creacion, edicion y eliminacion, ademas de una grafica por departamentos.

## Capturas
![Pantalla 1](PracticaEmpleadosMaui/Captura%20de%20pantalla%202026-02-25%20224310.png)
![Pantalla 2](PracticaEmpleadosMaui/Captura%20de%20pantalla%202026-02-25%20224512.png)

## Funcionalidades
- CRUD de empleados (crear, editar, eliminar, ver detalle).
- CRUD de departamentos (crear, editar, eliminar, ver detalle).
- Grafica circular con cantidad de empleados por departamento.
- Pantalla de configuracion para cambiar el tema (Sistema/Claro/Oscuro).

## Tecnologias utilizadas
- .NET MAUI (proyecto unico multi-plataforma).
- MVVM con CommunityToolkit.Mvvm.
- LiveChartsCore + SkiaSharp para graficas.

## Requisitos
- .NET SDK compatible con `net10.0`.
- Workload de MAUI instalado.
- API REST disponible en `http://localhost:8085`.

## Configuracion de API
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

```
PracticaEmpleadosMaui/
  Models/          # Entidades (Employee, Department)
  Service/         # Servicios de consumo REST
  ViewModels/      # Logica de presentacion y comandos
  Views/           # Pantallas XAML
  Resources/       # Estilos, fuentes e imagenes
  Platforms/       # Configuracion especifica por plataforma
  App.xaml
  AppShell.xaml
  MauiProgram.cs
  PracticaMaui.csproj
```

## Notas
- La grafica usa los datos de empleados y departamentos para agrupar por `DepartmentId`.
- La navegacion principal esta definida en `PracticaEmpleadosMaui/AppShell.xaml`.
