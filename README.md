# ApartmentFinder — Historical C# Learning Project

**Status:** Educational prototype, not a verified live apartment search service. This independent C#/.NET 7 console application experiments with property filtering, price comparisons, notification messages, and a sample web-scraper class.

## What's in the repository
- `ApartmentFinder/Program.cs` creates an example search/comparison flow.
- `ApartmentFinder/AdvancedSearch.cs` contains search logic.
- `ApartmentFinder/UpdatedWebScraper.cs` is illustrative HtmlAgilityPack code requiring site-specific parsing and permission to scrape; not a real listing integration.
- `ApartmentFinder/DatabaseManager.cs` is optional MySQL example code, not part of the default demo path.

## Local development
.NET 7 is out of support. A compatible .NET SDK is needed for historical builds; this repository has **not been independently compiled or runtime-verified in the current portfolio audit**. Modernize dependencies and add automated tests before promoting it as a production-ready app.

```bash
dotnet restore ApartmentFinder.sln
dotnet run --project ApartmentFinder/ApartmentFinder.csproj
```

## Database credential safety
**Never commit passwords or connection strings with secrets.** An earlier historical version of this repository contained a password-like value directly in `ApartmentFinder/Constants.cs`. The current branch reads the optional connection string from `APARTMENTFINDER_DB_CONNECTION_STRING` instead. Do not reuse the former value. If it was a real credential, rotate it on the database and any other service where it was reused.

For database exercises, set a connection string locally in an environment variable and run the application only against a database you administer, using a least-privileged user. The default sample flow does not require this variable.

**Important:** Updating the latest file does **not** remove the historical value from Git history or from copies; sensitive history cleanup is a separate operation.

## Portfolio positioning
Keep as a historical learning project. For a more recent operational application with automated tests, see [Meridian ERP](https://github.com/Esoham/Meridian-ERP) or [MerchantFlow](https://github.com/Esoham/merchantflow).
