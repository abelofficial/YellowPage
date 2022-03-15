export interface Business {
  id: number;
  name: string;
  description?: number;
  contact: Contact;
}

export interface Person {
  id: number;
  firstName: string;
  lastName: string;
  contact: Contact;
}

export interface Contact {
  id: number;
  email: string;
  phoneNumber: string;
  webSite: string;
  location?: Location;
}

export interface Location {
  id: number;
  country: string;
  city: string;
  zipCode: string;
  address: string;
}
