# HiringTestWebApp

# Geting Started

This web application was developed using .NET 8.

## Run the application

To run the application use the dotnet command:

`dotnet run`

## Swagger

Swagger documentation for API endpoints is available at the /swagger URL.

http://localhost:5212/swagger

# Design

The webapp was developed using the factory pattern in mind to be able to add new string manipulation algorithms as easy as possible.

# Testing

To run tests there is a script called run-test.sh inside the HiringTestWebapp.Tests project.

This script was tested on Mac OS 14 only.

```
cd HiringTestWebapp.Tests
./run-test.sh
```

This will run all the tests and generate the code coverage (in html) for the project.
