# RestaurantWeb
This web application has been created with Reactjs and MVC5.
The application has been built in Visual Studio 2019 Community Edition, with .Net Framework Version 4.6.1.
It is working in VS 2019, however it hasn't been tested using earlier versions of VS.
To get the app, download the zip from the GitHub repository. 
Open the solution in VS 2019, and Clean Solution and Rebuild Solution. 
The Clean and Rebuild makes sure that it runs properly, and doesn't show "could not find path bin\roslyn\csc.exe" error.
The application is using SQL Server ((LocalDb)\MSSQLLocalDB) that comes with VS 2019.
After successful build, when running the website first time, it should automatically create a database called "RestaurantWeb".
It is very important to add some seed data in dbo.FoodItems table. Use the file dbo.FoodItems.data.sql that is uploaded to this repository.
This will make sure that when home page is loaded, it shows Food Items menu, and user can then make use of Shopping Cart.
User will need to be logged in to add items into Shopping Cart and continue with the order.
On the navigation bar, there is Admin link that would also work only when user is logged in.
Currently Admin link is enabled for any logged-in user, however this can be restricted to Admin-User via code using [AuthorizeAdmin] attribute.

