# Database Diagnostic Guide

## Problem Identified
The application cannot access the MySQL database. Error message:
```
Unknown database 'dotnet'
```

## What This Means
1. Either the database 'dotnet' doesn't exist on your MySQL server
2. Or the MySQL 'root' user doesn't have permission to access it

## How to Fix It

### Option 1: Check if the database exists

Run this command on your MySQL server:

```sql
mysql -h localhost -u root -p@S123456p -e "SHOW DATABASES;"
```

Look for a database named 'dotnet' in the output.

### Option 2: If the database doesn't exist, create it

```sql
mysql -h localhost -u root -p@S123456p -e "CREATE DATABASE dotnet;"
```

### Option 3: If the database exists, verify the Product table exists

```sql
mysql -h localhost -u root -p@S123456p -D dotnet -e "SHOW TABLES;"
```

You should see a table called 'Product'.

### Option 4: If the Product table doesn't exist, create it

```sql
mysql -h localhost -u root -p@S123456p -D dotnet << EOF
CREATE TABLE Product (
	ProductId INT AUTO_INCREMENT PRIMARY KEY,
	ProductName VARCHAR(255) NOT NULL,
	CategoryId INT NOT NULL,
	Price DECIMAL(10, 2) NOT NULL,
	Quantity INT NOT NULL,
	Total DECIMAL(10, 2) NOT NULL
);
EOF
```

## Testing with the Application

After ensuring the database and table exist:

1. Run the application: `Product_Management.exe`
2. Select option `9` to see available databases
3. Select option `0` to test the connection
4. Select option `2` to display products (should be empty initially)

## Connection String Details

The application is trying to connect with these settings:
- Server: `localhost`
- Port: `3306`
- Database: `dotnet`
- User: `root`
- Password: `@S123456p`

If any of these are incorrect, update the connection string in `DBHelper.cs`:

```csharp
private static string connectionString = 
	"Server=localhost;Port=3306;Database=dotnet;Uid=root;Pwd=@S123456p;Connection Timeout=30;";
```
