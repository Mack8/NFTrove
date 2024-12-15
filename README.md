# NFTrove - Sistema de Gestión y Venta de NFTs 🌐

## 📖 **Descripción**
**NFTrove** es una aplicación web diseñada para gestionar el ciclo de vida completo de **NFTs** (Non-Fungible Tokens), incluyendo su creación, venta, control de propiedad y consultas. Este sistema permite a los usuarios interactuar con NFTs a través de billeteras criptográficas y proporciona herramientas avanzadas para reportes y análisis.

---

## 🎯 **Objetivos**
- Facilitar la **venta de NFTs** con trazabilidad en la propiedad.
- Proveer un sistema seguro con **perfiles de usuarios** (Administrador, Procesos y Reportes).
- Generar reportes exportables y gráficos para análisis de ventas.
- Brindar una **REST API** para consultas externas.

---

## 🚀 **Características Principales**
### 1. **Mantenimientos**
- **Clientes**:
  - Creación de criptowallets con GUID, nombre, apellidos, correo, país, entre otros.
- **NFTs**:
  - Gestión de activos NFT con información como GUID, nombre, autor, valor, cantidad e imagen.
- **Tarjetas**:
  - Configuración de métodos de pago: Visa, MasterCard, American Express.
- **Países**:
  - Gestión de países con códigos ISO 3166 y descripciones.

### 2. **Procesos**
- **Venta de NFTs**:
  - Generación de facturas en PDF con detalles de la venta, incluyendo la imagen del NFT, y envío por correo electrónico.
  - Reducción automática del inventario tras cada venta.
- **Anulación de Ventas**:
  - Permite revertir una transacción y eliminar el NFT del Blockchain.
- **Cambio de Propietario**:
  - Proceso para transferir la propiedad de un NFT.

### 3. **Reportes**
- **Consulta de Propietarios de NFTs**:
  - Información del propietario por nombre del NFT, incluyendo su imagen.
- **Listado de Clientes**:
  - Exportable en formato PDF.
- **Listado de Ventas**:
  - Filtrado por rango de fechas, exportable en PDF.
- **Listado de NFTs**:
  - Incluye datos como nombre, valor, propietario actual, imagen y suma total de los activos.
- **Gráficos**:
  - Análisis de ventas por rango de fechas.

### 4. **REST API**
- **Consulta por Nombre de NFT**:
  - Retorna datos del NFT y su propietario.
- **Consulta General de NFTs**:
  - Lista todos los NFTs disponibles con GUID, nombre e imagen.

### 5. **Administración**
- Gestión de usuarios del sistema con roles:
  - **Administrador**: Acceso total.
  - **Procesos**: Acceso a mantenimientos y procesos.
  - **Reportes**: Solo puede acceder a reportes.

---

## 🛠️ **Requerimientos Técnicos**
- **Lenguaje**: C# .NET Core 8 en Visual Studio 2022.
- **Base de Datos**: SQL Server 2019, normalizada hasta 3FNBC.
- **Arquitectura**:
  - Clean Architecture.
  - Patrones de diseño: GRASP, SOLID, MVC, Repository, Unit of Work, DTO.
- **Front-End**: Bootstrap para diseño responsivo y validaciones.
- **Log de Errores**: Serilog para registros.
- **Mensajes**: Toastr o SweetAlert para alertas amigables.

---

## 📋 **Instrucciones para Ejecutar**

### 🚀 **Backend**

#### 1. **Clonar el repositorio**
```bash
git clone https://github.com/Mack8/NFTrove.git
cd NFTrove/backend

```
