# University Course Project - Backend .NET 6 with Blazor Frontend

This repository contains the code for a university course project that involves developing a blog web application using .NET 6 on the backend and Blazor on the frontend. The project aims to demonstrate the implementation of a complete web solution for managing blog posts and related entities.

## Technologies Used

- Backend: .NET 6
- Frontend: Blazor

## Project Structure

The project is structured into three main components: the backend, the frontend, and the shared module.

### Backend

The backend is developed using .NET 6, which provides a robust and scalable foundation for building web applications. It includes the following components:

- RESTful API: The backend exposes a RESTful API to handle frontend requests. It implements various endpoints for performing CRUD operations on blog posts, authors, categories, and other necessary functionalities.

- Entity Framework Core: The application uses Entity Framework Core as an Object-Relational Mapping (ORM) tool for database communication. It provides a convenient way to interact with the database and perform database operations using C# code.

- Authentication and Authorization: The backend implements authentication and authorization using JSON Web Tokens (JWT). It ensures that only authenticated users can perform certain actions, such as creating or editing blog posts.

- Service Layer: The business logic of the application is encapsulated within service layers. These services handle data manipulation, validation, and other business-related tasks.

### Frontend

The frontend is built using Blazor, a framework for developing web applications using C#. It eliminates the need for separate frontend technologies like JavaScript, as it allows developers to write frontend code in C#. The frontend includes the following components:

- Blazor Components: The user interface is built using Blazor components, which are reusable UI elements. These components can be composed together to create complex UI structures.

- API Integration: The frontend communicates with the backend API using standard HTTP requests (GET, POST, PUT, DELETE). It sends requests to fetch data from the server and updates the UI accordingly.

### Shared

The shared module contains common components, models, and DTOs that are used by both the backend and frontend. It promotes code reusability and ensures consistency between the two parts of the application. This module includes:

- Models: The application includes models for entities such as authors, categories, and blog posts. These models define the structure and properties of these entities.

- DTOs (Data Transfer Objects): DTOs are used to transfer data between the backend API and the frontend. They define the structure of data objects exchanged between the two layers.

## Getting Started
note: The application will start running with the in-memory database seeded with sample data. Jwt is not configured to check issuare,audiance and lifespan.

To get started with the project, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution file in Visual Studio or your preferred .NET development environment.
3. Build the solution to restore NuGet packages and compile the code.
4. Configure the backend settings, such as database connection strings and JWT settings, in the appsettings.json file.
5. Run the backend project to start the API server.
6. Run the frontend project to launch the web application in your browser.

Make sure to set up the necessary dependencies and ensure that you have the required versions of .NET and Blazor installed on your development machine.

## Screenshots

Here are some screenshots demonstrating the functionality and user interface of the application:
Blazor:
1. Homepage/Post Listing:
  ![image](https://github.com/Murkod/BlazorBlog/assets/59425782/c79a68fe-1e00-490a-8cb8-438fdcbbb192)

2. Post :
   ![image](https://github.com/Murkod/BlazorBlog/assets/59425782/5091e4f5-ceae-4ad7-b642-1eabb537f29d)

Backend/Swagger:
1. Posts EndPoint:
   ![image](https://github.com/Murkod/BlazorBlog/assets/59425782/1260be0d-8cfb-458b-967f-3d947b8e65fc)
2. Author EndPoint:
  ![image](https://github.com/Murkod/BlazorBlog/assets/59425782/bd0a113a-b13c-4933-9d1d-f671cfaad76c)
3. Category EndPoint:
   ![image](https://github.com/Murkod/BlazorBlog/assets/59425782/b2ee1e1a-b5c7-4844-b578-e9c24f9b47a0)
4. Login EndPoint:
   ![image](https://github.com/Murkod/BlazorBlog/assets/59425782/6bf3e5a6-ec4f-4421-90ed-31985d9b148f)



Feel free to explore the application and see it in action!

Please note that these screenshots are from a demo version, and the actual appearance may vary based on the implementation and customization in your environment.
