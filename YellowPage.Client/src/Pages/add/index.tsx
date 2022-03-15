import React, { useState } from "react";
import AddBusinessForm from "../../Components/AddBusinessForm";
import AddPersonForm from "../../Components/AddPersonForm";

enum FormTypeOptions {
  business = "BUSINESS",
  person = "PERSON",
}

const AddPage = () => {
  const [formType, setFormType] = useState<FormTypeOptions>(
    FormTypeOptions.business
  );

  return (
    <div className='page__add'>
      <header className='add__header'>
        <div
          className='add__section'
          onClick={() => setFormType(FormTypeOptions.person)}
        >
          <img
            src='/person_placeholder.png'
            alt=''
            className='image__avatars'
          />
          <h4
            className={
              formType === FormTypeOptions.person
                ? "text--color-yellow"
                : "text"
            }
          >
            Add person
          </h4>
        </div>
        <div
          className='add__section'
          onClick={() => setFormType(FormTypeOptions.business)}
        >
          <img
            src='/business_placeholder.png'
            alt=''
            className='image__avatars'
          />
          <h4
            className={
              formType === FormTypeOptions.business
                ? "text--color-yellow"
                : "text"
            }
          >
            Add business
          </h4>
        </div>
      </header>
      {formType === FormTypeOptions.business ? (
        <AddBusinessForm />
      ) : (
        <AddPersonForm />
      )}
    </div>
  );
};

export default AddPage;
