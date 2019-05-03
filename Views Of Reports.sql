
--View1
--	List of orders and their details that a customer orders at specific time.


Create View CustomerOrder As
Select Concat(FirstName, LastName) As "Customer Name" , Orders.OrderId , MenuCard.Name AS "Food Name" , 
 OrderDate AS "Order Date", DeliveryDate, Quantity, UnitPrice*Quantity As Price
 From ((((Orders JOIN OrderDetails ON Orders.OrderId = OrderDetails.OrderId) 
JOIN Customer ON Customer.Id = Orders.CustomerId) 
JOIN MenuCard ON MenuCard.FoodId = OrderDetails.FoodId) JOIN Users On Users.Id = Customer.Id)


--View2
--List of registered employees with their salaries and designation.

Create View EmployeeDetails As
Select Concat(FirstName, LastName) As "Employee Name" , Salary , designationOfEmployee As Designation From ((Users JOIN 
Employee ON Employee.EmployeeId = UserS.Id) JOIN Designation on Employee.DesignationId = Designation.Id)

--View3
--	Number of employees working at each designation.

Create View DesignationDetails As
Select designation.designationOfEmployee  As Designation, Count(EmployeeId)  As "Num Of Employees" From (Employee 
JOIN Designation ON Designation.id = Employee.DesignationId)
Group by ( designationOfEmployee)

--View4
--Feedback given by customers order by date.

Create View CustomersFeedback As
Select Concat(FirstName, LastName) As CustomerName , comment As Feedback From ((Feedback JOIN Customer
 ON Customer.Id = Feedback.CustomerId)	JOIN Users On Users.Id = Customer.Id)

 --View5
 --Number of customers and total sale price on daily basis

 Create View DailyIncome As
 Select OrderDate, Count(CustomerId) As "Total Customers", Sum(TotalBill) As "Total Income"  From
 (Customer JOIN Orders ON Customer.Id = Orders.CustomerId) Group by(OrderDate)

 --View6
 --Categories of menu card along with total number of items they have.

 Create View MenuCardDetails AS 
 Select CategoryName, Count(FoodId) As "Num of Food Items"  From
 (FoodCategory JOIN MenuCard ON MenuCard.CategoryId = FoodCategory.Id)
 Group By(CategoryName)

  --View7
  --List of products along with their categories and supplier names.

 Create View PurchasedItemsDetails AS
 Select Name AS "Product Name", CategoryName, CompanyName From
 (([Purchased Items] JOIN Suppliers ON [Purchased Items].SupplierId = Suppliers.SupplierId)
 JOIN Categories ON [Purchased Items].CategoryId = Categories.CategoryId)

   --View8
   --Orders assigned to each chef and status of each order
 Create View ChefOrderDetails AS
 Select Concat(FirstName, LastName) As "Chef Name" ,  OrderId, ChefOrder.[Status] AS "Order Status" From
 ((ChefOrder JOIN Employee ON Employee.EmployeeId = ChefOrder.ChefId) JOIN Users ON Users.Id = Employee.EmployeeId)  

  --View9
  -- Customer order details .
 Create View CustomerOrderDetails AS
Select Concat(FirstName, LastName) As CustomerName , OrderId, TotalBill From ((Orders JOIN Customer
 ON Customer.Id = Orders.CustomerId)JOIN Users ON Customer.Id = Users.Id)

--View10
   --Orders assigned to each deliverer and status of each order with deliverer names

 Create View DeliveryOrderDetails AS
 Select Concat(FirstName, LastName) As "Deliverer Name",  DeliveryTeamId ,[Orders DeliveryTeams].OrderId, DeliveryStatus From
 (((([Orders DeliveryTeams] JOIN TeamMembers ON TeamMembers.TeamId = [Orders DeliveryTeams].DeliveryTeamId) 
  JOIN Orders ON Orders.OrderId = [Orders DeliveryTeams].OrderId) 
  JOIN Employee ON [Orders DeliveryTeams].OrderId = Orders.OrderId) JOIN Users ON Users.Id = Employee.EmployeeId)   

 
