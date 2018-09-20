# Globo.Calculator

## Description

Globo.Calculator is a simple console .NET Core 2.0 application that allows to evaluate very simple mathematical expressions. It implements **shunting-yard** algorithm to convert infix expression to postfix expression, and evaluate the result.

Supported mathematical operators:

- addition (**"+"** sign)
- subtraction (**"-"** sign)
- multiplication (**"*"** sign)
- division (**"/"** sign)

Also supported opening parenthesis (**"("** sign) and closing parenthesis (**")"** sign) to group expressions and set higher priority.

Application works only with integer operands.

## Instruction

1. Clone or download repository
1. Restore packages:
    - Execute `dotnet restore` via CLI or
    - Right-click on solution and select `Restore NuGet Packages` menu item.
1. Run the application
    - Execute `dotnet run` via CLI if current folder is `Globo.Calculator.Host`, or specify path to project by `--project` attribute or
    - Set `Globo.Calculator.Host` as startup project (if not set) and run via Visual Studio.
1. Enter `exit` command as expression to stop equation, and close the application.

## New Section
1. lorem ipsum
2. dolor met
