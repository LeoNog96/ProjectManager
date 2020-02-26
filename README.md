# ProjectMananger

### Tecnologias Utilizadas

- dotnet core >= 3.0
- Postgresql >= 12
- VueJs >= 2.x
- Docker

### Executar Projeto

Para executar todo projeto foi criado um docker-compose, antes de executar o docker-compose deve-se realizar o seguinte procedimento:

* No projeto `projectmanager.frontend` existe um arquvio com o nome `.env.production` substituir `SEU_IP` pelo o ip da sua maquina.

Após realizar o procedimento acima executar o seguinte comando na raiz do projeto:

```console
$ docker-compose up
```

Este comando irá compilar e executar o Projeto via docker.

### Documentação WebApi

Para Acessar a documentação REST da API basta acessar o seguinte endereço `SEU_IP:5002/swagger`.

## A Aplicação
O funcionamento da aplicação acontece de forma simples e intuitiva, abaixo será explicada o uso da aplicação por partes.

* Tela Principal: Na tela principal é onde é listados os projetos e seus respectivos detalhes, Também é possivel realizar o cadastro de novos projetos.

    - Criar novos Projetos: Para criar novos projetos basta um click no botão `Criar o primeiro projeto`:
    ![NovoProjeto](https://github.com/LeoNog96/ProjectManager/blob/master/img/criar_projeto.png

    ou até mesmo com um click em `novo`:
    ![NovoProjeto2](https://github.com/LeoNog96/ProjectManager/blob/master/img/novo_projeto.png

    com isto um basta preencher o formulário de Projeto:
    ![NovoProjeto3](https://github.com/LeoNog96/ProjectManager/blob/master/img/criar_projeto2.png