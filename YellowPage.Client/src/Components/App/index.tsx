import React, { useEffect, useState } from "react";
import { Route, Routes } from "react-router-dom";
import AddPage from "../../Pages/add";
import DetailPage from "../../Pages/Detail";
import HomePage from "../../Pages/Home";
import { YellowPageApi } from "../../Services/YellowPageApi";
import BusinessItem from "../BusinessItem";
import NavBar from "../NavBar";
import PersonItem from "../PersonItem";
import { Business, Person } from "../types";
import "./style.css";

function App() {
  // const [businesses, setBusinesses] = useState<Business[]>();
  // const [people, setPeople] = useState<Person[]>();
  // const [loading, setLoading] = useState<boolean>(true);

  // useEffect(() => {
  //   const fetchData = async () => {
  //     const [businessResp, peopleResp] = await Promise.all([
  //       new YellowPageApi().getBusinesses(),
  //       new YellowPageApi().getPeople(),
  //     ]);

  //     setBusinesses(businessResp.data);
  //     setPeople(peopleResp.data);
  //     setLoading(false);
  //   };
  //   fetchData();
  // }, []);

  // console.log(businesses);
  return (
    <main className='App'>
      <NavBar />
      <section className='app__container'>
        {/* {!loading ? (
          <div>
            {businesses && businesses.map((i) => <BusinessItem item={i} />)}
            {people && people.map((i) => <PersonItem item={i} />)}
          </div>
        ) : (
          <h1> Loading...</h1>
        )} */}
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
