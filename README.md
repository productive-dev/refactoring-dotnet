# refactoring-dotnet

An example project demonstrating cleaning up legacy code in a .NET Core MVC project

This repository was created for the Productive Dev YouTube series (TODO: link) on refactoring legacy code.

__Key concepts__:

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

__To Follow along via YouTube series__:
The `main` branch contains the result of refactoring the legacy code.  The `legacy_code` branch contains the starting point of the project, from where the refactoring begins.

- Clone the repository
- Checkout the `legacy_code` branch
- Complete the refactor
