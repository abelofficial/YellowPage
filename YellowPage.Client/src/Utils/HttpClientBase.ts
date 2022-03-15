import axios, { AxiosInstance, AxiosResponse } from "axios";

export abstract class HttpClientBase {
  protected readonly instance: AxiosInstance;

  public constructor(baseURL: string) {
    this.instance = axios.create({
      baseURL,
    });
  }
}
