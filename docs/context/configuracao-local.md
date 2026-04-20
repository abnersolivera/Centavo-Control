# Configuracao Local - Infrastructure

## Connection string

A API usa `ConnectionStrings:DefaultConnection` em:

- `src/CentavoControl/appsettings.json`
- `src/CentavoControl/appsettings.Development.json`

Exemplo atual:

```text
Server=localhost,1433;Database=CentavoControlDbDev;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;Encrypt=False
```

## Dependencias

- .NET SDK compatvel com a solucao
- SQL Server local (container ou instancia local)

## Registro de DI

A camada e registrada em `Program.cs`:

```csharp
builder.Services.AddInfrastructure(builder.Configuration);
```

## Observacoes

- ajuste `DefaultConnection` por ambiente
- em CI/CD, use variavel secreta para senha
- evitar credenciais fixas em producao

