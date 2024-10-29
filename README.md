# ECommerceApp

ECommerceApp is an ASP.NET Core MVC application for an e-commerce platform integrated with the Iyzico payment gateway. This application supports both seller and customer functionalities, providing a comprehensive platform for managing products, orders, and payments.


## Technologies Used

- ASP.NET Core 8.0
- ASP.NET Core API
- MySQL
- Iyzipay API
- Ajax
- Bootstrap
- JavaScript
- jQuery


## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/cicekalan/asp-net-mvc-ECommerceApp.git
    cd ECommerceApp
    ```

2. Create `appsettings.json` file in the `ECommerceApp.Web` folder with the following content:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=DbStoreAppDb;User=YourUserName;Password=YourPassword;"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "IyzipayOptions": {
        "ApiKey": "iyzipayApiKey",
        "SecretKey": "İyzipaySecretKey",
        "BaseUrl": "https://sandbox-api.iyzipay.com"
      },
      "AllowedHosts": "*"
    }
3. Create a migration under the `ECommerceApp` directory:
    ```bash
    cd ECommerceApp
    dotnet ef migrations add InitialCreate-p ECommerceApp.Infrastructure -s ECommerceApp.Web -o Data/Migrations
    ```
    
4. Run the application:
    ```bash
    cd ECommerceApp.Web
    dotnet run
    ```

## Usage

- Register a new user or log in with an existing account. The application includes 6 predefined users created using data seeding. You can use these accounts to test the application:

    | Username           | Password      | First Name | Last Name    | 
    |--------------------|---------------|------------|--------------|
    | user1@example.com  | Password123*  | John       | Doe          |
    | user2@example.com  | Password123*  | Jane       | Smith        | 
    | user3@example.com  | Password123*  | Michael    | Johnson      | 
    | user4@example.com  | Password123*  | Emily      | Davis        | 
    | user5@example.com  | Password123*  | Daniel     | Wilson       | 
    | user6@example.com  | Password123*  | Sophia     | Martinez     |
  
- Browse products, add them to the cart, and proceed to checkout.
- Make payments securely using the Iyzico payment gateway.
  
## Example Screenshots


- Product Page: ![Product Page](screenshots/Product.png)
- MyOrder Page: ![MyOrder Page](screenshots/MyOrder.png)
- ProductSold Page: ![ProductSold Page](screenshots/ProductsSold.png)
- ShoppingCart Page: ![ShoppingCart Page](screenshots/ShoppingCart.png)

## Sample Cards for Iyzico

| Card Network     | Card Number        |
|------------------|--------------------|
| Visa             | 4766620000000001   |
| Visa             | 4603450000000000   |
| MasterCard       | 5528790000000008   |
| MasterCard       | 5400360000000003   |
| Troy             | 9792020000000001   |
| Troy             | 9792030000000000   |
| American Express | 374427000000003    |

## Directory Structure

| Directory                    | Description                                      |
|------------------------------|--------------------------------------------------|
| ECommerceApp.Core/           | Core domain models and interfaces.               |
| ├── Models/                  | Contains entity models.                          |
| ├── Interfaces/              | Contains repository interfaces.                  |
| ├── Result.cs                | Utility class for operation results.             |
| └── ECommerceApp.Core.csproj | Core project file.                               |
|                              |                                                  |
| ECommerceApp.Infrastructure/ | Implementation of repositories and database context. |
| ├── Repositories/            | Repository implementations.                      |
| ├── Services/                | Infrastructure services.                         |
| ├── Data/                    | Database context and configurations.             |
| │   ├── AppDbContext.cs      | Main database context.                           |
| │   ├── Configurations/      | Entity configurations.                           |
| └── ECommerceApp.Infrastructure.csproj | Infrastructure project file.           |
|                              |                                                  |
| ECommerceApp.Application/    | Application layer services, DTOs, and mapping profiles. |
| ├── Interfaces/              | Application service interfaces.                  |
| ├── Services/                | Application service implementations.             |
| ├── Dtos/                    | Data Transfer Objects.                           |
| ├── Mapping/                 | AutoMapper profiles.                             |
| │   ├── MappingApp.cs        | Main mapping profile.                            |
| └── ECommerceApp.Application.csproj | Application project file.                 |
|                              |                                                  |
| ECommerceApp.Web/            | Web application, including controllers, views, and static files. |
| ├── Controllers/             | MVC controllers.                                 |
| ├── Views/                   | Razor views.                                     |
| ├── Models/                  | View models.                                     |
| ├── wwwroot/                 | Static files (CSS, JS, images, etc.).            |
| │   ├── css/                 | Stylesheets.                                     |
| │   ├── js/                  | JavaScript files.                                |
| │   ├── lib/                 | Library files.                                   |
| │   └── images/              | Images.                                          |
| ├── Components/              | View components.                                 |
| ├── Program.cs               | Application entry point.                         |
| ├── appsettings.json         | Configuration file.                              |
| └── ECommerceApp.Web.csproj  | Web project file.                                |


## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
