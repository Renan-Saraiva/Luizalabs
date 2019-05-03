# Desafio Luizalabs

**Pré-requisitos**

È necessário que a SDK do ASP.NET CORE 2.1 esteja instalada na máquina, o mesmo pode ser obtido atraves do link https://dotnet.microsoft.com/download/dotnet-core/2.1.

Para que a aplicação seja executada com sucesso, é importante que o SQL Server Express 2016 LocalDB esteja instalado no Visual Studio que irá executar o projeto, ele é usado como repositório de dados da aplicação.

Para instalar o mesmo, basta a abrir o **Visual Studio**, ir em **Tools > Get Tools and Features > Individual components** e selecionar a caixa **Server Express 2016 LocalDB** e clicar em modificar.

![Sql server](https://user-images.githubusercontent.com/11603630/57160361-f13c8580-6dbe-11e9-8a12-e84ab99a621a.PNG)

Uma alternativa para o **Server Express 2016 LocalDB** seria o uso de uma base MS SQL Server, mas para isso é necessário que a ConnectionString do projeto seja alterada nos arquivos appsettings.json da aplicação com os dados deste banco. Os mesmos se encontram nos projetos **EmployeeManager.Api** e **EmployeeManager.Infrastructure**.

![connection](https://user-images.githubusercontent.com/11603630/57160362-f13c8580-6dbe-11e9-9aff-f64824671e53.PNG)

Apos a definição do repositório do projeto, é necessário criar a base de dados da aplicação, para isso, somente é necessário executar o comando **update-database** utilizando **Package Manager Console** do **Visual Studio**, lembrando que o projeto default que deve estar selecionado é o **EmployeeManager.Infrastructure**.

![update](https://user-images.githubusercontent.com/11603630/57160363-f1d51c00-6dbe-11e9-94bd-1e9f1d3ac258.PNG)

Após isso é possível executar o projeto.

O painel administrativo da aplicação pode ser acessado pela URL http://localhost:8000/Admin.html
