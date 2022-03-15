import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import EditBusinessForm from "../../Components/EditBusinessForm";
import { Business } from "../../Components/types";
import { YellowPageApi } from "../../Services/YellowPageApi";

const EditBusinessPage = () => {
  const [business, setBusiness] = useState<Business>();
  const [loading, setLoading] = useState<boolean>(true);

  let { id } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      if (id) {
        const businessResp = await new YellowPageApi().getBusiness(id);
        setBusiness(businessResp.data);
      }
      setLoading(false);
    };
    fetchData();
  }, []);

  const removeHandler = async () => {
    if (business?.id !== undefined) {
      await new YellowPageApi().removeBusiness(business.id.toString());
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
          {business ? (
            <EditBusinessForm
              id={business.id ? business.id.toString() : ""}
              item={business}
            />
          ) : (
            <h1>business not found</h1>
          )}
        </>
      ) : (
        <h1>loading</h1>
      )}
    </>
  );
};

export default EditBusinessPage;
