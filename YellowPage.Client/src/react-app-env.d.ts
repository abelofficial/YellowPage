declare global {
  namespace NodeJS {
    interface ProcessEnv {
      REACT_APP_YELLOW_PAGE_API: string;
      NODE_ENV: "development" | "production";
    }
  }
}

export {};
