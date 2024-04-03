# AMXProductsCatalog

Este projeto é uma API para gerenciamento de produtos, estoque, pedidos e usuários.

## Product

- Os produtos servem como base de uma vitrine para que o estoque possa utilizar e se gerenciar.

- O sistema aceita inúmeros tipos de produtos desde que herdem de ‘BaseProduct’, utilizando de polimorfismo para isso.

- **CreateCarProduct**
  - Método: POST
  - Responsável por Criar o produto. Na criação do primeiro produto o estoque é criado, armazenando o produto dentro do estoque e com a quantidade de produtos zerados.
  - URL: /v1/CarProduct/CreateCarProduct
  - Body:
    ```json
    {
        "brand": "Totoya",
        "model": "Corolla",
        "year": 2023,
        "price": 250000
    }
    ```

- **GetCarProductById**
  - Método: GET
  - Responsável por pegar o produto pelo Id, passando esse Id pela url.
  - URL: /v1/CarProduct/GetCarProductById?id=93303

- **GetAllCarProducts**
  - Método: GET
  - Responsável por pegar todos os produtos que foram cadastrados. A paginação não é obrigatória, mas podemos passar o pageSize e pageNumber pela Url, caso um deles não for valido ou nullo se realizara a busca sem a paginação.
  - URL: /v1/CarProduct/GetAllCarProducts?pageSize=0&pageNumber=0

- **DeleteCarProductById**
  - Método: DELETE
  - Responsável por deletar o produto pelo Id, passando esse Id pela url.
  - URL: /v1/CarProduct/DeleteCarProductById?id=18342

- **UpdateCarProduct**
  - Método: PUT
  - Responsável por atualizar o produto, passando o id do produto e o resto dos dados a serem atualizados.
  - URL: /v1/CarProduct/UpdateCarProduct
  - Body:
    ```json
    {
        "id": "88369",
        "brand": "Toyota",
        "model": "Corolla",
        "year": 2022,
        "price": 250000
    }
    ```

## Stock
-	O estoque é responsável por armazenar os itens de produtos dentro dele, sendo responsável por gerenciar a quantidade e as transações de pedido.

-	O estoque é criado de forma automática, a partir da criação do primeiro produto no sistema.

-	Nesse caso em especifico utilizamos apenas um estoque, mas a estrutura foi feita para que possa expandir para mais estoques caso a empresa tenha filiais ou pela própria necessidade do cliente. 

- **GetStock**
  - Método: GET
  - Responsável por buscar o estoque.
  - URL: /v1/Stock/GetStock

- **GetItemStockById**
  - Método: GET
  - Responsável por buscar um item do estoque pelo Id.
  - URL: v1/Stock/GetItemStock?id=64423

- **UpdateItemStock**
  - Método: UPDATE
  - Responsável por atualizar a quantidade de um item do estoque, passando o Id do item e a quantidade, ambos obrigatórios. Sendo possível atualizar a quantidade conforme o senário e as necessidade do cliente.
  - URL: /v1/Stock/UpdateItemStock?id=75046&quantity=12

## Order
-	O pedido é realizado encima dos itens do estoque e atualiza o estoque conforme o pedido for confirmado.

-	O pedido só pode ser realizado e confirmado pelo vendedor (‘seller’) ou pelo administrador (‘admin’).

- **Existe quatro status para o pedido**:
  - Pending = 1: Status atualizado quando existe algum problema no pedido.
  - Processing = 2: Status atualizado quando o pedido é criado com sucesso, indica que o pedido não foi confirmado ainda, com a ideia de mostrar para o cliente o pedido e os valores, para somente após isso realizar a confirmação.
  - Confirmed = 3: Status atualizado quando o pedido é confirmado pelo cliente.
  - Canceled = 4: Status atualizado quando o pedido é cancelado pelo cliente.

- **CreateOrder**
  - Método: POST
  - Responsável por criar um pedido, passando no body o id do item e a quantidade que deseja comprar. Após criar o pedido o status do pedido fica como ‘Processing’.
  - URL: /v1/Order/CreateOrder
  - Body:
    ```json
    {
        "itemId": "64423",
        "quantity": "Corolla"
    }
    ```

- **GetOrder**
  - Método: GET
  - Responsável por buscar um pedido realizado passando o Id pela url.
  - URL: v1/Order/GetOrder?id=47406

- **ConfirmOrder**
  - Método: PUT
  - Responsável por confirmar o pedido que já foi criado e atualizar o estoque.
  - URL: /v1/Order/ConfirmOrder?id=47406

## User
-	Existem três tipos de usuário no sistema ‘admins, sellers e clients’, os administradores tem acesso total ao sistema e todas as funcionalidades, os vendedores conseguem gerenciar os pedidos e o estoque, sendo limitados a atualização do estoque, clientes podem somente consultar os pedidos.

- **CreateUser**
  - Método: POST
  - Responsável por criar um usuário de acesso.
  - URL: /v1/User/CreateUser
  - Body:
    ```json
    {
        "username": "will@amx",
        "password": "1234",
        "role": "admin" //admin, seller, client
    }
    ```

- **Authenticate**
  - Método: POST
  - Responsável por realizar o login de autenticação, retornando um token de acesso
  - URL: /v1/AuthenticationController/Authenticate
  - Body:
    ```json
    {
        "username": "will@amx",
        "password": "1234"
    }
    ```

## Requisitos

1- Provide features (enpoints) to deal with Products (catalog), Stock and Orders. Each entity
type should have at least three endpoints/features:
▪ List page to show all records of an entity type allowing the user to apply some filters.
Paging is optional but nice.
▪ Create/edit capability
▪ Delete an entity
▪ Details of the entity
2. Provide a Sign in page. Users have at least one of these access roles: Admin, Seller and Client.
3. Access control:
▪ Admins can access all features and manage all records.
▪ Sellers can create and manage any client. Moreover they can create orders for any client
and manage their own orders.
▪ Clients can see orders addressed to him.


## Configuração

1. [Instruções de instalação]
2. [Instruções de configuração]

## Como Usar

1. [Instruções de uso]

## Contribuições

Contribuições são bem-vindas! Para maiores detalhes, consulte [CONTRIBUTING.md](CONTRIBUTING.md).

## Licença

Este projeto é licenciado sob a [Licença XYZ](LICENSE).
