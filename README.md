BasicAuthIdentity Project
This is a sample ASP.NET Core application that demonstrates how to implement basic user authentication and authorization using ASP.NET Core Identity. The application provides endpoints for user registration, login, changing passwords, and retrieving user information.

Getting Started
Prerequisites
.NET 6 SDK or later installed on your machine.
Installation
Clone the repository to your local machine:

bash
git clone https://github.com/BeckhamBkm/Auth_Repo.git
Navigate to the project directory:

bash
cd BasicAuthIdentity
Restore the dependencies:

bash
dotnet restore
Update the connection string in appsettings.json with your database connection details.

Apply the database migrations:

bash
dotnet ef database update
Running the Application
To run the application, use the following command:

bash
dotnet run
The application will start and be accessible at http://localhost:5000 or https://localhost:5001 (with HTTPS enabled).

Endpoints
The application provides the following API endpoints:

POST /api/Users/Register
Register a new user with a unique username and email.

POST /api/Users/Authenticate
Authenticate a user by providing the email and password.

POST /api/Users/ChangePassword
Change the password for an authenticated user.

GET /api/Users/GetAll
Retrieve a list of all users in the database.

GET /api/Users/GetUserByEmail
Retrieve a user by providing the email address.

CORS Configuration
By default, the application allows requests from http://localhost:3000. If you want to change the allowed origins or further configure CORS, you can do so in the Program.cs file.

Authentication
The application uses ASP.NET Core Identity for user authentication and authorization. It provides pre-configured endpoints for user registration and login.

Additional Notes
This project is intended as a basic example of how to implement user authentication and authorization in an ASP.NET Core application. It is not production-ready and may require further security enhancements and error handling for a real-world application.

Contributing
If you find any issues or have suggestions for improvement, please feel free to open an issue or submit a pull request.

License
This project is licensed under the MIT License. Feel free to use it as a starting point for your own projects.