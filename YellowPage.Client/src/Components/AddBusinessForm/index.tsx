import React, { FormEvent } from "react";
import { useNavigate } from "react-router-dom";
import { YellowPageApi } from "../../Services/YellowPageApi";
import { Business, BusinessFormType } from "../types";

const AddBusinessForm = () => {
  const navigate = useNavigate();

  const submitHandler = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const targets = e.target as typeof e.target & BusinessFormType;
    const newBusiness: Business = {
      name: targets.name.value,
      description: targets.description.value,
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
    await new YellowPageApi().createBusiness(newBusiness);
    navigate("/");
  };
  return (
    <form onSubmit={submitHandler} className='form'>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='name'>
          Organization name
        </label>
        <input type='text' name='name' className='form__input' required />
      </div>
      <div className='form__inputContainer'>
        <label className='text__inputLabel' htmlFor='description'>
          Description
        </label>
        <input
          type='text'
          name='description'
          className='form__input'
          required
        />
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

export default AddBusinessForm;
