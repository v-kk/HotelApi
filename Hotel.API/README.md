** Hotel API **

=> Overview

A REST API built with C# and ASP .Net Core.
This API is used to fetch data from a Json file.
Designed for scalability and maintainability.

-> Project Structure: The project consists of 3 main layers.
1.Models: Represent the structure of the data.
2.Services: Encapsulate business logic and data handling. 
3.Controllers: Handle HTTP requests and define the API endpoints.

-> The features of the API include:

- Retrieving a list of all hotels.
- Retrieving details of a specific hotel by its ID.
- Graceful handling of errors.

-> Error Handling: The error handling is implemented to cover the main edge cases.
1.Malformed Input: If the ID is invalid, a 400 Bad Request is returned.
2.Resource Not Found: If the hotel is not found, a 404 Not Found is returned.
3.Unexpected Errors: If the JSON file is missing or corrupted, the API returns a 500 Internal Server Error.

=> Prerequisites to run locally.

- .NET 6.0 SDK or later.
- IDE like Visual Studio.

=> How to run the project locally.
- Clone the repository to your local machine.
- Open the solution file in Visual Studio or another IDE.
- Build and Run the project.


