# TechnicalAPI

---

## Rules

---

### Tech Stack
- **.NET 6**
- **Entity Framework Core**
- **PostgreSQL**
- **Swagger**

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
  - `PayorCPF_CNPJ`  
  - `PayeeName` (Required)  
  - `Amount` (Required)  
  - `DueDate` (Required)  
  - `Notes`  
  - `BancoId` (Required / references Banco register)  

- **GET** `/api/boleto/{Id}?searchDate=yyyy-MM-dd`  
  Returns a `Boleto` by its `Id`.  
  - Condition: If the `searchDate` is after the `DueDate`, apply the related `Banco.InterestPercent` **once** to the `Amount`.  
  - Interest is not accumulated per day, only added once.  

---

### Validation
- All **Required** fields must be validated.

---

### Optional Features
- Tokens
- DTOs
- AutoMapper
- Layer Separation
