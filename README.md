# Task Management APIs

Task Management APIs is a .NET Core WebAPI project designed to provide functionality for managing teams, projects, and tasks. The application allows users to create teams, assign team members, create projects, and manage tasks within those projects.

## Table of Contents

- [Introduction](#introduction)
- [Technologies](#technologies)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Database Setup](#database-setup)
- [Run the Application](#run-the-application)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction

Task Management APIs is a project management system that enables users to create teams, assign team members, create projects, and manage tasks. It provides an API for performing CRUD operations on teams, members, projects, and tasks.

## Technologies

- .NET Core
- PostgreSQL
- Entity Framework Core
- Other relevant technologies...

## Getting Started

To get started with Task Management APIs, clone the repository:

```bash
git clone https://github.com/ndungtse/task-management-apis.git
cd task-management-apis
```

## Configuration

Configure the application settings by updating the appropriate configuration files or using environment variables.

## Database Setup

Set up the PostgreSQL database by providing the connection string in the configuration. Run Entity Framework Core migrations to create the necessary tables:

```bash
dotnet ef database update
```

## Run the Application

Build and run the application using the following commands:

```bash
dotnet build
dotnet run
```

## Usage

Use the provided API endpoints to create teams, manage team members, create projects, and handle tasks within those projects.

## Contributing

If you would like to contribute to the project, please follow the [contributing guidelines](CONTRIBUTING.md).

## License

This project is licensed under the [MIT License](LICENSE).
