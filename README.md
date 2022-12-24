# API-ArchitectureDDD


By: Gabriel Novais Maia

Api desenvolvida junto ao Curso de NETCore do professor Marcos Fabricio Rosa

Esta Api Realiza o CRUD de um usuário com os dados de Nome e Email em seu JSON, utilizando a arquitetura DDD
  
	Exemplo: {
        "name": "Gabriel",
        "email": "Gabriel.gnm@gmail.com",
        "id": "97db10fc-32e4-42fa-ae7d-604eb009875a",
        "createAt": "2022-12-21T03:52:07.342121",
        "updateAt": null
    }
		
 
criando um GUID para cada usuário e setando datas de criação e update.

# Como Executar MySQL 12 Commit

Para que essa API funcionasse utilizei o MySQL até o 12 Commit com o usuário padrão(root) e o Localhost:5000 com a senha: "mudar@123"
  |  ----   |
  | 1- Instalar MySQL|
  | 2- realizar configurações na connectionString em src\Api.Data\Context\ContextFactory.cs|
  | 3- realizar configurações na AddDbContext em src\Api.CrossCutting\DependencyInjection\ConfigureRepository.cs|
  | 4- executar no terminal "dotnet ef update database"|
  
# Requisições Configuradas

  * GetAll - http://localhost:5000/api/users - vai retornar um JSON com todos os usuários
  * GetWithId - http://localhost:5000/api/users/"UserID" - retorna apenas os usuário mencionado no ID
  * Post - http://localhost:5000/api/users - insere um novo usuário pelo formato JSON
  * Put - http://localhost:5000/api/users/"UserID" - atualiza os dados no formato JSON (é necessário informar o ID do usuário)
  * Delete - http://localhost:5000/api/users/"UserID" - Delete o usuário informado da Tabela

# SQL Server 2017
  Commit 14 Api Convertida para SQL server
  :
use dbapi
select * from [user]

insert into [User] values (NEWID(), GetDate(), null, 'Administrador', 'gabriel.gnm@gmail.com')
  :
