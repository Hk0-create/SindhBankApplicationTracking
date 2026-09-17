# Sindh Bank — Application Tracking

A lightweight ASP.NET Core MVC web page that lets applicants check the
current status of their submitted application using their Tracking ID.
Built to be attached to Sindh Bank's official website via URL, matching
the bank's green-and-white branding.

## Features

- Bilingual (English + Urdu) UI, styled to match Sindh Bank's official
  site theme
- Single-page, fully responsive layout (no scrolling on any screen size)
- Applicant enters a Tracking ID and instantly sees their application
  status: **In Process**, **Rejected**, or **Approved**
- Status data is served from SQL Server via a stored procedure

## Tech Stack

- **Framework**: ASP.NET Core MVC, .NET 10
- **Database**: SQL Server (ADO.NET + stored procedure, no ORM)
- **Frontend**: Razor Views, plain CSS (no frontend framework)

## Project Structure

Controllers/ → TrackingController.cs (handles ID lookup)
Models/ → TrackingViewModel.cs
Views/ → Tracking/Index.cshtml + Shared/_Layout.cshtml
wwwroot/ → CSS, images (logo, etc.)
