# TechnicalAPI
---
This project is a Technical challenge proposed for a job opening.
It consists in following a ruleset given by the organization to build a API that Registers and Finds "Banco" and "Boleto" entities on a PostgreSQL database.

---
## Index
````````
- Sample Requests
-- Banco
-- Boleto
- Rules
-- Tech Stack
-- Banco Endpoints
-- Boleto Endpoints
-- Validation
-- Optional Features
````````
---
## Sample Requests

### Banco

#### Get all Bancos

**GET** `/api/bancos/all`

#### Request
_No request body required._

#### Response
````````
[
  {
    "id": 0,
    "name": "string",
    "code": 0,
    "interestPercent": 0
  }
]
````````

#### Get Banco by Code

**GET** `/api/bancos/{code}`

#### Parameters
_code: int32_

#### Response
````````
{
  "Id": 1,
  "Name": "Banco Exemplo",
  "Code": "BE",
  "InterestPercent": 2.5
}
````````

#### Register a new Banco

**POST** `/api/bancos/register`

#### Request
````````
{
  "name": "string",
  "code": 0,
  "interestPercent": 0
}
````````

#### Response
````````
{
  "id": 0,
  "name": "string",
  "code": 0,
  "interestPercent": 0
}
````````

### Boleto

#### Get Boleto by Id

**GET** `/api/boletos/{id}`

#### Parameters
_id: int32_

#### Response
````````
{
  "id": 0,
  "payorName": "string",
  "payorCpfCnpj": "string",
  "payeeName": "string",
  "amount": 0,
  "dueDate": "2025-10-06T07:20:39.875Z",
  "notes": "string",
  "bancoId": 0
}
````````

#### Register a new Boleto

**POST** `/api/boletos/register`

**Request Body**
````````
{
  "payorName": "string",
  "payorCpfCnpj": "string",
  "payeeName": "string",
  "amount": 0,
  "dueDate": "2025-10-06T07:22:37.289Z",
  "notes": "string",
  "bancoId": 0
}
````````

#### Response
````````
{
  "id": 0,
  "payorName": "string",
  "payorCpfCnpj": "string",
  "payeeName": "string",
  "amount": 0,
  "dueDate": "2025-10-06T07:22:37.289Z",
  "notes": "string",
  "bancoId": 0
}
````````

---
## Rules

---
### Tech Stack
````````
- .NET 6
- Entity Framework Core
- PostgreSQL
- Swagger
````````

---
### Features

#### Endpoints

##### Banco
- **POST** `/api/banco/register`  
  Registers a new `Banco` with the following properties:
  - `Id` (Required)  
  - `Name` (Required)  
  - `Code` (Required)  
  - `InterestPercent` (Required)  

- **GET** `/api/banco/all`  
  Returns all `Banco` entries.  

- **GET** `/api/banco/{Code}`  
  Returns one `Banco` entry by its `Code`.  

##### Boleto
- **POST** `/api/boleto/register`  
  Registers a new `Boleto` with the following properties:
  - `Id` (Required)  
  - `PayorName` (Required)  
  - `PayorCpfCnpj`  
  - `PayeeName` (Required)  
  - `Amount` (Required)  
  - `DueDate` (Required)  
  - `Notes`  
  - `BancoId` (Required / references Banco register)  

- **GET** `/api/boleto/{Id}?searchDate=yyyy-MM-dd`  
  Returns a `Boleto` by its `Id`.  
  - Condition: If the current date is later the `DueDate`, apply the related `Banco.InterestPercent` **once** to the `Amount`.  
  - Interest is not accumulated per day, only added once.  

---
### Validation
````````
- All **Required** fields must be validated.
````````
---
### Optional Features
````````
- Tokens
- DTOs
- AutoMapper
- Layer Separation
````````
