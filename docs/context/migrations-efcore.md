# Migrations EF Core

Este runbook descreve o fluxo minimo para criar e aplicar migrations.

## Pre-requisitos

- projeto `CentavoControl.Infrastructure` compilando
- acesso ao banco configurado em `DefaultConnection`
- ferramenta EF instalada (`dotnet-ef`)

## Criar migration

```powershell
dotnet ef migrations add InitialCreate `
  --project "C:\dev\Centavo-Control\src\CentavoControl.Infrastructure\CentavoControl.Infrastructure.csproj" `
  --startup-project "C:\dev\Centavo-Control\src\CentavoControl\CentavoControl.csproj" `
  --output-dir Persistence\Migrations
```

## Aplicar migration

```powershell
dotnet ef database update `
  --project "C:\dev\Centavo-Control\src\CentavoControl.Infrastructure\CentavoControl.Infrastructure.csproj" `
  --startup-project "C:\dev\Centavo-Control\src\CentavoControl\CentavoControl.csproj"
```

## Reverter ultima migration (se necessario)

```powershell
dotnet ef migrations remove `
  --project "C:\dev\Centavo-Control\src\CentavoControl.Infrastructure\CentavoControl.Infrastructure.csproj" `
  --startup-project "C:\dev\Centavo-Control\src\CentavoControl\CentavoControl.csproj"
```

## Nota

Se houver erro de restore por feed privado, ajuste `NuGet.Config`/credenciais antes de rodar comandos EF.

