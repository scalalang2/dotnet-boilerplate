## dotnet boilerplate
The fastest way to get started with dotnet core to build a restful api server with a structured project.

## This project includes:
- .NET 7
- Entity Framework Core
- Postgres
- Basic Authentication and Authorization with JWT
- Dependency Injection
- Service layer
- Containerized with Docker

## Features
Features includes the following:

- User
  - Register
  - Login 
  - Logout
- Article
  - Create
  - Update
  - Delete
  - List
  - Detail

## How To Use
```shell
$ docker-compose up -d
$ cd Server

# Migrate database
$ dotnet ef database update

# Run server
$ dotnet run
```

## License

**MIT**

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the 'Software'), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.