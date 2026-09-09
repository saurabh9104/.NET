================================================================================
					  PRODUCT MANAGEMENT APPLICATION
						  README & DOCUMENTATION
================================================================================

PROJECT OVERVIEW
================================================================================
Product Management is a .NET 10 console-based application that allows users to 
manage product inventory in a MySQL database. Users can perform CRUD operations 
(Create, Read, Update, Delete) on products through an interactive menu system.


APPLICATION ARCHITECTURE & DATA FLOW
================================================================================

APPLICATION FLOW DIAGRAM
------------------------
┌─────────────────────────────────────────────────────────────────────────────┐
│                            USER INTERFACE                                   │
│                         (MainApp.cs - Console)                              │
│                          [Menu System]                                      │
└────────────────────────┬────────────────────────────────────────────────────┘
						 │
						 │ User Input (0-5 choice)
						 ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                        BUSINESS LOGIC LAYER                                 │
│                    (ProductRepository.cs)                                   │
│    • AddProduct()          → INSERT                                         │
│    • DisplayProducts()     → SELECT                                         │
│    • UpdateProduct()       → UPDATE                                         │
│    • DeleteProduct()       → DELETE                                         │
└────────────────────────┬────────────────────────────────────────────────────┘
						 │
						 │ Database Operations (SQL Queries)
						 ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                        DATA ACCESS LAYER                                    │
│                      (DBHelper.cs)                                          │
│         GetOpenConnection() → Opens MySQL Connection                        │
│              Uses Connection String                                         │
└────────────────────────┬────────────────────────────────────────────────────┘
						 │
						 │ Network/TCP Connection
						 ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                          DATABASE LAYER                                     │
│                   MySQL Server (localhost:3306)                             │
│         Database: dotnet                                                    │
│         Table: Product                                                      │
│         Storage: MySQL Data Files                                           │
└─────────────────────────────────────────────────────────────────────────────┘


PROJECT FILE STRUCTURE
================================================================================

Product_Management/
├── MainApp.cs              - Main entry point, menu system, user interface
├── ProductRepository.cs    - Business logic for CRUD operations
├── DBHelper.cs            - Database connection management
├── Product.cs             - Data model (Product class)
├── DB.cs                  - Empty file (not used)
├── Product_Management.csproj - Project configuration (NuGet packages)
└── README.txt             - This file


COMPONENT DESCRIPTIONS
================================================================================

1. MainApp.cs (User Interface Layer)
   ───────────────────────────────────
   • File Location: Product_Management/MainApp.cs
   • Entry Point: Program.Main(string[] args)

   Responsibilities:
   - Displays interactive console menu
   - Takes user input (0-5)
   - Calls appropriate methods based on user choice
   - Handles exceptions and displays error messages

   Menu Options:
   • 0 - Test Database Connection
	 └─> Tests if the database is accessible

   • 9 - List Available Databases (Diagnostic)
	 └─> Shows all databases on MySQL server

   • 1 - Add Product
	 └─> Prompts for product details and saves to database
	 └─> Required fields: Product Name, Category ID, Price, Quantity

   • 2 - Display Products
	 └─> Retrieves and displays all products from database

   • 3 - Update Product
	 └─> Updates existing product details
	 └─> Required: Product ID to update

   • 4 - Delete Product
	 └─> Deletes a product from database
	 └─> Required: Product ID to delete

   • 5 - Exit
	 └─> Closes the application


2. ProductRepository.cs (Business Logic Layer)
   ──────────────────────────────────────────
   • File Location: Product_Management/ProductRepository.cs

   Public Methods:

   a) AddProduct(Product product)
	  ├─ Receives: Product object with ProductName, CategoryId, Price, Quantity
	  ├─ Database Operation: INSERT INTO Product table
	  ├─ Error Handling: MySqlException and general Exception catch blocks
	  └─ Returns: void

   b) DisplayProducts()
	  ├─ Receives: None
	  ├─ Database Operation: SELECT * FROM Product
	  ├─ Displays: ProductId, ProductName, CategoryId, Price, Quantity, Total
	  ├─ Output: Formatted table in console
	  └─ Error Handling: MySqlException and general Exception catch blocks

   c) UpdateProduct(Product product)
	  ├─ Receives: Product object with ProductId and updated fields
	  ├─ Database Operation: UPDATE Product WHERE ProductId = @id
	  ├─ Updated Fields: ProductName, CategoryId, Price, Quantity, Total
	  ├─ Error Handling: MySqlException and general Exception catch blocks
	  └─ Returns: void

   d) DeleteProduct(int id)
	  ├─ Receives: Product ID to delete
	  ├─ Database Operation: DELETE FROM Product WHERE ProductId = @id
	  ├─ Error Handling: MySqlException and general Exception catch blocks
	  └─ Returns: void

   Data Flow in Repository:
   - Accepts data from MainApp
   - Connects to database via DBHelper.GetOpenConnection()
   - Executes SQL queries using MySqlCommand
   - Handles results (ExecuteReader for SELECT, ExecuteNonQuery for INSERT/UPDATE/DELETE)
   - Catches and logs all exceptions
   - Uses 'using' statements for automatic connection disposal


3. DBHelper.cs (Data Access Layer)
   ──────────────────────────────
   • File Location: Product_Management/DBHelper.cs

   Public Static Methods:

   a) GetOpenConnection()
	  ├─ Purpose: Creates and opens a MySQL connection
	  ├─ Connection String: 
	  │  Server=localhost;Port=3306;Database=dotnet;Uid=root;Pwd=@S123456p;Connection Timeout=30;
	  ├─ Returns: Open MySqlConnection object
	  ├─ Error Handling: 
	  │  ├─ MySqlException: Connection failures with detailed error info
	  │  ├─ General Exception: Unexpected errors
	  │  └─ Disposes connection if error occurs
	  └─ Debug Output: Connection attempt details

   b) TestConnection()
	  ├─ Purpose: Tests database connectivity without queries
	  ├─ Operation: Opens and closes connection
	  ├─ Returns: bool (true if successful, false otherwise)
	  └─ Output: Debug messages to console

   c) ListAvailableDatabases()
	  ├─ Purpose: Lists all databases on MySQL server (Diagnostic)
	  ├─ Operation: Connects to MySQL without specifying database
	  ├─ SQL Query: SHOW DATABASES
	  ├─ Output: List of database names to console
	  └─ Error Handling: Try-catch with error messages

   Connection String Components:
   ├─ Server: localhost (MySQL server address)
   ├─ Port: 3306 (MySQL default port)
   ├─ Database: dotnet (Target database name)
   ├─ Uid: root (MySQL username)
   ├─ Pwd: @S123456p (MySQL password)
   └─ Connection Timeout: 30 seconds (Wait time for connection)


4. Product.cs (Data Model)
   ────────────────────────
   • File Location: Product_Management/Product.cs

   Class: Product
   • Properties (Auto-properties):
	 ├─ ProductId (int) - Unique identifier, auto-generated by database
	 ├─ ProductName (string) - Product name/title
	 ├─ CategoryId (int) - Category identifier
	 ├─ Price (decimal) - Unit price
	 └─ Quantity (int) - Available quantity

   • Constructors:
	 ├─ Default: Product() - Empty constructor
	 └─ Parameterized: Product(int, string, int, decimal, int)

   • Purpose: Encapsulates product data for transfer between layers


DATABASE STRUCTURE
================================================================================

Database Name: dotnet
Table Name: Product

Table Schema:
┌─────────────┬──────────────┬────────┬──────────┬──────────────┐
│ Column      │ Type         │ Null   │ Key      │ Auto Increment│
├─────────────┼──────────────┼────────┼──────────┼──────────────┤
│ ProductId   │ INT          │ NO     │ PRIMARY  │ YES          │
│ ProductName │ VARCHAR(255) │ NO     │          │              │
│ CategoryId  │ INT          │ NO     │          │              │
│ Price       │ DECIMAL(10,2)│ NO     │          │              │
│ Quantity    │ INT          │ NO     │          │              │
│ Total       │ DECIMAL(10,2)│ NO     │          │              │
└─────────────┴──────────────┴────────┴──────────┴──────────────┘

Column Descriptions:
• ProductId: Unique identifier for each product (auto-generated)
• ProductName: Name of the product
• CategoryId: Reference to product category
• Price: Unit price per item
• Quantity: Number of items in stock
• Total: Calculated as (Price * Quantity)


COMPLETE DATA FLOW EXAMPLE - ADD PRODUCT
================================================================================

Step 1: User Interface (MainApp.cs)
├─ User selects "1. Add Product" from menu
├─ Application prompts for:
│  ├─ Product Name: "Laptop"
│  ├─ Category ID: "5"
│  ├─ Price: "899.99"
│  └─ Quantity: "10"
└─ Creates Product object with these values

Step 2: Business Logic (ProductRepository.cs)
├─ MainApp calls: repository.AddProduct(product)
├─ ProductRepository creates SQL query:
│  INSERT INTO Product (ProductName, CategoryId, Price, Quantity, Total)
│  VALUES ('Laptop', 5, 899.99, 10, 8999.90)
└─ Prepares parameterized query with @name, @category, @price, @quantity, @total

Step 3: Data Access (DBHelper.cs)
├─ ProductRepository calls: DBHelper.GetOpenConnection()
├─ DBHelper creates MySqlConnection with connection string
├─ Connection attempts to reach: localhost:3306
└─ Returns open connection object

Step 4: Database (MySQL Server)
├─ MySQL server receives connection request
├─ Authenticates username: root, password: @S123456p
├─ Verifies database exists: dotnet
├─ Establishes TCP connection (port 3306)
└─ Waits for queries

Step 5: Query Execution (ProductRepository.cs)
├─ ProductRepository creates MySqlCommand with query and connection
├─ Adds parameters to prevent SQL injection:
│  ├─ @name = "Laptop"
│  ├─ @category = 5
│  ├─ @price = 899.99
│  ├─ @quantity = 10
│  └─ @total = 8999.90
└─ Executes: cmd.ExecuteNonQuery()

Step 6: Database Processing (MySQL)
├─ MySQL parses INSERT statement
├─ Validates data types and constraints
├─ Generates ProductId (auto-increment)
├─ Inserts row into Product table
└─ Returns affected rows count (1)

Step 7: Response to User (MainApp.cs)
├─ ProductRepository receives successful response
├─ Catches any MySqlException (not thrown if successful)
├─ Returns to MainApp without error
├─ MainApp displays: "Product Added Successfully."
└─ User returns to menu


COMPLETE DATA FLOW EXAMPLE - DISPLAY PRODUCTS
================================================================================

Step 1: User Interface (MainApp.cs)
├─ User selects "2. Display Products" from menu
└─ Calls: repository.DisplayProducts()

Step 2: Business Logic (ProductRepository.cs)
├─ Creates SQL query: SELECT ProductId, ProductName, CategoryId, Price, Quantity, Total FROM Product
└─ Prepares to execute read operation

Step 3: Data Access (DBHelper.cs)
├─ Gets connection via: DBHelper.GetOpenConnection()
├─ Connection established to: dotnet database on localhost:3306
└─ Returns open connection

Step 4: Query Execution (ProductRepository.cs)
├─ Creates MySqlCommand with SELECT query and connection
├─ Executes: cmd.ExecuteReader()
└─ Receives DataReader object for reading results

Step 5: Database Processing (MySQL)
├─ Searches Product table for all rows
├─ Retrieves columns: ProductId, ProductName, CategoryId, Price, Quantity, Total
├─ Sends all matching rows back to application
└─ Keeps connection open for streaming data

Step 6: Data Processing (ProductRepository.cs)
├─ Loops through reader.Read() for each row:
│  ├─ Reads: ProductId (int), ProductName (string), CategoryId (int)
│  ├─ Reads: Price (decimal), Quantity (int), Total (decimal or NULL)
│  └─ Formats and displays each product as table row
├─ Handles NULL values for Total field
└─ Closes reader and connection when done

Step 7: Display to User (Console)
├─ Displays header: "ID  Name  Category  Price  Qty  Total"
├─ Displays separator line: "---------------------------------------------------------------"
├─ Shows each product as: "1  Laptop  5  899.99  10  8999.90"
└─ Returns to menu after user presses key


ERROR HANDLING FLOW
================================================================================

When Database Connection Fails:

Step 1: Connection Attempt (DBHelper.cs)
├─ Application tries to open connection
└─ MySqlException occurs (e.g., Unknown database 'dotnet')

Step 2: Exception Handling (DBHelper.cs)
├─ Catches MySqlException
├─ Disposes connection to free resources
├─ Logs detailed error information:
│  ├─ Error Number: 1049
│  ├─ Error Message: "Unknown database 'dotnet'"
│  ├─ Connection Details: Server, Port, Database, User
└─ Re-throws exception

Step 3: Repository Exception Handling (ProductRepository.cs)
├─ Catches the re-thrown MySqlException
├─ Logs database error to Console.Error:
│  └─ "Database error while inserting product: [error message]"
└─ Silently continues (returns without throwing)

Step 4: User Feedback (MainApp.cs)
├─ Operation appears to complete (message says "Added Successfully")
├─ BUT: Data was NOT actually inserted
├─ Next data display will not show the product
└─ Error messages visible only if watching console


RUNNING THE APPLICATION
================================================================================

Prerequisites:
• .NET 10 SDK installed
• MySQL Server running on localhost:3306
• MySQL Database: dotnet (must exist)
• MySQL Table: Product (must exist with proper schema)
• MySQL User: root with password @S123456p
• MySql.Data NuGet package (v9.7.0) installed

Compilation:
1. Open command prompt in project directory
2. Run: dotnet build
3. Run: dotnet run

Or using Visual Studio:
1. Open Product_Management.slnx
2. Press Ctrl+Shift+B to build
3. Press Ctrl+F5 to run

Running the Executable:
1. Navigate to: bin\Debug\net10.0\
2. Run: Product_Management.exe
3. Select option from menu (0-5)


TROUBLESHOOTING GUIDE
================================================================================

Problem: "Unknown database 'dotnet'"
Solution:
• Check database exists: mysql -h localhost -u root -p@S123456p -e "SHOW DATABASES;"
• If not exists, create: mysql -h localhost -u root -p@S123456p -e "CREATE DATABASE dotnet;"
• Then use option 9 in app to verify

Problem: "Unknown table 'Product'"
Solution:
• Check table exists: mysql -h localhost -u root -p@S123456p -D dotnet -e "SHOW TABLES;"
• If not exists, create the Product table with proper schema (see DATABASE STRUCTURE section)

Problem: "Access denied for user 'root'"
Solution:
• Verify MySQL root password in DBHelper.cs connection string
• Ensure password matches MySQL server configuration
• Test password manually: mysql -h localhost -u root -p@S123456p

Problem: "Can't connect to MySQL server on 'localhost:3306'"
Solution:
• Verify MySQL server is running
• Check if port 3306 is correct (default is 3306)
• Try: mysql -h localhost -u root (should connect)

Problem: No products display after adding
Solution:
• Check error messages in console (red text)
• Use option 0 to test database connection
• Use option 9 to list available databases
• Verify database and table exist


RELATIONSHIP BETWEEN COMPONENTS
================================================================================

Data Flow Chain:
User Input (MainApp) 
→ Business Logic (ProductRepository) 
→ Database Access (DBHelper) 
→ MySQL Server (Database)
→ Response Back (DataReader/ExecuteNonQuery)
→ Display to User (Console Output)

Dependency Chain:
MainApp depends on → ProductRepository
ProductRepository depends on → DBHelper, Product
DBHelper depends on → MySql.Data (NuGet package)
Product depends on → Nothing (standalone model)

Error Propagation Chain:
Database Error (MySQL) 
→ Caught by DBHelper (MySqlException)
→ Re-thrown to ProductRepository
→ Caught by ProductRepository
→ Logged to Console.Error
→ Dialog message to user (if applicable)


KEY CONCEPTS TO REMEMBER
================================================================================

1. Separation of Concerns
   - MainApp handles UI only
   - ProductRepository handles business logic
   - DBHelper handles database connectivity
   - Product handles data models

2. Using Statements
   - Automatically close/dispose database connections
   - Prevent connection pool exhaustion
   - Ensure resources are freed even if exceptions occur

3. Parameterized Queries
   - Uses @parameter syntax
   - Prevents SQL injection attacks
   - Parameters: @name, @category, @price, @quantity, @total, @id

4. Connection String Security
   - Currently hardcoded in DBHelper.cs
   - Should use configuration file for production
   - Password visible in source code (consider encryption)

5. Error Handling Strategy
   - Catches MySqlException for database-specific errors
   - Catches generic Exception for unexpected issues
   - Logs errors but continues execution
   - May hide failures from user


NEXT STEPS FOR IMPROVEMENT
================================================================================

1. Security:
   • Move connection string to configuration file
   • Encrypt password
   • Implement authentication/authorization

2. Error Handling:
   • Return success/failure indicators from methods
   • Implement logging framework (e.g., Serilog)
   • Show success messages consistently

3. Features:
   • Add search/filter functionality
   • Add data validation
   • Add transaction support
   • Implement pagination for large datasets

4. Testing:
   • Add unit tests for ProductRepository
   • Add integration tests for database operations
   • Add mock database for testing


DATABASE INITIALIZATION SQL
================================================================================

To create the database and table manually:

-- Create Database
CREATE DATABASE IF NOT EXISTS dotnet;

-- Use Database
USE dotnet;

-- Create Product Table
CREATE TABLE IF NOT EXISTS Product (
	ProductId INT AUTO_INCREMENT PRIMARY KEY,
	ProductName VARCHAR(255) NOT NULL,
	CategoryId INT NOT NULL,
	Price DECIMAL(10, 2) NOT NULL,
	Quantity INT NOT NULL,
	Total DECIMAL(10, 2) NOT NULL
);

-- Optional: Verify table creation
SHOW TABLES;
DESCRIBE Product;


DEPENDENCIES & VERSIONS
================================================================================

Framework: .NET 10.0
Language: C# (Latest syntax supported by .NET 10)

NuGet Packages:
• MySql.Data (v9.7.0)
  ├─ Provides MySqlConnection class
  ├─ Provides MySqlCommand class
  ├─ Provides MySqlDataReader class
  └─ Handles MySQL protocol communication

NuGet Package Reference in .csproj:
<PackageReference Include="MySql.Data" Version="9.7.0" />


FILE LOCATIONS
================================================================================

Source Code: D:\.NET\Backend\Product_Management\Product_Management\
├── MainApp.cs
├── ProductRepository.cs
├── DBHelper.cs
├── Product.cs
├── DB.cs
├── Product_Management.csproj
└── README.txt (this file)

Solution File: D:\.NET\Backend\Product_Management\Product_Management.slnx

Compiled Output: 
└── bin\Debug\net10.0\Product_Management.exe

Object Files: 
└── obj\Debug\net10.0\


CONCLUSION
================================================================================

The Product Management Application demonstrates a three-tier architecture:
1. Presentation Layer (MainApp.cs) - User interface
2. Business Logic Layer (ProductRepository.cs) - CRUD operations
3. Data Access Layer (DBHelper.cs) - Database connectivity

Data flows from user input through business logic to the database and back
to the user for display. Each layer has specific responsibilities and is
loosely coupled, making the application maintainable and testable.

For questions or issues, refer to the troubleshooting guide section above.

================================================================================
END OF README
================================================================================
