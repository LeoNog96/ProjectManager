# ProjectMananger

### Tecnologias Utilizadas

- dotnet core >= 3.0
- Postgresql >= 12
- VueJs >= 2.x
- Docker

### Executar Projeto

Para executar todo projeto foi criado um docker-compose, antes de executar o docker-compose deve-se realizar o seguinte procedimento:

* No projeto `projectmanager.frontend` existe um arquvio com o nome `.env.production` substituir `SEU_IP` pelo o ip da sua maquina.

Após realizar o procedimento acima executar o seguinte comando na raiz do repositório:

```console
$ docker-compose up
```

Este comando irá compilar e executar o Projeto via docker.

### Documentação WebApi

Para Acessar a documentação REST da API basta acessar o seguinte endereço `SEU_IP:5002/swagger`.

## A Aplicação
O funcionamento da aplicação acontece de forma simples e intuitiva, abaixo será explicada o uso da aplicação por partes.

* Tela Principal: Na tela principal são listados os projetos e seus respectivos detalhes, Também é possivel realizar o cadastro de novos projetos, exclusão, edição, ver detalhes e ir para as atividades do projeto.

    - Criar novos Projetos: Para criar novos projetos basta um click no botão `Criar o primeiro projeto`:
    ![NovoProjeto](https://github.com/LeoNog96/ProjectManager/blob/master/img/criar_projeto.png)

    ou até mesmo com um click em `novo`:
    ![NovoProjeto2](https://github.com/LeoNog96/ProjectManager/blob/master/img/novo_projeto.png)

    com isto um basta preencher o formulário de Projeto:
    ![NovoProjeto3](https://github.com/LeoNog96/ProjectManager/blob/master/img/criar_projeto2.png)
    

    Após a criação do projeto, podemos:

    - Excluir Projetos:
        ![ExcluirProjeto](https://github.com/LeoNog96/ProjectManager/blob/master/img/excluir_projeto.png)


    - Editar Projetos:
        ![EditarProjeto](https://github.com/LeoNog96/ProjectManager/blob/master/img/editar_projeto.png)


    - Ver detalhes do projeto:
        ![DetalhesProjeto](https://github.com/LeoNog96/ProjectManager/blob/master/img/detalhes.png)


    - Ir para atividades:
        ![AtividadesProjeto](https://github.com/LeoNog96/ProjectManager/blob/master/img/ir_atividades.png)

* Atividades: Após usar a opção ir para atividades, é encaminhado para a página de atividades referente ao projeto, Nela podemos listar todas atividades assim como criar novas atividades, excluir, editar e finalizar atividades.

    - Criar novas Atividades: Para criar novas atividades basta um click no botão `Criar a primeira atividade`:
        ![NovaAtividade](https://github.com/LeoNog96/ProjectManager/blob/master/img/criar_primeira_atividade.png)

    ou até mesmo com um click em `novo`:
        ![NovaAtividade2](https://github.com/LeoNog96/ProjectManager/blob/master/img/criar_atividade.png)

    com isto um basta preencher o formulário de Atividade:
        ![NovaAtividade3](https://github.com/LeoNog96/ProjectManager/blob/master/img/criando_atividade.png)

    Após a criação da atividade, temos a seguinte tabela:
        ![TelaAtividades](https://github.com/LeoNog96/ProjectManager/blob/master/img/tela_atividades.png)
    
    Nela podemos:
    
    - Excluir Ativiades:
        ![ExcluirAtiviade](https://github.com/LeoNog96/ProjectManager/blob/master/img/excluir_atividade.png)


    - Editar Ativiades:
        ![EditarAtiviade](https://github.com/LeoNog96/ProjectManager/blob/master/img/editar_atividade.png)


    - Finalizar:
        ![FinalizarAtiviade](https://github.com/LeoNog96/ProjectManager/blob/master/img/finalizar_atividade.png)


* Menu Lateral: O Menu Lateral nesta versão possui somente uma opção que é para voltar aos projetos, posteriomente pode ser implementado mais funções para o ProjectManager.
    ![MenuLateral](https://github.com/LeoNog96/ProjectManager/blob/master/img/back_projetos.png)

* Voltando para projetos após criar algumas atividades podemos notar que os detalhes do projeto é alterado conforme é feito o movimento de atividades.
    ![Detalhes](https://github.com/LeoNog96/ProjectManager/blob/master/img/detalhe_projeto.png)

* Quando existe um projeto com atraso é destacado pela cor vermelha:
    ![Atraso](https://github.com/LeoNog96/ProjectManager/blob/master/img/atraso.png)

Com isso finalizamos nosso mini tutorial sobre a usabilidade do ProjectManager.
