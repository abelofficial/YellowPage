export interface Business {
  id?: number;
  name: string;
  description?: string;
  contact: Contact;
}

export interface Person {
  id?: number;
  firstName: string;
  lastName: string;
  contact: Contact;
}

export interface Contact {
  id?: number;
  email: string;
  phoneNumber: string;
  webSite: string;
  location?: Location;
}

export interface Location {
  id?: number;
  country: string;
  city: string;
  zipCode: string;
  address: string;
}

export type BusinessFormType = {
  name: { value: string };
  description: { value: string };
  email: { value: string };
  phoneNumber: { value: string };
  webSite: { value: string };
  country: { value: string };
  city: { value: string };
  address: { value: string };
  zipCode: { value: string };
};

export type PersonFormType = {
  firstName: { value: string };
  lastName: { value: string };
  email: { value: string };
  phoneNumber: { value: string };
  webSite: { value: string };
  country: { value: string };
  city: { value: string };
  address: { value: string };
  zipCode: { value: string };
};
