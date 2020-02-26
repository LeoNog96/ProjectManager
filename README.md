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

Este comando irá executar o Projeto.

### Documentação WebApi

Para Acessar a documentação REST da API basta acessar o seguinte endereço `SEU_IP:5002/swagger`.

## A Aplicação