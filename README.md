# Project "Homework"

This simple web application shows product data from  [DummyJSON api](https://dummyjson.com/docs/products).
Only the first page of the results is used.

Solution consist of the following projects:

## Server

ASP.NET Core Web api backend which functions as a proxy between the client and the dummy api.
The project exposes one endpoint, `/Products`, which relays the calls to the DummyJSON api.
Responses sent to the Client(s) are cached globally for 5 seconds to prevent excessive amount of api calls in multi-client scenario.

### Environment variables

| Name                   | Description                                                                                                             | 
|------------------------|-------------------------------------------------------------------------------------------------------------------------|
| ASPNETCORE_URLS        | The url(s) the application is reachable from, separated by semicolon. `applicationUrl` in Properties/launchSetting.json | 
| ASPNETCORE_ENVIRONMENT | The hosting environment. Development or Production<br/> Also found in Properties/launchSetting.json                          | 
| DummyApi__BaseUrl      | DummyJSON api url (prefilled in appsettings.json)                                                                       | 
| ClientUrl | The url the Client project is running at (prefilled in appsettings.json)                                                | 

## Client

User interface built with React (+ Vite) for browsing the products available from the api.

This project also has ASP.NET project with very basic configuration, the only purpose of which is to host the React app. Not strictly necessary to use, the standalone Vite dev server should be enough on development.

### Running development setup

When running on development setup, ASP.NET project uses a proxy to the React/Vite dev server.
To setup HTTPS on dev environment, run 

`dotnet dev-certs https --export-path devcert.pem --format PEM`

and copy the generated `devcert.pem` and `devcert.key` to ~/.aspnet/https/

### Running production mode

On production mode the built static files are served from Client/wwwroot. 
Hence, running this project on production mode requires `npm run build` to be run first. 


### Environment variables

#### ASP.NET Host

| Name                   | Description                                                                                                                                                                                      | 
|------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ASPNETCORE_URLS        | The url(s) the application is reachable from, separated by semicolon. Needs to match `ClientUrl` on the Server. <br/>Relevant only for production build. Dev mode runs at https://localhost:5002 | 
| ASPNETCORE_ENVIRONMENT | The hosting environment. Development or Production.<br/> Also found in Properties/launchSetting.json                                                                                                  | 
| ASPNETCORE_HOSTINGSTARTUPASSEMBLIES      | Development mode only, value: `Microsoft.AspNetCore.SpaProxy`                                                                                                                                    | 

#### React/Vite app

| Name                   | Description                                                                                    | 
|------------------------|------------------------------------------------------------------------------------------------|
| VITE_SERVER_BASE_URL        | Server's url. This needs to be available <i>on build time</i> when running on production mode. | 

