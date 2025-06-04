# Acquiring - Transaction Core

Transactional core for an acquiring platform, built as a modular monolith for high-scale and reliable financial operations within a distributed ecosystem.
## 🐳 Get started

### ✅ Build and start containers

```bash
run project docker-compose (seed included)
```

## 🌐 Services

| Service        | URL                               | Description                          |
|----------------|-----------------------------------|--------------------------------------|
| **Web API**    | http://localhost:8080             | API Endpoint                         |
| **RabbitMQ UI**| http://localhost:15672            | RabbitMQ Management Dashboard        |
| **SQL Server** | localhost:18001                   | SQL Server Instance                  |
| **Scalar Docs**| http://localhost:8080/scalar/v1   | API Documentation                    |
| **Prometheus** | http://localhost:9090             | Metrics Scraping and Query Dashboard |
| **Grafana**    | http://localhost:3000             | Observability Dashboards and Visuals |

### 🧰 Tech Stack

| Category          | Technology                |
|-------------------|---------------------------|
| **Backend**       | .NET 9 (C#, .NET Web API) |
| **Database**      | SQL Server 2019           |
| **Messaging**     | RabbitMQ 3.11.7           |
| **Virtualization**| Docker                    |
| **API Docs**      | OpenAPI, Scalar           |
| **Metrics**       | Grafana, Prometheus       |
