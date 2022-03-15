import { Business, Person } from "../Components/types";
import { HttpClientBase } from "../Utils/HttpClientBase";

export class YellowPageApi extends HttpClientBase {
  public constructor() {
    super("https://localhost:7113/api");
  }

  public getBusinesses = () => this.instance.get<Business[]>("/business");

  public getPeople = () => this.instance.get<Person[]>("/person");

  public getBusiness = (id: number) =>
    this.instance.get<Business>(`/users/${id}`);
}
