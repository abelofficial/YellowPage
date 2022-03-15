import { Route, Routes } from "react-router-dom";
import AddPage from "../../Pages/Add";
import EditBusinessPage from "../../Pages/EditBusinessPage";
import EditPersonPage from "../../Pages/EditPersonPage";
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
          <Route path='/edit/person/:id' element={<EditPersonPage />} />
          <Route path='/edit/business/:id' element={<EditBusinessPage />} />
        </Routes>
      </section>
    </main>
  );
}

export default App;
