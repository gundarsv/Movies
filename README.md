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

🔗 The backend API should now be running on `https://localhost:7206` or a port specified in your configuration. Documentation can be accessed on `https://localhost:7206/swagger`

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

## ⚙️ Configuration

- Backend configurations like API key and base URL are located in `appsettings.json`.
- Adjust frontend API endpoints or other configurations in their respective service.
