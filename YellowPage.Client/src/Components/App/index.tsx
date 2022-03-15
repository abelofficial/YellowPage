import { Route, Routes } from "react-router-dom";
import AddPage from "../../Pages/add";
import DetailPage from "../../Pages/Detail";
import HomePage from "../../Pages/Home";
import NavBar from "../NavBar";

function App() {
  return (
    <main className='App'>
      <NavBar />
      <section className='app__container'>
        <Routes>
          <Route path='/' element={<HomePage />} />
          <Route path='/add' element={<AddPage />} />
          <Route path='/detail/:id' element={<DetailPage />} />
        </Routes>
      </section>
    </main>
  );
}

export default App;
