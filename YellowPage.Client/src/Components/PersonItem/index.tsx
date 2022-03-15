import React from "react";
import { useNavigate } from "react-router-dom";
import { Person } from "../types";

export interface PersonItemProps {
  item: Person;
}

const PersonItem = ({ item }: PersonItemProps) => {
  const navigate = useNavigate();

  return (
    <div className='card'>
      <img src='/person_placeholder.png' alt='' className='image__avatars' />
      <h3 className='text'>
        {item.firstName} {item.lastName}
      </h3>
      <div className='card__detailContainer'>
        <small className='text--bold'>
          Phone:
          <span className='text--highlighted spacing-xs'>
            {item.contact.phoneNumber}
          </span>
        </small>
        <small className='text--bold'>
          Email:
          <span className='text--highlighted spacing-xs'>
            {item.contact.email}
          </span>
        </small>
        <small className='text--bold'>
          Website:
          <span className='text--highlighted spacing-xs'>
            {item.contact.webSite}
          </span>
        </small>
        <div>
          <small className='text--bold'>
            Address:
            <span className='text--highlighted spacing-xs'>
              {item.contact.location?.country},
            </span>
            <span className='text--highlighted spacing-xs'>
              {item.contact.location?.city},
            </span>
            <span className='text--highlighted spacing-xs'>
              {item.contact.location?.address},
            </span>
            <span className='text--highlighted spacing-xs'>
              {item.contact.location?.zipCode}
            </span>
          </small>
        </div>
      </div>
      <button
        className='button button--bg-yellow button--pos-right'
        onClick={() => navigate(`/edit/person/${item.id}`)}
      >
        Edit
      </button>
    </div>
  );
};

export default PersonItem;
