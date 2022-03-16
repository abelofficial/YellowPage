import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { v4 as uuid } from "uuid";
import BusinessItem from "../../Components/BusinessItem";
import PersonItem from "../../Components/PersonItem";
import { Business, Person } from "../../Components/types";
import { YellowPageApi } from "../../Services/YellowPageApi";

const HomePage = () => {
  const navigate = useNavigate();
  const [businesses, setBusinesses] = useState<Business[]>();
  const [people, setPeople] = useState<Person[]>();
  const [loading, setLoading] = useState<boolean>(true);
  const [readyToFetch, setReadyToFetch] = useState<boolean>(true);
  const [filterTerm, setFilterTerm] = useState<string>("");

  useEffect(() => {
    if (readyToFetch) {
      const fetchData = async () => {
        const [businessResp, peopleResp] = await Promise.all([
          new YellowPageApi().getBusinesses(filterTerm),
          new YellowPageApi().getPeople(filterTerm),
        ]);
        setTimeout(() => {
          setBusinesses(businessResp.data);
          setPeople(peopleResp.data);
          setLoading(false);
          setReadyToFetch(false);
        }, 300);
      };
      fetchData();
    }
  }, [readyToFetch]);

  const getItemToRender = () => {
    if (loading)
      return (
        <div className='container--centered'>
          <h1>loading...</h1>
        </div>
      );
    if (businesses?.length === 0 && people?.length === 0)
      return (
        <div className='container--centered'>
          <h1>No content found</h1>
        </div>
      );

    if (businesses && people)
      return (
        <div>
          {people.map((i) => (
            <PersonItem key={uuid()} item={i} />
          ))}
          {businesses.map((i) => (
            <BusinessItem key={uuid()} item={i} />
          ))}
        </div>
      );

    if (businesses)
      return (
        <div>
          {businesses.map((i) => (
            <BusinessItem key={uuid()} item={i} />
          ))}
        </div>
      );
    if (people)
      return (
        <div>
          {people.map((i) => (
            <PersonItem key={uuid()} item={i} />
          ))}
        </div>
      );
  };

  return (
    <div>
      <header className='search__container'>
        <div>
          <h4 className='text'>Search records</h4>
        </div>
        <div className='search__section'>
          <input
            type='text'
            className='form__input width-full'
            placeholder='name, email, phone, address'
            value={filterTerm}
            onChange={(e) => setFilterTerm(e.target.value)}
          />
          <button
            className='button button--bg-yellow button__submit'
            onClick={() => {
              setReadyToFetch(true);
              setLoading(true);
            }}
          >
            Search
          </button>
        </div>
      </header>
      {getItemToRender()}
    </div>
  );
};

export default HomePage;
