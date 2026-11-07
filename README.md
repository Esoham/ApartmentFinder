# ApartmentFinder — Apartment Search & Affordability Prototype

**A renter-first product concept with a working web MVP** | HTML · CSS · JavaScript · Node tests · Historical C#/.NET

ApartmentFinder started as a C# project to help people find apartments. The goal is to **make apartment searches and affordability comparisons easier for real people**, with particular attention to up-front costs that are often less obvious than advertised rent.

> **Current status:** The demo comparison includes eight **fictional sample homes**. The site now also has an **opt-in provider-reported rental listing section** and links to independent rental marketplaces. An authorized RentCast API key has **not** been configured in the public website's source. Provider data appears only after activation and a successful refresh; unit availability is never guaranteed.

## Public web demonstration

**[Open ApartmentFinder's interactive sample demo](https://esoham.github.io/projects/apartmentfinder/)** — hosted on the existing portfolio GitHub Pages site. The demo has clearly labeled fictional rental examples and is not connected to live apartment listings.

Source for the deployed interface: [portfolio demo folder](https://github.com/Esoham/Esoham.github.io/tree/main/projects/apartmentfinder).

## Try the web demo locally

Requires Python 3 or another static file server:

```bash
python -m http.server 8000 --directory web
```

Visit **http://127.0.0.1:8000/**. The app has separate sections: (1) authorized rental feed / original rental marketplace links, and (2) fictional demo apartments with city/ZIP, rent, bedrooms, pets, move-in budgets, favorites, and three-way comparison. Local website builds without a provider key show the `not_configured` feed status.

### Core affordability calculations

- **Estimated move-in:** First full month's rent + sample security deposit + application fee + administrative fee.
- **Estimated monthly:** Rent + synthetic utility estimate + optional parking; sample pet rent is included when the pet-friendly filter is selected.

Actual rental quotes may also include insurance, prorated rent, tax, pet deposits, utility setup, or other fees. These formulas are deliberately transparent rather than presented as a complete official quote.

## QA evidence

```bash
node --test web/tests/*.test.mjs
```

The [GitHub Actions workflow](.github/workflows/apartmentfinder-web-tests.yml) runs unit tests and syntax checks on changes, including the provider-view freshness tests. See the [product vision and Agile QA test plan](docs/PRODUCT_VISION_AND_TEST_PLAN.md) for acceptance criteria, risks and future backlog.

## Real rental listings integration

The published site has a secure, **licensed-data integration ready for activation**. Provider: [RentCast's long-term rental listing API](https://developers.rentcast.io/reference/rental-listings-long-term). It requires the repository owner to configure a private `RENTCAST_API_KEY` secret in the `Esoham/Esoham.github.io` repository and run its refresh workflow. The public site **does not embed the key**.

- [Live integration setup and cost/accuracy limitations](https://github.com/Esoham/Esoham.github.io/blob/main/projects/apartmentfinder/RENTAL_DATA_SETUP.md)
- [Secure refresh workflow](https://github.com/Esoham/Esoham.github.io/blob/main/.github/workflows/apartmentfinder-rental-refresh.yml)
- [Current data-source snapshot](https://github.com/Esoham/Esoham.github.io/blob/main/projects/apartmentfinder/data/live-listings.json)

**Until a key is configured, the site offers official outbound rental-search links, not provider-fed listing cards.** Provider data includes only reported active status and recent timestamps, not independently verified availability or complete fee information. The sample apartment calculations must never be mistaken for quotes on real properties.

## Original C# project preserved

The original .NET 7 console application, models, starter search service, and optional MySQL example are still in `ApartmentFinder/`. They have **not** been replaced or claimed as production-ready. The original search currently returns placeholder records without applying all filters, and the sample web scraper is not a verified listing-data integration. .NET 7 is unsupported; the legacy code needs a separate modernization and build/test pass.

To inspect the historical console demo:

```bash
dotnet restore ApartmentFinder.sln
dotnet run --project ApartmentFinder/ApartmentFinder.csproj
```

The legacy build has not been independently verified in this release.

## Security and privacy

The browser prototype runs without third-party services or login and stores saved demo IDs in localStorage. Do not paste personal rental information into it. Previously committed credential-like text in historical C# commits was removed from the current branch earlier, but **old Git history still contains that value**; rotate any real or reused credential.

## Roadmap

The next meaningful milestone is **activating the authorized RentCast integration with a private key**, then verifying freshness, comparing against source listings, expanding authorized geography and accessible browser tests, and continuing C# modernization. Do not scrape listing sites without permission or claim fictional examples are real homes.

---

**Scope:** An independently developed educational product prototype, not a rental brokerage or production listing service.
