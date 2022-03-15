import React, { useEffect, useState } from "react";
import { v4 as uuid } from "uuid";
import BusinessItem from "../../Components/BusinessItem";
import PersonItem from "../../Components/PersonItem";
import { Business, Person } from "../../Components/types";
import { YellowPageApi } from "../../Services/YellowPageApi";

const HomePage = () => {
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

  return (
    <div>
      {!loading ? (
        <div>
          {businesses &&
            businesses.map((i) => <BusinessItem key={uuid()} item={i} />)}
          {people && people.map((i) => <PersonItem key={uuid()} item={i} />)}
        </div>
      ) : (
        <h1> Loading...</h1>
      )}
    </div>
  );
};

export default HomePage;
