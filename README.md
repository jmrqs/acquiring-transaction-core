# Acquiring - Transaction Core

Transactional core for an acquiring platform, built as a modular monolith for high-scale and reliable financial operations within a distributed ecosystem.
## 🐳 Get started

### ✅ Build and start containers

```bash
docker-compose up --build
```

## 🌐 Services

| Service        | URL                               | Description                   |
|----------------|-----------------------------------|-------------------------------|
| **Web API**    | http://localhost:8080             | API Endpoint                  |
| **Scalar Docs**| http://localhost:8080/scalar/v1   | API Documentation             |
| **RabbitMQ UI**| http://localhost:15672            | RabbitMQ Management Dashboard |
| **SQL Server** | localhost:18001                   | SQL Server Instance           |

### 🧰 Tech Stack

| Category          | Technology                |
|-------------------|---------------------------|
| **Backend**       | .NET 9 (C#, .NET Web API) |
| **Database**      | SQL Server 2019           |
| **Messaging**     | RabbitMQ 3.11.7           |
| **Virtualization**| Docker                    |
| **API Docs**      | OpenAPI, Scalar           |
