# Amadeus Technical Test Juan Moreno

## Description

This API was developed as part of a technical exercise in .NET 6.0. The API implements a CRUD (Create, Read, Update, Delete) service to manage passenger information. Through this API, you can perform operations on a Microsoft SQL Server database where all passenger information is stored.

## Features

- **Create Passenger:** Allows the creation of a new passenger record in the database.
- **Read Passengers:** Retrieves a list of all passengers stored in the database.
- **Read Passenger Details:** Retrieves details of a specific passenger by providing their ID.
- **Update Passenger:** Allows modifying the data of an existing passenger, identified by their ID.
- **Delete Passenger:** Deletes a passenger record from the database using their ID.

## Technologies Used

- **.NET 6.0:** Framework used to develop the API.
- **Entity Framework Core:** Used to manage database operations in a simplified manner.
- **SQL Server:** Relational database where passenger data is stored.
- **Swagger:** Integrated tool for API documentation and testing.
- **C#:** Programming language used for implementation.

## Configuration

### Database Connection

This API is configured to connect to a SQL Server database. Make sure to properly configure the connection string in the `appsettings.json` file before running the application:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=False;MultipleActiveResultSets=true;Encrypt=false"
}
```

Replace `YOUR_SERVER_NAME` and `YOUR_DATABASE_NAME` with the name of your SQL Server and database, respectively.

### Migrations

To apply database migrations, run the following commands in the Visual Studio Package Manager Console or terminal:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This will create the necessary tables in your SQL Server database based on the models defined in the API.

## Testing

This project includes unit and integration tests to ensure the API's correct functionality. Make sure to run the tests before deploying.

## How to Run

1. Clone the repository to your local machine.
2. Configure the connection string in `appsettings.json`.
3. Run the migrations to create the necessary tables in the database.
4. Start the application using Visual Studio or from the terminal with `dotnet run`.
5. The API will be available at `https://localhost:{port}/api/passengers`.

## Contributions

If you want to contribute to this project, feel free to open an issue or submit a pull request. Any contributions are welcome.

---

This README provides a clear and comprehensive description of your project, including the necessary instructions for setting it up and running it.
