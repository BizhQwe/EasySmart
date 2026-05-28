# EasySmart — Интернет-магазин бытовой техники

## 📖 О проекте

**EasySmart** — дипломный проект на тему
**«Разработка интернет-магазина бытовой техники»**.

Проект представляет собой веб-приложение для просмотра каталога товаров, оформления заказов и управления интернет-магазином через административную панель.

Система разработана с использованием **ASP.NET Core Blazor** и **Entity Framework Core**.

---

## ✨ Основной функционал

### Для пользователей

* Просмотр каталога товаров
* Поиск и просмотр информации о товарах
* Добавление товаров в корзину
* Оформление заказа
* Регистрация и авторизация

### Для администратора

* Управление товарами
* Управление категориями и брендами
* Просмотр заказов
* Изменение статусов заказов
* Загрузка изображений товаров

---

## ⚙️ Используемые технологии

### Backend

* ASP.NET Core
* Blazor Server
* Entity Framework Core
* MS SQL Server

### Frontend

* Razor Components
* Microsoft Fluent UI Blazor

### Дополнительно

* LINQ
* Dependency Injection
* Data Validation
* EF Core Migrations

---

## 🗄️ Структура базы данных

В проекте используются следующие сущности:

* Users
* Products
* Categories
* Manufacturers
* Orders
* OrderItems

База данных создаётся автоматически через Entity Framework Core Migrations.

---

## 🚀 Настройка проекта

### 1. Клонирование репозитория

```bash id="r1"
git clone https://github.com/your-username/EasySmart.git
cd EasySmart
```

---

### 2. Настройка базы данных

Откройте файл:

```bash id="r2"
appsettings.json
```

Измените строку подключения:

```json id="r3"
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=EasySmartDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

### 3. Применение миграций

Выполните команду:

```bash id="r4"
dotnet ef database update
```

После этого база данных будет создана автоматически.

---

### 4. Запуск проекта

```bash id="r5"
dotnet run
```

Приложение будет доступно по адресу:

```bash id="r6"
https://localhost:5001
```
