# AMXProductsCatalog - English

This project is an API for managing products, inventory, orders, and users.

## Product

- The products serve as the basis for a storefront so that inventory can be utilized and managed.

- The system accepts numerous types of products as long as they inherit from 'BaseProduct', utilizing polymorphism for this purpose.

- **CreateCarProduct**
  - Method: POST
  - Responsible for creating the product. Upon creating the first product, the inventory is created, storing the product within the inventory with a quantity of zero products.
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
  - Method: GET
  - Responsible for retrieving the product by its ID, passing the ID through the URL.
  - URL: /v1/CarProduct/GetCarProductById?id=93303

- **GetAllCarProducts**
  - Method: GET
  - Responsible for retrieving all the products that have been registered. Pagination is not mandatory, but we can pass the pageSize and pageNumber through the URL. If either of them is not valid or null, the search will be conducted without pagination.
  - URL: /v1/CarProduct/GetAllCarProducts?pageSize=0&pageNumber=0

- **DeleteCarProductById**
  - Method: DELETE
  - Responsible for deleting the product by its ID, passing the ID through the URL.
  - URL: /v1/CarProduct/DeleteCarProductById?id=18342

- **UpdateCarProduct**
  - Method: PUT
  - Responsible for updating the product, passing the product ID and the rest of the data to be updated.
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
-	The inventory is responsible for storing the product items within it, managing the quantity and order transactions.

-	The inventory is automatically created upon the creation of the first product in the system.

-	In this specific case, we only use one inventory, but the structure was designed so that it can be expanded to include more inventories if the company has branches or due to the customer's own needs..

- **GetStock**
  - Method: GET
  - Responsible for retrieving the inventory.
  - URL: /v1/Stock/GetStock

- **GetItemStockById**
  - Method: GET
  - Responsible for retrieving an inventory item by ID.
  - URL: v1/Stock/GetItemStock?id=64423

- **UpdateItemStock**
  - Method: UPDATE
  - Responsible for updating the quantity of an inventory item, passing the item ID and the quantity, both mandatory. It's possible to update the quantity according to the scenario and the client's needs.
  - URL: /v1/Stock/UpdateItemStock?id=75046&quantity=12

## Order
-	The order is made based on the items in the inventory and updates the inventory as the order is confirmed.

-	The order can only be placed and confirmed by the seller ('seller') or by the administrator ('admin').

- **There are four statuses for the order.**:
  - Pending = 1: Status updated when there is an issue with the order.
  - Processing = 2: Status updated when the order is successfully created, indicating that the order has not been confirmed yet. This allows showing the order and its values to the customer before confirming it.
  - Confirmed = 3: Status updated when the order is confirmed by the customer.
  - Canceled = 4: Status updated when the order is canceled by the customer.

- **CreateOrder**
  - Method: POST
  - Responsible for creating an order, passing in the request body the ID of the item and the quantity the customer wishes to purchase. After creating the order, the status of the order is set to 'Processing'.
  - URL: /v1/Order/CreateOrder
  - Body:
    ```json
    {
        "itemId": "64423",
        "quantity": "Corolla"
    }
    ```

- **GetOrder**
  - Method: GET
  - Responsible for retrieving a placed order by passing the ID through the URL.
  - URL: v1/Order/GetOrder?id=47406

- **ConfirmOrder**
  - Method: PUT
  - Responsible for confirming the order that has already been created and updating the inventory.
  - URL: /v1/Order/ConfirmOrder?id=47406

## User
-	There are three types of users in the system: admins, sellers, and clients. Administrators have full access to the system and all functionalities. Sellers can manage orders and inventory, but are limited to updating the inventory. Clients can only view their orders.

- **CreateUser**
  - Method: POST
  - Responsible for creating an access user.
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
  - Method: POST
  - Responsible for performing authentication login, returning an access token.
  - URL: /v1/AuthenticationController/Authenticate
  - Body:
    ```json
    {
        "username": "will@amx",
        "password": "1234"
    }
    ```

## Requirements

Provide features (endpoints) to deal with Products (catalog), Stock, and Orders:

Each entity type should have at least three endpoints/features:
List page: To show all records of an entity type, allowing the user to apply some filters. Paging is optional but nice.
Create/edit capability: Ability to create or edit a record.
Delete an entity: Delete a record.
Details of the entity: Show the details of a record.
Provide a Sign-in page:

Users have at least one of these access roles: Admin, Seller, and Client.
Access control:

Admins can access all features and manage all records.
Sellers can create and manage any client. Moreover, they can create orders for any client and manage their own orders.
Clients can see orders addressed to them.


## How to Use

1. Create a user - Endpoint CreateUser
2. Perform authentication - Endpoint Authenticate
3. Use the token to access the functionalities
4. Create a product that will be added to the inventory - Endpoint CreateCarProduct
5. Retrieve the inventory to get the ID of the item - Endpoint GetStock
6. Update the inventory item, adding the quantity available in the stock, passing the ID of the item from step (5) - Endpoint UpdateItemStock
7. Create an order, passing the ID of the item you wish to purchase and the quantity - Endpoint CreateOrder
8. Confirm the order, passing the ID of the order created in step (7) - Endpoint ConfirmOrder

## Contributions

William Borges


----------------------------------------------------------------------------------------


# AMXProductsCatalog - Português

Este projeto é uma API para gerenciamento de produtos, estoque, pedidos e usuários.

## Product

- Os produtos servem como base de uma vitrine para que o estoque possa utilizar e se gerenciar.

- O sistema aceita inúmeros tipos de produtos desde que herdem de ‘BaseProduct’, utilizando de polimorfismo para isso.

- **CreateCarProduct**
  - Método: POST
  - Responsável por Criar o produto. Na criação do primeiro produto o estoque tambem é criado, armazenando o produto dentro do estoque e com a quantidade de produtos zerados.
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

Fornecer funcionalidades (endpoints) para lidar com Produtos (catálogo), Estoque e Pedidos:

Cada tipo de entidade deve ter pelo menos três endpoints/funcionalidades:
- **Listagem**: Uma página para mostrar todos os registros de um tipo de entidade, permitindo que o usuário aplique alguns filtros. A paginação é opcional, mas recomendada.
- **Criar/editar**: Capacidade de criar ou editar um registro.
- **Excluir**: Excluir um registro.
- **Detalhes**: Mostrar os detalhes de um registro.

Fornecer uma página de login:
- Os usuários têm pelo menos um desses papéis de acesso: Admin, Vendedor e Cliente.

Controle de acesso:
- Os administradores podem acessar todas as funcionalidades e gerenciar todos os registros.
- Os vendedores podem criar e gerenciar qualquer cliente. Além disso, podem criar pedidos para qualquer cliente e gerenciar seus próprios pedidos.
- Os clientes podem ver os pedidos endereçados a eles.

Provide features (endpoints) to deal with Products (catalog), Stock, and Orders:

Each entity type should have at least three endpoints/features:
List page: To show all records of an entity type, allowing the user to apply some filters. Paging is optional but nice.
Create/edit capability: Ability to create or edit a record.
Delete an entity: Delete a record.
Details of the entity: Show the details of a record.
Provide a Sign-in page:

Users have at least one of these access roles: Admin, Seller, and Client.
Access control:

Admins can access all features and manage all records.
Sellers can create and manage any client. Moreover, they can create orders for any client and manage their own orders.
Clients can see orders addressed to them.


## Como Usar

1. Crie um user - Enpoint CreateUser
2. Faça a autenticação - Enpoint Authenticate
3. Utilize o token para realizar o acesso as funcionalidades
4. Crie um produto que sera adicionado no stock - Endpoint CreateCarProduct
5. Busque o estoque para pegar o Id do item - Endpoint GetStock
6. Atualize o item do estoque, adicionando a quantidade que tem no estoque, passando o Id do item (5) - Endpoint UpdateItemStock
7. Crie um pedido, passando o Id do item que deseja comprar e a quantidade - Endpoint CreateOrder
8. Confirme o pedido, passando o Id do pedido que veio ao criar ele (7) - Endpoint ConfirmOrder

## Contribuições

William Borges
