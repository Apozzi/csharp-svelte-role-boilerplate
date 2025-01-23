# Csharp-Svelte-Role-Boilerplate

Exemplo minimo de Backend em C# com .NET 9.0 e Frontend Svelte com autenticação JWT e controle de papeis de usuário.

Utilizado padrões de Clean Archicteture.

![Capturar](https://github.com/user-attachments/assets/5b51fea4-a586-4f91-9b0b-7056662194d4)


![Capturar2](https://github.com/user-attachments/assets/6c4c0aab-c389-4c3a-9dec-7e7551be2639)


## Como rodar?

### Rodar com docker.

Basta executar `docker-compose up --build` e após isso estará rodando no `localhost:5173` (se aparecer pagina do nginx basta dar F5 para configurações do ngix carregarem).

### Rodar na sua maquina.

Deve ter postgres rodando na sua maquina com database `exemplo2`, executar os arquivos dentro da pasta `Database`.

Com SDK do .NET 9.0 instalado dentro da pasta BackendAPI rodar `dotnet install` e `dotnet run`.

Na pasta Frontend executar `npm i` e `npm run dev`.
