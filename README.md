# 🚀 C# Brush-Up

> **The Brush-Up**: A light yet focused exercise to refresh and renew C# skills.

---

## 📋 Table of Contents

- [🛠️ .NET CLI Commands](#️-net-cli-commands)
- [🆕 Creating New Projects](#-creating-new-projects)
- [📦 Package Management](#-package-management)
- [🗃️ Entity Framework](#️-entity-framework)
- [🏗️ Build & Run](#️-build--run)

---

## 🛠️ .NET CLI Commands

### List Available Project Templates
```bash
dotnet new list
```

---

## 🆕 Creating New Projects

### 🖥️ Console Application
```bash
dotnet new console --framework net6.0 -n CSharpDotnetCoreConsole
```

### 🌐 Web API Project
> **Note**: Use `webapi`, not `webapp`
```bash
dotnet new webapi --framework net6.0 -n Commander
```

---

## 📦 Package Management

### 🔍 Finding Packages
Visit [nuget.org](https://nuget.org) to browse available packages.

### 🎯 Essential Entity Framework Packages

| Package | Description | Link |
|---------|-------------|------|
| `Microsoft.EntityFrameworkCore` | Core EF functionality | [📦 NuGet](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/8.0.0-rc.1.23419.6) |
| `Microsoft.EntityFrameworkCore.Design` | Design-time tools | [📦 NuGet](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design) |
| `Microsoft.EntityFrameworkCore.SqlServer` | SQL Server provider | [📦 NuGet](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer) |
| `ccxt` | Cryptocurrency exchange library | [📦 NuGet](https://www.nuget.org/packages/ccxt/0.0.35-beta) |

### 📥 Installing Packages
```bash
# Example: Installing Entity Framework SQL Server provider
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0-rc.1.23419.6
```

> 💡 **Package Location**: Installed packages are stored in `C:\Users\{username}\.nuget\packages` (not in GAC like in the old days)

---

## 🗃️ Entity Framework

### 🔧 Installing EF Tools
```bash
# Install globally
dotnet tool install --global dotnet-ef

# Verify installation
dotnet ef
```

### 🔄 Database Migrations

| Command | Description |
|---------|-------------|
| `dotnet ef migrations add InitialMigration` | Create a new migration |
| `dotnet ef migrations remove` | Remove the last migration |
| `dotnet ef database update` | Apply migrations to database |

```bash
# Create initial migration
dotnet ef migrations add InitialMigration

# Remove last migration
dotnet ef migrations remove

# Update database with migrations
dotnet ef database update
```

---

## 🏗️ Build & Run

### 🔨 Building Your Project
```bash
dotnet build
```

### ▶️ Running Your Project
```bash
dotnet run
```

---

<div align="center">

**Happy Coding! 💻✨**

*Keep brushing up those C# skills!*

</div>
