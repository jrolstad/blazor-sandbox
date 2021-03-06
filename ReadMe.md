# Blazor Sandbox
A sandbox for learning and using ASP.NET Blazor

# Requirements
* .NET Core 3.2 or Higher

# Projects
## blazor.wasm.ghpages
Blazor WebAssembly project that is self-hosted on Github Pages.  Showcases how to:

1. Create a standalone Blazor app
2. Host as a static Blazor app on Github Pages (for free)
3. Use Azure AD authentication in a Blazor WebAssembly application
4. Call authenticated APIs (Microsoft Graph) with the logged in user's tokens
5. Enable a standalone Blazor to be functional as a Progressive Web App (PWA) and work offline
6. Build, Publish, and Deploy to Github pages with Github Actions

## blazor.wasm.ghpages.tests
Unit tests for the Blazor project using [bUnit](https://bunit.egilhansen.com/index.html).

# Actions
## deploy-app-to-gh-pages
![deploy-app-to-gh-pages](https://github.com/jrolstad/blazor-sandbox/workflows/deploy-app-to-gh-pages/badge.svg)

Every time code is pushed to master, the projects are built, unit tests ran, and the project pushed to GitHub pages so it is available at [https://jrolstad.github.io/blazor-sandbox/](https://jrolstad.github.io/blazor-sandbox/)



