import {
  BrowserRouter as Router,
  Route,
  Link,
  Routes
} from "react-router-dom";
import MovieDetail from "./components/MovieDetail";
import MovieSearch from "./components/MovieSearch";

const App: React.FC = () => {
  return (
    <Router>
      <div>
        <nav className="bg-blue-600 p-4">
          <ul className="flex space-x-4">
            <li>
              <Link to="/" className="text-white hover:text-blue-200">
                Home
              </Link>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path="/movie/:id" element={<MovieDetail />}>
          </Route>
          <Route path="/" element={<MovieSearch />}>
          </Route>
        </Routes>
      </div>
    </Router>
  );
}

export default App;
