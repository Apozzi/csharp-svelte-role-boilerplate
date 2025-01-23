# 🚀 Sistema de Autenticação com .NET 9.0 + Svelte

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)](https://dotnet.microsoft.com)
[![Svelte](https://img.shields.io/badge/Svelte-4-FF3E00)](https://svelte.dev)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-336791)](https://www.postgresql.org)
[![JWT](https://img.shields.io/badge/JWT-Auth-000000)](https://jwt.io)

Exemplo minimo de Backend em C# com .NET 9.0 e Frontend Svelte com autenticação JWT e controle de papeis de usuário. Utilizado padrões de Clean Archicteture.

**Funcionalidades principais:**

| Backend (.NET)          | Frontend (Svelte)         |
|-------------------------|---------------------------|
| ✅ JWT Authentication  | ✅ Login/Registro        |
| ✅ Role-based Access   | ✅ Controle de Permissões|
| ✅ Entity Framework 9  | ✅ SessionStorage        |
| ✅ Swagger UI          | ✅ Rotas Dinâmicas       |

---

![Capturar](https://github.com/user-attachments/assets/5b51fea4-a586-4f91-9b0b-7056662194d4)

![Capturar2](https://github.com/user-attachments/assets/6c4c0aab-c389-4c3a-9dec-7e7551be2639)

---

## 📂 Estrutura de Arquivos
```bash
├── BackendAPI/
│   ├── Application/    # Lógica de negócios
│   ├── Domain/         # Entidades
│   ├── Infrastructure/ # Database/JWT
│   └── WebAPI/         # Controllers
├── Frontend/
│   ├── src/            # Componentes
│   └── routes/         # Admin/User
└── docker-compose.yml
```


## Como rodar?

### Rodar com docker.

Basta executar:
```bash
docker-compose up --build
```
E após isso estará rodando no `localhost:5173` (se aparecer pagina do nginx basta dar F5 para configurações do ngix carregarem).

### Rodar na sua maquina.

Deve ter postgres rodando na sua maquina com database `exemplo2`, executar os arquivos dentro da pasta `Database`.

Com SDK do .NET 9.0 instalado dentro da pasta BackendAPI rodar `dotnet install` e `dotnet run`.

Na pasta Frontend executar `npm i` e `npm run dev`.


## 🔑 Acesso
```yaml
email: transportadoraplatina@gmail.com
password: 1234
```

---


