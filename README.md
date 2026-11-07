# ApartmentFinder — Apartment Search & Affordability Prototype

**A renter-first product concept with a working web MVP** | HTML · CSS · JavaScript · Node tests · Historical C#/.NET

ApartmentFinder started as a C# project to help people find apartments. The goal is to **make apartment searches and affordability comparisons easier for real people**, with particular attention to up-front costs that are often less obvious than advertised rent.

> **Current status:** The new web interface uses eight **fictional, sample listings**. All example prices, location descriptors and amenity tags are synthetic. This is not a live apartment aggregator; it does not display verified availability, accept rental applications, or connect renters with property managers.

## Public web demonstration

**[Open ApartmentFinder's interactive sample demo](https://esoham.github.io/projects/apartmentfinder/)** — hosted on the existing portfolio GitHub Pages site. The demo has clearly labeled fictional rental examples and is not connected to live apartment listings.

Source for the deployed interface: [portfolio demo folder](https://github.com/Esoham/Esoham.github.io/tree/main/projects/apartmentfinder).

## Try the web demo locally

Requires Python 3 or another static file server:

```bash
python -m http.server 8000 --directory web
```

Visit **http://127.0.0.1:8000/**. You can search by city/ZIP, rent ceiling, bedroom count, pet-friendly category, or maximum estimated move-in cost, save examples in your browser and compare three homes.

### Core affordability calculations

- **Estimated move-in:** First full month's rent + sample security deposit + application fee + administrative fee.
- **Estimated monthly:** Rent + synthetic utility estimate + optional parking; sample pet rent is included when the pet-friendly filter is selected.

Actual rental quotes may also include insurance, prorated rent, tax, pet deposits, utility setup, or other fees. These formulas are deliberately transparent rather than presented as a complete official quote.

## QA evidence

```bash
node --test web/tests/*.test.mjs
```

The [GitHub Actions workflow](.github/workflows/apartmentfinder-web-tests.yml) runs unit tests and syntax checks on changes. See the [product vision and Agile QA test plan](docs/PRODUCT_VISION_AND_TEST_PLAN.md) for acceptance criteria, risks and future backlog.

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

The next meaningful milestone is **an authorized and independently validated source of live apartment data**, followed by freshness indicators, genuine property links, accessible UI/browser testing, and continued C# modernization. Do not scrape listing sites without permission or claim fictional examples are real homes.

---

**Scope:** An independently developed educational product prototype, not a rental brokerage or production listing service.
