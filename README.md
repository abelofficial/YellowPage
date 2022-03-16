# Yellow Page App

A Yellow page application for keeping track of information of Businesses and People. This application was made as part of SALT bootcamp assignment for making a fullstack web project within one day. The project uses .Net (C#) as backend, React as frontend, and SQL using EntityFramework for database.

## Findings

While doing this project one strangle i faced was mapping request DTO objects to entity models. The solution was using a third-party library called Auto-mapper. By using Auto-mapper, I was able to define how i want each DTO to be mapped to the corresponding entity model. This mapping definitions can be found in `YellowPage.Api/Profiles`

## Scripts

### Project setup backend

- `git clone https://github.com/abelofficial/YellowPage.git`
- `cd YellowPage.Api`
- `dotnet restore`
- `docker-compose up`
- `dotnet ef database update`

### Project setup frontend

- `cd YellowPage.Client`
- `npm i`

### Running Backend

- `cd YellowPage.Api`
- `dotnet watch run`

### Running frontend

- `cd YellowPage.Client`
- `npm start`
