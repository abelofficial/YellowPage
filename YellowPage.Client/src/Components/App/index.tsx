import React, { useEffect, useState } from "react";
import { YellowPageApi } from "../../Services/YellowPageApi";
import BusinessItem from "../BusinessItem";
import PersonItem from "../PersonItem";
import { Business, Person } from "../types";
import "./style.css";

function App() {
  const [businesses, setBusinesses] = useState<Business[]>();
  const [people, setPeople] = useState<Person[]>();
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    const fetchData = async () => {
      const [businessResp, peopleResp] = await Promise.all([
        new YellowPageApi().getBusinesses(),
        new YellowPageApi().getPeople(),
      ]);

      setBusinesses(businessResp.data);
      setPeople(peopleResp.data);
      setLoading(false);
    };
    fetchData();
  }, []);

  console.log(businesses);
  return (
    <div className='App'>
      <header className='App-header'>
        {!loading ? (
          <div>
            {businesses && businesses.map((i) => <BusinessItem item={i} />)}
            {people && people.map((i) => <PersonItem item={i} />)}
          </div>
        ) : (
          <h1> Loading...</h1>
        )}
      </header>
    </div>
  );
}

export default App;
