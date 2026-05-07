# ERPConsumoAPI (WPF)

![.NET 10](https://img.shields.io/badge/.NET-10-blueviolet)
![C# 14](https://img.shields.io/badge/C%23-14-green)
![Architecture](https://img.shields.io/badge/Architecture-MVVM-blue)
![Database](https://img.shields.io/badge/DB-SQL_Server_2026-red)

## 📝 Descripción General

**ERPConsumoAPI** es una aplicación de escritorio de alto rendimiento desarrollada bajo el ecosistema **.NET 10**. El objetivo principal del sistema es actuar como un cliente robusto para el consumo de servicios externos (**ERPOrigenAPI**). 

La aplicación pone un énfasis crítico en la separación de responsabilidades y la mantenibilidad, utilizando el patrón de diseño **MVVM (Model-View-ViewModel)** para garantizar un desacoplamiento efectivo entre la interfaz de usuario y la lógica de negocio.

## 🛠️ Especificaciones Técnicas

* **Framework:** .NET 10
* **Lenguaje:** C# 14
* **Interfaz Gráfica:** XAML (WPF)
* **Arquitectura:** MVVM (Model-View-ViewModel)
* **Base de Datos:** SQL Server Express 2026
* **Comunicación:** REST vía HTTPS (JSON)

## 🏗️ Arquitectura de Software

La solución se estructura en cuatro capas lógicas para facilitar el escalado y las pruebas unitarias:

1.  **Views:** Definición de la UI mediante XAML. No contiene lógica de negocio, interactuando con los datos exclusivamente vía *Data Binding*.
2.  **ViewModels:** Capa de abstracción que gestiona el estado de la vista y la lógica de presentación. Implementa `INotifyPropertyChanged` para la actualización reactiva de la UI.
3.  **Services:** Capa de infraestructura encargada del consumo de APIs externas y la lógica de acceso a datos (DAL).
4.  **Models:** Representación de las entidades de negocio y POCOs (*Plain Old CLR Objects*).

## 🚀 Características Destacadas

### 1. Optimización y Refactorización
El código ha sido sometido a un análisis riguroso mediante el motor de **Visual Studio 2026**, implementando:
* **Primary Constructors:** Reducción de código boilerplate en servicios y ViewModels.
* **Baja Carga Cognitiva:** Refactorización de métodos complejos para mejorar la legibilidad y el mantenimiento a largo plazo.

### 2. Lógica de Negocio Avanzada
* **Conversión de Divisas:** Incluye un servicio especializado para la normalización de montos a **MXN**. La arquitectura es modular, permitiendo integrar en el futuro proveedores como el Banco de México (Banxico).
* **Motor de Reglas de Facturación:** Implementación lógica en `FacturasViewModel` para calcular estados dinámicos (*PENDIENTE, PARCIAL, PAGADA*) basados en la aritmética de abonos vs. total.

### 3. Comunicación de Datos
* **Serialización Nativa:** Uso de bibliotecas de alto rendimiento para el procesamiento de JSON.
* **Enfoque Funcional:** Diseño orientado al diagnóstico directo y ejecución ligera, priorizando el flujo funcional sobre la persistencia de logs masivos.

## 🔒 Seguridad y Comunicaciones

> [!IMPORTANT]
> Este proyecto está configurado actualmente para un **entorno de desarrollo controlado**.

* **Autenticación:** Acceso *Stateless* (sin estado) para facilitar el prototipado rápido.
* **Cifrado:** Comunicación sobre canales seguros **HTTPS**, procesando los payloads en JSON estándar.
* **Integridad:** Procesamiento de datos en formato original sin capas intermedias de desencriptación para maximizar la velocidad de respuesta.

## ⚠️ Observaciones Técnicas

Actualmente, el sistema no integra **Health Checks**. En entornos de producción, se recomienda implementar mecanismos de monitoreo para:
* Verificar la disponibilidad del backend (ERPOrigenAPI).
* Detectar caídas en la instancia de SQL Server.
* Gestionar escenarios de agotamiento de recursos o latencia de red.

## 💻 Requisitos de Ejecución

Para ejecutar o compilar este proyecto, se requiere:

1.  **SO:** Windows 10 o Windows 11.
2.  **Runtime:** [.NET 10 SDK](https://dotnet.microsoft.com/download).
3.  **Base de Datos:** Instancia de **SQL Server 2026** (Local o Remota).
4.  **Red:** Conectividad HTTPS activa para el consumo de la API origen.

---
*Desarrollado como prototipo funcional para integración de sistemas ERP.*
