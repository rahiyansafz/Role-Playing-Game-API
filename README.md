# RPG Web API with .NET

This API provides various functionalities related to an RPG game, including character management, authentication, weapon management, and fighting.

## Getting Started

To get started with this API, you will need to follow these steps:

1. Clone or download the project from GitHub.
2. Install any necessary dependencies using the package manager console.
3. Set up the database connection in the appsettings.json file.
4. Run the project using Visual Studio or the command prompt.

## Usage

This API provides the following controllers:

- FightController: Manages fighting functionalities between characters.
- CharacterController: Manages character creation, editing, and deletion.
- AuthController: Manages user authentication and authorization.
- WeaponController: Manages weapon creation, editing, and deletion.

Each controller provides various endpoints that can be accessed using HTTP requests. Here are some examples of how to use the API:

- To create a new character, send a POST request to the /api/character endpoint with the necessary data in the request body.
- To get a list of all characters, send a GET request to the /api/character endpoint.
- To authenticate a user, send a POST request to the /api/auth/login endpoint with the user's credentials in the request body.

For more detailed information about the available endpoints and their parameters, please refer to the Swagger documentation.

## Requirements

This API requires the following:

- .NET 5.0 or higher
- Microsoft SQL Server

## Contact

If you have any questions or need support, please contact us at rahiyansafin@gmail.com.

## License

This project is licensed under the MIT License. See the LICENSE file for details.
