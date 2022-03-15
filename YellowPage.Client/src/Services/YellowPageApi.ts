import { Business, Person } from "../Components/types";
import { HttpClientBase } from "../Utils/HttpClientBase";

export class YellowPageApi extends HttpClientBase {
  public constructor() {
    super("https://localhost:7113/api");
  }

  public getBusinesses = () => this.instance.get<Business[]>("/business");

  public getBusiness = (id: string) =>
    this.instance.get<Business>(`/business/${id}`);

  public createBusiness = (business: Business) =>
    this.instance.post<Business>("/business", business);

  public updateBusiness = (id: string, business: Business) =>
    this.instance.put<Business>(`/business/${id}`, business);

  public removeBusiness = (id: string) =>
    this.instance.delete(`/business/${id}`);

  public createPeople = (person: Person) =>
    this.instance.post<Person>("/person", person);

  public updatePerson = (id: string, person: Person) =>
    this.instance.put<Person>(`/person/${id}`, person);

  public removePerson = (id: string) => this.instance.delete(`/person/${id}`);

  public getPeople = () => this.instance.get<Person[]>("/person");

  public getPerson = (id: string) => this.instance.get<Person>(`/person/${id}`);
}
