# ECommerceApp

ECommerceApp is an ASP.NET Core MVC application for an e-commerce platform integrated with the Iyzico payment gateway.

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
    git clone https://github.com/Aaed517/asp-net-mvc-ECommerceApp.git
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

- Register a new user or log in with an existing account.
- Browse products, add them to the cart, and proceed to checkout.
- Make payments securely using the Iyzico payment gateway.
  
## Example Screenshots

![Homepage](path/to/homepage-screenshot.png)
![Product Page](path/to/product-page-screenshot.png)
![Cart Page](path/to/cart-page-screenshot.png)
![Checkout Page](path/to/checkout-page-screenshot.png)

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


## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
