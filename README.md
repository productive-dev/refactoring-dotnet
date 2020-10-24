# refactoring-dotnet

An example project demonstrating cleaning up legacy code in a .NET Core MVC project

This repository was created for the Productive Dev YouTube series on refactoring legacy code ([here's the link](https://www.youtube.com/watch?v=uj0RWP3DdUo&list=PL3_YUnRN3Uhh8H3Zw2M6KDdP3aAlbfT8j)). 

## Key concepts

- Improving testability
- Inversion of control via dependency injection
- Message-sending between objects
- Making smaller things
- Improving naming
- Extracting configuration
- Programming to abstractions instead of implementations
- Replacing conditional logic with polymorphism
- Using factory methods
- Using async / await
- Using `Task.FromResult` for non-asynchronous overiddes of `Task` methods
- Writing unit and integration tests
- Monitoring code quality using static code analysis
- Creating a continuous integration loop

## To Follow along via YouTube series
The `main` branch contains the result of refactoring the legacy code.  The `legacy_code` branch contains the starting point of the project, from where the refactoring begins.

- Clone the repository
- Checkout the `legacy_code` branch
- Complete the refactor
