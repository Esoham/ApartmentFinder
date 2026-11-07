# ApartmentFinder real-rental search integration

This repository is the original ApartmentFinder product source, including its historical C# project and the mirrored static web demo.

The public [ApartmentFinder site](https://esoham.github.io/projects/apartmentfinder/) has two **clearly separated** areas:

1. **Provider-sourced rental lookup**: An opt-in RentCast feed showing provider-reported active listings only if a secret key and a successful recent refresh exist. It displays reported rent and listing metadata but does **not** assert verified vacant units or infer unknown fees.
2. **Sample affordability comparison**: Eight entirely fictional homes used for search, budgeting, favorites and test exercises. Their move-in costs are example arithmetic only.

Until the data feed is activated, the website provides official links to [Apartments.com listings in College Park](https://www.apartments.com/college-park-ga/) and [Atlanta](https://www.apartments.com/atlanta-ga/) for actual live searches. ApartmentFinder does **not** scrape those sources.

## Secret and activation
RentCast uses a key. Never put that key into `web/`, README, JSON, GitHub issues, or a frontend request. The secured workflow is maintained in the portfolio-site repository:

[Full setup, provider licensing and overage-cost instructions](https://github.com/Esoham/Esoham.github.io/blob/main/projects/apartmentfinder/RENTAL_DATA_SETUP.md).

When you run this source repository's static site locally, `web/data/live-listings.json` starts as `not_configured` because no licensed records are bundled. The deployed site's snapshot is refreshed by a GitHub Actions job after the owner activates it.

## Tests
```bash
node --test web/tests/*.test.mjs
```

The 14 original unit tests plus new provider snapshot freshness/filter tests run without external API calls. The legacy .NET 7 application is not runtime-verified by these tests.
