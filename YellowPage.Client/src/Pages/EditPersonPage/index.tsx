import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import EditPersonForm from "../../Components/EditPersonForm";
import { Person } from "../../Components/types";
import { YellowPageApi } from "../../Services/YellowPageApi";

const EditPersonPage = () => {
  const [person, setPerson] = useState<Person>();
  const [loading, setLoading] = useState<boolean>(true);

  let { id } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      if (id) {
        const personResp = await new YellowPageApi().getPerson(id);
        setPerson(personResp.data);
      }
      setLoading(false);
    };
    fetchData();
  }, []);

  const removeHandler = async () => {
    if (person?.id !== undefined) {
      await new YellowPageApi().removePerson(person.id.toString());
      navigate("/");
    }
  };

  return (
    <>
      {!loading ? (
        <>
          <header className='add__header'>
            <button
              className='button button--bg-yellow button__submit'
              onClick={() => navigate("/")}
            >
              back to home
            </button>
            <button
              className='button button--bg-red button__submit'
              onClick={removeHandler}
            >
              Remove
            </button>
          </header>
          {person ? (
            <EditPersonForm
              id={person.id ? person.id.toString() : ""}
              item={person}
            />
          ) : (
            <h1>Person not found</h1>
          )}
        </>
      ) : (
        <h1>loading</h1>
      )}
    </>
  );
};

export default EditPersonPage;
