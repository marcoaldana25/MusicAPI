# MusicAPI

This project is built on .NET 8.0 and integrates with Spotify's Web API: https://developer.spotify.com/documentation/web-api

## Design
MusicAPI follows the IDesign architecture pattern, more in depth information can be found here: https://www.idesign.net/.

Below is a listing of how the application is structured

- Client Layer:
    - Responsible for consumer facing integration such as API Controllers and application setup. There should be limited business logic on this layer and should only
    be focused on accepting requests and returning data to the end user
- Manager Layer:
    - Responsible for directing workflow between the client layer and any additional layers. Business logic should be minimal here and should mostly be pass through to keep the layers separate. This
    layer can also contain items that are exposed to the end user such as ViewModel response objects
- Engine Layer:
    - Responsbile for heavier business logic/data processing. Any data manipulation that exceeds response object data mapping can live in this layer, or additional items that translate the data
    further that a pass through between Client and Accessor layers.
- Accessor Layer:
    - Responsible for the Data Access to external entities. This can include, but is not limited to, external API's (in this case Spotify's Web API), databases that may be setup, and additional
    external data applications. This layer is also responsible for in memory caching and storing of items such as developer authentication tokens
- Utilities Layer:
    - Intended to be an all-encompassing layer that may host methods and classes necessary for any application layer. This project abstracts the retrieval of appsettings.json data into this layer as 
    an example.
- Unit Tests:
    - Responsbile for the testing of their respective application layers and classes.
- Solution Items:
    - Hosts items such as this Readme, and any other project documentation or application standard file.


## Project Setup
To run MusicAPI, you will need the .NET 8.0 runtime and sdk installed on your machine. More information on downloading .NET 8.0 can be found here: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

As of writing this Readme, this project does not contain databases that need local setup.

Music API does make use of a user secrets.json file to abstract out secure client credentials from source control. When setting up this project, consider following these setup steps:
1. Right click on any project within the app and select **Manage User Secrets** (This should create a blank secrets.json file)
1. Copy the contents from the appsettings.json file and paste the values into the **secrets.json** file
1. Follow the developer **Getting Started** documentation provided from Spotify to authorize your spotify account and retieve the base access token https://developer.spotify.com/documentation/web-api/tutorials/getting-started
    1. This documentation will walk you through getting a developer account setup, obtaining client ID's and secrets, granting the API authorization to make requests on your behalf, and retrieving an access token to 
    make additional requests to the Spotify API.

After following the steps listed above, set the runtime to **IIS Express** and hit the **Run Application** button within Visual Studio. You should be presented with a Swagger page for the Spotify Controller.

## Making Requests
Music API for Spotify follows the Authorization Code flow: https://developer.spotify.com/documentation/web-api/tutorials/getting-started

This flow describes the process of authenticating the Spotify Account to make requests on the users behalf, how to retrieve an access bearer token, and how to retrieve a
refresh token upon bearer token expiration. To prevent making multiple requests to gain a bearer token unnecessairly, the active bearer token is cached using In-Memory caching for the lifetime 
of the bearer token. By default, the bearer token returned from Spotify has a lifetime of 3600 or 1 hour. After the token expires and the cache expires, a new token is retrieved and 
stored in the same manner.

## Project Deployment
As of writing this Readme, there are no intentions to deploy this API. This project is mostly used as a learning opportunity to keep my skills sharp and to continue learning
new practices.