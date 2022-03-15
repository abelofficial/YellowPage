import React, { FormEvent } from "react";
import { YellowPageApi } from "../../Services/YellowPageApi";
import { Person } from "../types";
import { AddNewPersonFormType } from "./types";

const AddPersonForm = () => {
  const submitHandler = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const targets = e.target as typeof e.target & AddNewPersonFormType;
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
    await new YellowPageApi().createPeople(newPerson);
  };
  return (
    <form onSubmit={submitHandler} className='form'>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='firstName'>
          First name
        </label>
        <input type='text' name='firstName' className='form__input' required />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='lastName'>
          Last name
        </label>
        <input type='text' name='lastName' className='form__input' required />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='email'>
          Email address
        </label>
        <input type='text' name='email' className='form__input' required />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='phoneNumber'>
          Phone number
        </label>
        <input
          type='text'
          name='phoneNumber'
          className='form__input'
          required
        />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='webSite'>
          Website
        </label>
        <input type='text' name='webSite' className='form__input' required />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='country'>
          Country
        </label>
        <input type='text' name='country' className='form__input' required />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='city'>
          City
        </label>
        <input type='text' name='city' className='form__input' required />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='address'>
          Address
        </label>
        <input type='text' name='address' className='form__input' required />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='zipCode'>
          Postal code
        </label>
        <input type='text' name='zipCode' className='form__input' required />
      </div>

      <button
        id='btnAddTodo'
        type='submit'
        className='button button--bg-green button__submit'
      >
        Add
      </button>
    </form>
  );
};

export default AddPersonForm;
