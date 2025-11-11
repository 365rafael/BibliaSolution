# 📖 BibliaApp

**BibliaApp** é um projeto composto por duas partes integradas:
1. Uma **API RESTful** desenvolvida em **ASP.NET Core 8.0**, responsável por fornecer dados bíblicos.
2. Uma **interface web em Blazor Server**, que consome essa API para exibir o **Versículo do Dia**, além de permitir **busca por livro e tema**.

---

## 🏗️ Estrutura do Projeto

BibliaApp/
├── Biblia.API/ # API REST com Entity Framework Core e SQLite
├── Biblia.Blazor/ # Interface Web em Blazor Server
├── Biblia.Core/ # Entidades, DTOs e contratos compartilhados
├── Biblia.Data/ # Contexto e repositórios (EF Core)
└── Biblia.Service/ # Serviços e lógica de negócio

---

## ⚙️ Tecnologias Utilizadas

### Backend (API)
- **ASP.NET Core 8.0**
- **Entity Framework Core 8**
- **SQLite**
- **Repository + Service Pattern**
- **AutoMapper**
- **IMemoryCache** (cache diário para o versículo do dia)

### Frontend (Interface Blazor)
- **Blazor Server**
- **Bootstrap 5.3**
- **C# / Razor Components**
- **Integração direta com a API**
- **Layouts responsivos e leves**

---

## 🚀 Funcionalidades

### 📖 API Bíblia
- **Versículo do Dia**: retorna aleatoriamente um versículo positivo, com cache diário.  
- **Busca por Livro e Capítulo**: lista todos os versículos de um livro ou capítulo específico.  
- **Busca por Tema**: pesquisa versículos relacionados a um tema (ex: amor, fé, esperança).  

Exemplo de endpoint:

GET /api/versiculo/do-dia
GET /api/livro/{nomeOuAbrev}/{capitulo?}
GET /api/tema/{palavra}

### 💻 Interface Blazor
- Página inicial com **Versículo do Dia** centralizado e estilizado.
- Páginas de **Busca por Livro** e **Busca por Tema**.
- Interface moderna e responsiva com **Bootstrap**.
- Comunicação com a API via `HttpClient`.

---

## 🔧 Como Executar Localmente

### 1️⃣ Clonar o repositório
```bash
git clone https://github.com/rafaelarantes/BibliaSolution.git
cd BibliaApp

Executar API:
cd Biblia.API
dotnet run

Executar interface Blazor:
cd ../Biblia.Blazor
dotnet run
A aplicação Blazor rodará em: https://localhost:7173

🧩 Banco de Dados

O projeto utiliza SQLite para simplicidade e portabilidade.
As tabelas são criadas automaticamente via migrations.

🧠 Arquitetura

O projeto segue boas práticas de arquitetura em camadas:
Biblia.Core contém as entidades e DTOs.
Biblia.Service aplica regras de negócio e cache.
Biblia.Data faz a persistência com EF Core.
Biblia.API expõe os endpoints.
Biblia.Blazor consome os endpoints da API.

🧑‍💻 Autor

Rafael Arantes da Silva
📍 Prata, MG — Brasil
💼 [LinkedIn](https://www.linkedin.com/in/rafaelarantes365/)
📧 rafael.imu@gmail.com

🌟 Objetivo do Projeto

O BibliaApp nasceu como um estudo prático de integração entre API .NET 8 + Blazor Server, aplicando padrões de arquitetura, caching, consumo de dados e interface amigável — tudo em C# full stack.

