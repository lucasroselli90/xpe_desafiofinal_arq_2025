# 📦 Projeto XPE - Desafio final

## 🧩 Diagrama de Componentes - MVC

```mermaid
graph TD
  A[Client] -->|Requisição HTTP| B[Controller]
  B --> C[Service]
  C --> D[Repository]
  D --> E[(Banco de Dados)]

  subgraph API ASP.NET Core -  C#
    B[Controller]
    C[Service]
    D[Repository]
  end

  subgraph PostgreSQL
    E[(Banco de Dados)]
  end
```

### 🧬 Diagrama de Entidade - Cliente

```mermaid
classDiagram
  class Cliente {
    +int Id
    +string Nome
    +string Email
  }

  Cliente : +GetId()
  Cliente : +SetId(int id)
  Cliente : +GetNome()
  Cliente : +SetNome(string nome)
  Cliente : +GetEmail()
  Cliente : +SetEmail(string email)
```

### 🗂️ Estrutura de Pastas - Projeto ASP.NET Core API

```
MyProject/
├── Controllers/
│   └── ClienteController.cs
│
├── Models/
│   └── Cliente.cs
│
├── Services/
│   └── ClienteService.cs
│
├── Repositories/
│   └── ClienteRepository.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── appsettings.json
├── Program.cs
└── Startup.cs
```

### 📘 Explicação dos Componentes


| Pasta/Arquivo          | Descrição                                                                       |
| ---------------------- | ------------------------------------------------------------------------------- |
| `Controllers/`         | Controladores que recebem requisições HTTP e retornam respostas JSON.           |
| `Models/`              | Entidades de domínio. Cada classe representa uma tabela no banco (ex: Cliente). |
| `Services/`            | Camada de lógica de negócio. Regras e validações.                               |
| `Repositories/`        | Acesso direto aos dados (via Entity Framework, Dapper etc).                     |
| `Data/AppDbContext.cs` | Define o contexto do banco e as configurações de entidades.                     |
| `Program.cs`           | Ponto de entrada da aplicação.                                                  |
| `Startup.cs`           | Configurações de serviços e middlewares da aplicação.                           |


### ✅ Endpoints REST Esperados

- `GET /clientes` → Lista todos os clientes  
- `GET /clientes/{id}` → Busca cliente por ID  
- `GET /clientes/nome/{nome}` → Busca cliente pelo nome  
- `GET /clientes/contar` → Conta total de clientes  
- `POST /clientes` → Cria novo cliente  
- `PUT /clientes/{id}` → Atualiza cliente  
- `DELETE /clientes/{id}` → Remove cliente  

### Para rodar o projeto

## Executar os comandos abaixo no terminal

```
cd xpe_cliente_api

docker compose build

docker compose up -d
```

>> logo em acessar seu brownser [local](http://localhost:5078/swagger/index.html).