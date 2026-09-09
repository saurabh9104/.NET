# Repository Pattern - CRUD Operations

## Generic Repository (IGenericRepository<T>)

All repositories inherit from GenericRepository<T> which provides the following CRUD operations:

### CREATE
- `AddAsync(T entity)` - Add single entity
- `AddRangeAsync(IEnumerable<T> entities)` - Add multiple entities

### READ
- `GetByIdAsync(int id)` - Get entity by primary key
- `GetAllAsync()` - Get all entities
- `FindAsync(Expression<Func<T, bool>> predicate)` - Find entities by condition
- `FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)` - Get first match or null

### UPDATE
- `UpdateAsync(T entity)` - Update single entity
- `UpdateRangeAsync(IEnumerable<T> entities)` - Update multiple entities

### DELETE
- `DeleteAsync(int id)` - Delete by ID
- `DeleteAsync(T entity)` - Delete entity
- `DeleteRangeAsync(IEnumerable<T> entities)` - Delete multiple entities

### HELPERS
- `CountAsync()` - Count all entities
- `CountAsync(Expression<Func<T, bool>> predicate)` - Count by condition
- `AnyAsync(Expression<Func<T, bool>> predicate)` - Check if any entity matches
- `SaveChangesAsync()` - Save all changes

---

## Specialized Repositories

### OrderDetailsRepository
- `GetByOrderIdAsync(int orderId)` - Get all details for an order
- `GetByProductIdAsync(int productId)` - Get all orders containing a product
- `GetWithDetailsAsync(int id)` - Get single order detail with relations
- `GetAllWithDetailsAsync()` - Get all order details with relations
- `CalculateLineTotal(OrderDetails)` - Calculate total with discount

### ProductRepository
- `GetByCategoryAsync(int categoryId)` - Get products in category
- `GetLowStockProductsAsync()` - Get products below reorder level
- `GetByNameAsync(string productName)` - Get product by name
- `UpdateQuantityAsync(int productId, int quantity)` - Add/subtract quantity
- `ProductExistsByNameAsync(string productName)` - Check product exists

### CategoryRepository
- `GetByNameAsync(string categoryName)` - Get category by name
- `CategoryExistsByNameAsync(string categoryName)` - Check category exists
- `UpdateLastUpdateAsync(int categoryId)` - Update timestamp

### OrderRepository
- `GetByCustomerAsync(int customerId)` - Get customer's orders
- `GetByEmployeeAsync(int employeeId)` - Get employee's orders
- `GetByStatusAsync(string status)` - Get orders by status
- `GetByDateRangeAsync(DateTime, DateTime)` - Get orders in date range
- `GetPendingOrdersAsync()` - Get pending/processing orders
- `GetCompletedOrdersAsync()` - Get completed/delivered orders
- `UpdateOrderStatusAsync(int orderId, string status)` - Update order status
- `GetCustomerOrderCountAsync(int customerId)` - Count customer's orders

### EmployeeRepository
- `GetByDepartmentAsync(int departmentId)` - Get department employees
- `GetByRoleAsync(int roleId)` - Get employees by role
- `GetByEmailAsync(string email)` - Get employee by email
- `GetByNameAsync(string employeeName)` - Get employees by name (partial match)
- `EmployeeExistsByEmailAsync(string email)` - Check email exists
- `GetDepartmentEmployeeCountAsync(int departmentId)` - Count department employees
- `GetByRoleInDepartmentAsync(int deptId, int roleId)` - Get specific role in department

### CustomerRepository
- `GetByEmailAsync(string email)` - Get customer by email
- `GetByNameAsync(string customerName)` - Get customers by name
- `GetByCityAsync(string city)` - Get customers in city
- `GetByCountryAsync(string country)` - Get customers in country
- `CustomerExistsByEmailAsync(string email)` - Check email exists
- `GetByPhoneAsync(string phone)` - Get customer by phone
- `GetTotalCustomersAsync()` - Count total customers
- `GetCustomersWithOrdersAsync()` - Get customers who have orders

### DepartmentRepository
- `GetByNameAsync(string departmentName)` - Get department by name
- `DepartmentExistsByNameAsync(string departmentName)` - Check name exists
- `GetDepartmentEmployeeCountAsync(int departmentId)` - Count employees

### RoleRepository
- `GetByNameAsync(string roleName)` - Get role by name
- `RoleExistsByNameAsync(string roleName)` - Check name exists
- `GetRoleEmployeeCountAsync(int roleId)` - Count employees in role

### AddressRepository
- `GetByCityAsync(string city)` - Get address by city
- `GetByCountryAsync(string country)` - Get address by country
- `GetAddressCustomerCountAsync(int addressId)` - Count customers at address

### EmployeeDetailsRepository
- `GetByEmployeeIdAsync(int employeeId)` - Get details for employee
- `GetByUsernameAsync(string username)` - Get by username
- `UsernameExistsAsync(string username)` - Check username exists
- `GetActiveEmployeeCountAsync()` - Count active employees

---

## Unit of Work Pattern

The UnitOfWork class coordinates all repositories and provides transaction support:

```csharp
using (var unitOfWork = new UnitOfWork(context))
{
	try
	{
		await unitOfWork.BeginTransactionAsync();

		// Multiple operations
		var product = await unitOfWork.Products.AddAsync(newProduct);
		var order = await unitOfWork.Orders.AddAsync(newOrder);

		await unitOfWork.CommitAsync();
	}
	catch
	{
		await unitOfWork.RollbackAsync();
		throw;
	}
}
```

### Transaction Methods
- `BeginTransactionAsync()` - Start a transaction
- `CommitAsync()` - Commit all changes
- `RollbackAsync()` - Rollback all changes
- `SaveChangesAsync()` - Save without transaction

---

## Usage Example

```csharp
public class OrderService
{
	private readonly IUnitOfWork _unitOfWork;

	public OrderService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	// Create a new order
	public async Task<Order> CreateOrderAsync(Order order)
	{
		return await _unitOfWork.Orders.AddAsync(order);
	}

	// Get customer orders
	public async Task<IEnumerable<Order>> GetCustomerOrdersAsync(int customerId)
	{
		return await _unitOfWork.Orders.GetByCustomerAsync(customerId);
	}

	// Update order status
	public async Task<bool> UpdateOrderStatusAsync(int orderId, string status)
	{
		return await _unitOfWork.Orders.UpdateOrderStatusAsync(orderId, status);
	}

	// Delete order
	public async Task<bool> DeleteOrderAsync(int orderId)
	{
		return await _unitOfWork.Orders.DeleteAsync(orderId);
	}

	// Complex operation with transaction
	public async Task<Order> ProcessOrderAsync(Order order, List<OrderDetail> details)
	{
		try
		{
			await _unitOfWork.BeginTransactionAsync();

			var savedOrder = await _unitOfWork.Orders.AddAsync(order);
			await _unitOfWork.OrderDetails.AddRangeAsync(details);

			await _unitOfWork.CommitAsync();
			return savedOrder;
		}
		catch
		{
			await _unitOfWork.RollbackAsync();
			throw;
		}
	}
}
```

---

## Dependency Injection Setup

In Program.cs:

```csharp
builder.Services.AddDbContext<ProductManagementDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
```
