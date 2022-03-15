import React, { FormEvent } from "react";
import { useNavigate } from "react-router-dom";
import { YellowPageApi } from "../../Services/YellowPageApi";
import { Person, PersonFormType } from "../types";

export interface EditPersonFormProps {
  id: string;
  item: Person;
}

const EditPersonForm = ({ id, item }: EditPersonFormProps) => {
  const navigate = useNavigate();

  const submitHandler = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const targets = e.target as typeof e.target & PersonFormType;
    const newPerson: Person = {
      firstName: targets.firstName.value,
      lastName: targets.lastName.value,
      contact: {
        email: targets.email.value,
        phoneNumber: targets.phoneNumber.value,
        webSite: targets.webSite.value,
        location: {
          country: targets.country.value,
          city: targets.city.value,
          zipCode: targets.zipCode.value,
          address: targets.address.value,
        },
      },
    };
    await new YellowPageApi().updatePerson(id, newPerson);
    navigate("/");
  };
  return (
    <form onSubmit={submitHandler} className='form'>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='firstName'>
          First name
        </label>
        <input
          type='text'
          name='firstName'
          className='form__input'
          defaultValue={item.firstName}
          required
        />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='lastName'>
          Last name
        </label>
        <input
          type='text'
          name='lastName'
          className='form__input'
          defaultValue={item.lastName}
          required
        />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='email'>
          Email address
        </label>
        <input
          type='text'
          name='email'
          className='form__input'
          defaultValue={item.contact.email}
          required
        />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='phoneNumber'>
          Phone number
        </label>
        <input
          type='text'
          name='phoneNumber'
          className='form__input'
          defaultValue={item.contact.phoneNumber}
          required
        />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='webSite'>
          Website
        </label>
        <input
          type='text'
          name='webSite'
          className='form__input'
          defaultValue={item.contact.webSite}
          required
        />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='country'>
          Country
        </label>
        <input
          type='text'
          name='country'
          className='form__input'
          defaultValue={item.contact.location?.country}
          required
        />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='city'>
          City
        </label>
        <input
          type='text'
          name='city'
          className='form__input'
          defaultValue={item.contact.location?.city}
          required
        />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='address'>
          Address
        </label>
        <input
          type='text'
          name='address'
          className='form__input'
          defaultValue={item.contact.location?.address}
          required
        />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='zipCode'>
          Postal code
        </label>
        <input
          type='text'
          name='zipCode'
          className='form__input'
          defaultValue={item.contact.location?.zipCode}
          required
        />
      </div>

      <button
        id='btnAddTodo'
        type='submit'
        className='button button--bg-green button__submit'
      >
        Update
      </button>
    </form>
  );
};

export default EditPersonForm;
