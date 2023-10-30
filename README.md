# Movie Search App

- **Frontend**: React, TypeScript, Vite, and Tailwind CSS.
- **Backend**: .NET 7

## Getting Started

### Backend Setup:

1. **Navigate** to the backend directory:
    ```bash
    cd JETech.Movies\JETech.Movies.Api
    ```

2. **Install** the necessary packages:
    ```bash
    dotnet restore
    ```

3. **Run** the backend:
    ```bash
    dotnet run --urls "https://localhost:7206"
    ```

🔗 The backend API should now be running on `https://localhost:7206` or a port specified in your configuration.

### Frontend Setup:

1. **Navigate** to the frontend directory:
    ```bash
    cd JETech.Movies\JETech.Movies.Web
    ```

2. **Install** dependencies:
    ```bash
    npm install
    ```

3. **Start** the frontend development server:
    ```bash
    npm run dev
    ```

🌐 The frontend should now be live at `http://localhost:5173`.

## 🛠 Usage

1. **Home Page**: Explore a curated list of movies or navigate to different sections of the app.
2. **Search**: Use the intuitive search bar to discover movies.
3. **Recent Searches**: Stay updated with your search history, conveniently located on the right side of the home page.

## ⚙️ Configuration

- Backend configurations like API key and base URL are located in `appsettings.json`.
- Adjust frontend API endpoints or other configurations in their respective service or component files.
