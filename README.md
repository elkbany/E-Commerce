# E-Commerce Desktop Management System

A comprehensive Windows Forms desktop application for e-commerce operations management, built using clean architecture principles and modern .NET development practices <cite/>. The system provides separate administrative and client interfaces for complete e-commerce platform management.

## 🚀 Features

### Core Functionality
- **Product Management**: Full CRUD operations with category organization and inventory tracking
- **Order Processing**: Complete order lifecycle management with detailed tracking
- **User Management**: Role-based authentication system (Admin/Client)
- **Shopping Cart**: Real-time cart management with persistent storage
- **Category Management**: Hierarchical product categorization

### User Interfaces
- **Admin Dashboard**: Complete management interface for products, orders, users, and categories
- **Client Interface**: User-friendly shopping experience with cart and order management
- **Authentication System**: Secure login with username/email validation

## 🛠️ Technology Stack

| Component | Technology | Version |
|-----------|------------|---------|
| **Framework** | .NET | 9.0 |
| **UI Framework** | Windows Forms + Guna.UI2 | 2.0.4.7 |
| **ORM** | Entity Framework Core | 9.0.4 |
| **Database** | SQL Server | - |
| **Dependency Injection** | Microsoft.Extensions.Hosting | 9.0.4 |
| **Validation** | FluentValidation | - |
| **Object Mapping** | Mapster | - |
| **Authentication** | ASP.NET Identity Core | - | [1](#2-0) 

## 🏗️ Architecture

The application follows a clean three-layer architecture with clear separation of concerns:

```
E-Commerce.Presentation/     # Windows Forms UI Layer
├── Forms/                   # Application forms
├── UserControls/           # Reusable UI components
└── Program.cs              # Application bootstrap

E-Commerce.BL/              # Business Logic Layer
├── Contracts/              # Service interfaces
├── Implementations/        # Service implementations
├── DTOs/                   # Data Transfer Objects
└── Validators/             # FluentValidation rules

E-Commerce.DA/              # Data Access Layer
├── Context/                # Entity Framework DbContext
├── Implementations/        # Repository implementations
├── Contracts/              # Repository interfaces
└── Migrations/             # Database migrations

E-Commerce.Domain/          # Domain Models
├── Models/                 # Entity classes
└── Enums/                  # Domain enumerations
```

## 📊 Database Schema

The application uses a normalized database schema with proper foreign key relationships:

- **Users**: User accounts with role-based access
- **Categories**: Product categorization
- **Products**: Product catalog with inventory tracking
- **Orders**: Order management with status tracking
- **OrderDetails**: Order line items
- **CartItems**: Shopping cart persistence [2](#2-1) 

## 🚀 Getting Started

### Prerequisites
- .NET 9.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or later

### Installation

1. **Clone the repository**
   ```bash
   git clone [repository-url]
   cd E-Commerce
   ```

2. **Update connection string**
   
   Update the connection string in `Program.cs`: [3](#2-2) 

3. **Run database migrations**
   ```bash
   dotnet ef database update --project E-Commerce.DA --startup-project E-Commerce.Presentation
   ```

4. **Build and run**
   ```bash
   dotnet build
   dotnet run --project E-Commerce.Presentation
   ```

### Default Test Accounts

The application includes seed data with test accounts:
- **Admin Users**: Pre-configured administrative accounts
- **Client Users**: Sample customer accounts
- **Sample Data**: 16 products across 4 categories with test orders

## 🔧 Configuration

### Dependency Injection Setup

The application uses Microsoft.Extensions.Hosting for comprehensive dependency injection: [4](#2-3) 

### Database Configuration

Entity Framework is configured with SQL Server and proper cascade behaviors:
- **Restrict**: Prevents deletion of referenced entities
- **Cascade**: Allows deletion of dependent entities

## 🏛️ Design Patterns

- **Repository Pattern**: Generic and specialized repository implementations
- **Unit of Work**: Transaction coordination across repositories
- **Dependency Injection**: IoC container throughout all layers
- **Service Layer**: Business logic encapsulation
- **DTO Pattern**: Data transfer between layers
- **Validation**: FluentValidation for business rules

## 📝 Usage

### Admin Features
- Manage products, categories, and inventory
- Process and track orders
- Manage user accounts
- View comprehensive reports

### Client Features
- Browse products by category
- Add items to shopping cart
- Place and track orders
- Manage user profile

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## Notes

This README provides a comprehensive overview of the E-Commerce desktop application, highlighting its clean architecture, modern .NET practices, and comprehensive feature set. The application demonstrates enterprise-level development patterns with proper separation of concerns and extensive use of dependency injection throughout all layers <cite/>.

Wiki pages you might want to explore:
- [Overview (elkbany/E-Commerce)](/wiki/elkbany/E-Commerce#1)
