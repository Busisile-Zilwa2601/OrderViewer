# OrderViewer ASP.NET Core MVC Application

An ASP.NET Core MVC application to manage and view orders with full CRUD operations, advanced filtering (including date range), pagination, and responsive design.

Features:
- View Orders with filtering by:
  - Order ID
  - Customer
  - Status
  - Total
  - Created Date Range
- Pagination and sorting
- Instant search JavaScript Fetch
- Responsive UI with Bootstrap
- Entity Framework Core with SQL Server
- Swagger-enabled API endpoints

- ## Getting Started
- ### 1. Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server
- Visual Studio 2022 or VS Code

- ### 2. Clone and Run

```bash
git clone https://github.com/Busisile-Zilwa2601/OrderViewer.git
cd OrderViewer
dotnet restore
dotnet ef database update --project OrderViewer.Service.OrderAPI --startup-project OrderViewer.Web
```
- ### Option 1: Visual Studio
    Set both OrderViewer.OrderAPI and OrderViewer.Web as startup projects.
    Press F5
- ### Option 2: Command Line
- In two terminals, run,
  -   cd OrderViewer.Services.OrderAPI
    -   dotnet run    
  -  cd OrderViewer.Web
    -  dotnet run
      
backend will run at: http://localhost:5100/swagger/index.html
frontend will run at: http://localhost:5181/   you shold click Order on the menu bar to view the orders

##DataBase Setup
- dotnet ef migrations add InitialCreate
- dotnet ef database update
- Connection string is located on the appsetting (OrderViewerAPI )

##Filtering & Pagination

The /OrderViewer/OrderViewerIndex endpoint supports:

Query Parameters:

OrderId: string
Customer: string
Status: string (enum)
Total: decimal
FromDate: date (yyyy-MM-dd)
ToDate: date (yyyy-MM-dd)
PageNumber: int
PageSize: int
--- Example ---
/OrderViewer/OrderViewerIndex?Customer=John&Status=Completed&FromDate=2024-01-01&ToDate=2024-12-31

