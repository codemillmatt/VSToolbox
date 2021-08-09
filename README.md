# VS Toolbox Episode

## Demo Outline

### Demo 1 - Use Case of Supporting Citizen Devs

- Minimal Web API to Azure SQL
- Deploy to Azure App Service
- Deploy to APIM
- Create a custom connector
- Create a forms over data app

### Demo 2 - Use Case of Replacing an Existing App

- Grab OpenAPI Doc
- Create custom connector
- Create forms over data app

### Demo 3 - OpenAPI for Functions

- Create Azure Function
- Put OpenAPI into it
- Deploy
- Consume

## Demo Steps

### Demo 1

#### Prereq's

- VM started
- RDP opened
- VS running with solution opened
- Power Apps Maker opened in local tab

#### Steps

- Show the Power App (just UI filled out)
- Build up backend - switch to VS
- Show `GetAllVendors` and `AddRating`
- Run locally & use Swagger test harness
- Add in some Swagger documentation
- Change the OpenAPI info in the `ConfigureServices`
  - Add a `Description` and a `Contact` (of type `OpenApiContact`)
- Add in XML documentation
  - into the csproj
  
    ```xml
    <PropertyGroup>
        <GenerateDocumentationFile>true</GenerateDocumentationFile>
        <NoWarn>$(NoWarn);1591</NoWarn>
      </PropertyGroup>
    ```

  - into the `Startup.cs`
  
    ```csharp
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    ```

  - add xml docs to `VendorController.GetAllVendors`
  
    ```xml
    /// <summary>
    /// Returns all the vendors in the database
    /// </summary>
    /// <returns>A list of vendors</returns>
    /// <response code="200">Returns a list of all vendors</response>
    ```

- Add `[ProducesResponseType(200)]` to `VendorController.GetAllVendors`
- Add `[Produces("application/json")]` to `VendorController` class level
- Add some `[Required]` to the `Vendor` class
- Run the website again and see the updated changes
- Deploy to App Service and to APIM
- Go to the Portal and view it in APIM
- Test it
- Create a Power Connector for it
- Go to the Maker and under custom connectors look for the new name
  - View it
- Create a new connection from the connector page
- Open the app up
- Add a new connection to the data source
- `LoadData` button: `ClearCollect(Vendors, VendorReviewAPI.getapivendor())`
- `VendorGallery.Text`: `ThisItem.name`
- `VendorGallery.Label3.Text`: `"Avg Rating: " & Average(ThisItem.ratings, rating)`
- `Gallery3.Items`: `VendorGallery.Selected.ratings`
- `Gallery3.Title4.Text`: `ThisItem.review`
- `Gallery3.Subtitle2.Text`: `ThisItem.rating`
- `SubmitRating.OnSelect`: `VendorReviewAPI.postapirating({vendorId:VendorGallery.Selected.id,rating:VendorRating.Value,review:RatingReviewText.Text});ClearCollect(Vendors,VendorReviewAPI.getapivendor());`

### Demo 2

- Download the swagger file from APIM
- View it with VS Code
- Create a connector with it

### Demo 3

- Work through the Function tutoral on docs

**Delete the SAT resource group**
