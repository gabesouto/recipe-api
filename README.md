# Recipe API for Cooking App

Welcome to the Recipe API project, an essential extension for our beloved cooking app! This README will provide a comprehensive overview of how to integrate and use the Recipe API in your existing application.

## Key Features:

1. **Recipe Listing:**
   - Endpoint to retrieve all available recipes.

2. **Recipe Management:**
   - Addition, removal, and updating of recipes in an easy and intuitive way.

3. **User Management:**
   - Registration, removal, querying, and updating of user data in the application.

4. **Comments:**
   - Registration and querying of comments associated with recipes.

## Quick Integration:

1. **Available Endpoints:**
   - `/api/recipes`: Listing of all recipes.
   - `/api/recipes/add`: Addition of a new recipe.
   - `/api/recipes/remove/{id}`: Removal of a specific recipe.
   - `/api/recipes/update/{id}`: Updating details of a recipe.
   - `/api/users/register`: Registration of a new user.
   - `/api/users/remove/{id}`: Removal of a specific user.
   - `/api/users/query/{id}`: Querying user data.
   - `/api/users/update/{id}`: Updating user data.
   - `/api/comments/register`: Registration of a new comment.
   - `/api/comments/query/{recipeId}`: Querying comments associated with a recipe.

2. **Data Models:**
   - All necessary models are already available for integration.

3. **Running Locally:**
   - Make sure you have [.NET Core SDK](https://dotnet.microsoft.com/download) installed.
   - Clone this repository to your local machine.
   - Navigate to the project directory in the terminal.
   - Run `dotnet restore` to restore the project dependencies.
   - Execute `dotnet run` to start the local development server.
   - Access the API through `https://localhost:5001` in your browser.

4. **Support:**
   - For any questions or suggestions, feel free to contact us for assistance.

We are excited to see how the Recipe API will enhance the functionalities of your cooking app. Happy cooking! 🍳🚀

    
    
