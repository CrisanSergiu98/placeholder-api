# PlaceholderApi 🧪

A lightweight, RESTful ASP.NET Core Web API for generating realistic, randomized mock data—perfect for testing, prototyping, and development.

---

## 📘 Introduction

PlaceholderApi gives you instant access to high-quality fake data—no external dependencies required. It supports both controller-based and minimal API routing, making it flexible for small utilities or full-scale applications. With CSV-backed data generation and clean separation of concerns, it's built for speed, clarity, and extensibility.

---

## 🚀 Features

- ✅ Generate full mock profiles (name, email, phone, address, DOB)  
- ✅ Retrieve atomic data types individually: addresses, phone numbers, emails, names, and DOBs  
- ✅ RESTful architecture with clean, intuitive endpoints  
- ✅ Supports both controller-based and minimal API routing  
- ✅ CSV-backed data generation for realistic and customizable output  
- ✅ Asynchronous address generation for high-performance batch processing  
- ✅ Easily extensible—add new endpoints for companies, job titles, lorem text, and more  
- ✅ Query parameters for flexible data generation (e.g., quantity, filters, format)  
- ✅ Ready for Swagger/OpenAPI documentation and testing

---

## 🧱 Project Structure

The project is organized using a clean separation of concerns. Each layer handles a specific responsibility, making the codebase easy to navigate and extend. You'll find controllers for structured endpoints, minimal APIs for utility routes, services for business logic, and repositories for data access.

📁 Placeholder.API       # ASP.NET Core Web API project  
📁 Placeholder.Core      # Core logic and shared interfaces  
📁 Placeholder.Data      # CSV-backed data sources and repositories  
📁 Placeholder.Domain    # Domain models and abstractions

---

## 🛠️ Getting Started

To get started with PlaceholderApi:

1. Clone the repository  
```bash
git clone https://github.com/your-username/PlaceholderApi.git
cd PlaceholderApi
```

2. Build the solution using Visual Studio, Rider, or your preferred IDE.

3. Ensure CSV files are copied to the output directory. In `Placeholder.Data.csproj`, add:  
```Xml
<ItemGroup>
  <None Update="Data/*.csv">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </None>
</ItemGroup>
```

4. Run the API  
```bash
dotnet run --project PlaceholderApi
```

5. Open Swagger UI in your browser  
```text
https://localhost:{port}/swagger
```

---

## 🔑 Core Concepts

- **ProfilesService** – Orchestrates the generation of mock profiles using injected repositories and async address generation  
- **ProfilesRepository** – Loads CSV-backed data and generates randomized profile fields  
- **AddressRepository** – Supplies random addresses from a seed file  
- **AddressService** – Generates addresses asynchronously for parallel performance  
- **Minimal API Endpoints** – Lightweight routes for atomic data types like phones, emails, and DOBs  
- **Controllers** – Used for structured resources like `/profiles`

---

## 🔗 API Endpoints

| Endpoint         | Method | Description                          |
|------------------|--------|--------------------------------------|
| `/profiles`      | GET    | Returns full mock user profiles      |
| `/addresses`     | GET    | Returns random addresses             |
| `/phones`        | GET    | Returns random phone numbers         |
| `/emails`        | GET    | Returns random email addresses       |
| `/names`         | GET    | Returns random first and last names |
| `/dob`           | GET    | Returns random dates of birth        |

> All endpoints support the `?quantity=` query parameter for batch generation.

---

## 💡 Usage Examples

```http
GET /profiles?quantity=5
GET /phones?quantity=10
GET /addresses?quantity=3
GET /emails?quantity=20
GET /names?quantity=15
GET /dob?quantity=10
```

---

## ⚙️ Setup Instructions

Make sure your CSV files are copied to the output directory.  
```Xml
<ItemGroup>
  <None Update="Data/*.csv">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </None>
</ItemGroup>
```

Then run the API  
```bash
dotnet run --project PlaceholderApi
```

---

## 🧠 Design Philosophy

- Keep generation logic in services for testability  
- Repositories handle raw data access and randomization  
- Minimal APIs are used for utility-style endpoints  
- Controllers are used for structured, composite resources

---

## ⚙️ Async Usage in the Project

This project uses asynchronous programming to enable parallel data generation, improving performance during high-volume operations. CSV file loading remains synchronous, as it's only performed once at startup and doesn't impact runtime responsiveness.

---

## 🛤️ Roadmap & Future Ideas

- Add support for company names and job titles  
- CSV or Excel export options  
- Seeded randomness for reproducible results  
- Rate limiting and API key support  
- Docker containerization  
- Async CSV reloading for dynamic data updates

---

## 🤝 Contributing

Pull requests are welcome! If you’d like to add new data types or improve generation logic, feel free to fork and submit a PR.

---

## 📄 License

MIT License. Use freely, modify boldly.
