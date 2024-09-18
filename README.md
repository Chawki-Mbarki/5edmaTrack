# 5edmaTrack 🎯

5edmaTrack is a task management and movie exploration web app built using **C#.NET**. It allows users to create and manage tasks, as well as explore and react to movies fetched from an external API. Users can also create personal movies and interact with them. The application comes with built-in account management features.

## Design 🎨 (Made by me):
### This is my first web design ever, you can find it [Here](https://www.figma.com/design/GEmZ06xJu9ctxAjDCv6oAm/5edmaTrack?node-id=0-1&node-type=canvas&t=5YcZjWHcYGo9bgBY-0)

## Features ✨

### Account Management 🔐
- **Create, Login & Manage Accounts**
  - Edit profile (email, name, password).
  - Delete account or transfer data to another account via email.

### Task Management 📝
- **Create, Update, Delete & Organize Tasks**:
  - Filter tasks by importance or urgency.
  - Update task statuses with different actions based on the status:
    - Pending: Start task
    - In Progress: Complete or Suspend task
    - On Hold: Resume task
    - Completed: Close task

### Movie Exploration 🎥
- **Browse and React to Movies**:
  - Movies fetched from an API, sortable by date or rating.
  - Filter by liked movies or new releases.
  - Users can like/dislike movies.
- **Add Personal Movies**:
  - Create your own movies and add them to the general movie list as well as the "My Movies" section.

## Technologies Used 🛠️
- **C#.NET 6**
- **Entity Framework Core** for database interactions.
- **MySQL** for database management.
- **ASP.NET MVC** for structure.
- **External Movie API** for movie data fetching.

## Database Schema 📊
The application uses a relational database with the following main tables:
- **Users**: Handles user information and credentials.
- **Tasks**: Stores tasks with their related metadata.
- **Movies**: Stores movie data, including user-created movies.
- **Ratings**: Tracks user reactions (like/dislike) to movies.

## Installation & Setup 🚀

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/5edmaTrack.git
   cd 5edmaTrack
   ```

2. Install dependencies:
   ```bash
   dotnet restore
   ```

3. Set up the database connection in the `appsettings.json` file:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your-server;Database=5edmaTrack;User Id=your-username;Password=your-password;"
   }
   ```

4. Run migrations to create the database schema:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. Run the application:
   ```bash
   dotnet run
   ```

## Usage 🛠️

- Access the app locally via: `https://localhost:5001`
- Register a new user, create tasks, and explore the movie section.
- Start managing your tasks and enjoy a personalized movie experience!

## License 📄
This project is licensed under the MIT License.

## Contributing 🤝
Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

---
Made with ❤️ by Chawki
