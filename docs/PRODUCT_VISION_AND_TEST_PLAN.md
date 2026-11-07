# ApartmentFinder — renter-first product vision and test plan

## Product statement
People searching for apartments need a way to evaluate affordability and upfront cost, not just advertised rent. ApartmentFinder aims to help renters search, compare and understand total costs before contacting a property. **The current site is an independent educational prototype, not a public live listing aggregator.**

## Current milestone (web MVP)
- Accessible static site in `web/` with eight clearly labeled **fictional** metro-Atlanta examples.
- Filter by city, ZIP prefix, rent limit, minimum bedrooms, max estimated move-in cost, pet-friendly status, and saved homes.
- Sort by rent, move-in estimate or estimated monthly total.
- Save favorite IDs in the browser using localStorage; no accounts, trackers or server storage.
- Compare three example homes side-by-side.
- Show cost assumptions and limitations clearly; no claim of accurate pricing or listing availability.
- No web scraping, external APIs, payments, contact forms, or actual property inquiries.

## Cost definitions
**Estimated move-in = first full month's rent + security deposit + application fee + administrative fee.** It intentionally excludes prorating, additional deposits, insurance, local fees, and incentives.

**Estimated monthly total = advertised sample rent + sample utility estimate + optional parking fee.** A pet-rent amount is included when the "Pet-friendly only" checkbox is selected, to illustrate a possible recurring cost; this is not a guarantee that pets are accepted in any actual rental.

All numbers are whole USD values for fictional examples. Actual rental properties can have different billing rules.

## Test strategy (Agile QA)
| Scenario | Category | Expected behavior |
|---|---|---|
| Search by rent 780 or 779 | Boundary-value | Lowest-cost example included at 780, excluded at 779 |
| Select city + exact ZIP | Black-box functional | Only matching city and ZIP sample shown |
| Select 2+ bedrooms | Equivalence class | Studios and 1BR examples excluded |
| Enter a move-in ceiling | Calculated-field integration | Compare actual computed formula, not advertised rent |
| Save and filter favorites | State/data | Only saved IDs displayed; malformed localStorage gracefully ignored |
| Compare four homes | Negative | Fourth selection rejected with accessible explanation |
| Compare, then remove | State transition | Selection toggles off without mutating other choices |
| Untrusted sample listing name | Security design | DOM uses textContent rather than injecting markup |
| Filter down to no results | Empty state | User sees a helpful empty-state message |
| Navigate with keyboard | Accessibility manual check | All controls reachable, visible focus and labels |

Automated logic checks run with `node --test web/tests/*.test.mjs` and GitHub Actions. Visual/keyboard testing and the legacy C#/.NET 7 application are **not yet claimed as independently runtime-verified** in this milestone.

## Future backlog / acceptance gates
1. **Authorized live-data provider:** Decide on a legitimate listing API, licensing terms, refresh schedules, deduplication and attribution. Never claim current availability from synthetic demo data.
2. **Data quality:** Validate rent/fee provenance, currency, listing timestamps, location, and a "last verified" field.
3. **Accessible live UI:** Add actual permitted photos, geocoded maps, stale-data warnings, keyboard/screen-reader tests and mobile E2E tests.
4. **Privacy/security:** Define user accounts only if necessary, secure secrets server-side, rate limits, opt-in alerts and abuse prevention.
5. **Legacy C# modernization:** Update the original .NET 7 solution, model/search implementations and database boundary under separate tested PRs.
6. **Release review:** Confirm authorized data, legal and data-quality requirements, clear error states, manual QA, and server monitoring before marketing it as a real apartment-finding service.

## Local preview
From the repository root:

```bash
python -m http.server 8000 --directory web
```

Open http://127.0.0.1:8000. ES modules require an HTTP server; do not open `index.html` using `file://`.

## Potential deployment
GitHub Pages can serve the static `web/` directory through a Pages deployment workflow after Pages is enabled in the repo settings. This milestone does not assert that a live Pages site is configured or deployed.
