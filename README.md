# Flag Explorer API - .NET 8

## Overview
This is a .NET 8 Web API that provides country information, including flags, population, and capital cities. It consumes data from the [RestCountries API](https://restcountries.com/v3.1/all) and follows clean architecture principles.

## Clean Architecture Overview
This project follows the **Clean Architecture** pattern, separating concerns into different layers:
- **Controllers (Presentation Layer):** Handles HTTP requests and interacts with the service layer.
- **Services (Application Layer):** Contains business logic and calls the repository layer.
- **Repositories (Data Access Layer):** Fetches and processes data from the external RestCountries API.
- **Models (Domain Layer):** Defines data structures and ensures a clear contract between layers.

### **Repository Pattern & Services**
- The **Repository Pattern** is used to abstract the data access logic, making it easier to manage dependencies and facilitate unit testing.
- The **Service Layer** acts as an intermediary between controllers and repositories, ensuring business rules are applied before returning data.

## Swagger Integration
This project uses **Swagger** to provide API documentation and testing UI. Once the API is running, navigate to:
```
http://localhost:5000/swagger
```
or
```
https://localhost:5001/swagger
```
Swagger allows you to test the API endpoints interactively.

## Automapper Integration
The project uses **Automapper** to simplify object-to-object mapping, ensuring cleaner and more maintainable code when transforming data between different layers.

## Prerequisites
Ensure you have the following installed:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio 2022](https://visualstudio.microsoft.com/)
- Postman (optional for testing API endpoints)

## Installation
### Clone the repository:
```sh
git clone https://github.com/benitazz/Old-Mutual-Proj.git
cd old-mutual-api
```

### Restore dependencies:
```sh
dotnet restore
```

## Running the API (Backend Project)
This is the **backend project**, which needs to be run first before setting up the frontend.

### Using the command line:
```sh
dotnet run --project Old-Mutual-Proj
```

### Using Visual Studio:
- Open the solution file.
- Set `Old-Mutual-Proj` as the startup project.
- Click the **Run** button.

Once running, copy the API base URL (e.g., `http://localhost:5000` or `https://localhost:5001`) and configure it in the frontend project to connect with the API.

## API Endpoints
### Get All Countries
**Request:**
```http
GET /api/countries
```
**Response:**
```json
[
  {
    "name": "South Africa",
    "flag": "https://flagcdn.com/w320/za.png"
  }
]
```

### Get Country Details
**Request:**
```http
GET /api/countries/{name}
```
**Response:**
```json
{
  "name": "South Africa",
  "flag": "https://flagcdn.com/w320/za.png",
  "population": 59308690,
  "capital": "Pretoria"
}
```

## Running Tests
To ensure code quality and functionality, run the unit tests using the following command:
```sh
dotnet test
```

### Running Specific Tests
To run a specific test, use:
```sh
dotnet test --filter FullyQualifiedName=Namespace.ClassName.MethodName
```

### Viewing Test Coverage
To check code coverage, install the .NET coverage tool and run:
```sh
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov
```
To run the unit tests, use:
```sh
dotnet test
```

## Deployment
Build and publish the application:
```sh
dotnet publish -c Release -o out
```
Run the published app:
```sh
cd out
./Old-Mutual-Proj
```

## Connecting the Frontend Project
1. Start the **backend API** first.
2. Copy the API base URL (`http://localhost:5000` or `https://localhost:5001`).
3. Paste the URL into the frontend project's API configuration.
4. Start the frontend project.

## Contributing
1. Fork the repository.
2. Create a new branch (`feature/new-feature`).
3. Commit your changes.
4. Push to your branch and open a pull request.

## License
This project is licensed under the Ben and Old Mutual License.

