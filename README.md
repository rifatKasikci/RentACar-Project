
# RentACar-Project

This project is the backend of my rent a car project that I developed at the C#-Angular camp of Engin Demiroğ. In this project I used diffrent and rare technologies and architectures and technics.


## Technologies That Used

* Fluent Validation
* Autofac
* JWT(Json Web Token)
* Entity Framework
* Caching, Validation, Transaction, Performance Aspects



  
## Entities
### Brands

| Name | Data Type    | Allow Nulls | Default |
| :--- | :----------- | :---------- | :------ |
| Id   | int          | False       |         |
| BrandName | nvarchar(50) | False       |         |

### Car Images

| Name      | Data Type     | Allow Nulls | Default |
| :-------- | :------------ | :---------- | :------ |
| Id        | int           | False       |         |
| CarId     | int           | False       |         |
| ImagePath | nvarchar(MAX) | False       |         |
| Date      | datetime      | False       |         |

### Car

| Name            | Data Type     | Allow Nulls | Default |
| :-------------- | :------------ | :---------- | :------ |
| Id              | int           | False       |         |
| BrandId            | int  | False       |         |
| ColorId         | int           | False       |         |
| CarName         | nvarchar(100)           | False       |         |
| ModelYear      | int           | False       |         |
| DailyPrice       | int           | False       |         |
| MinFindeksPoint     | int  | False        |         |
| Description | nvarchar(250)      | False       |    |

### Color

| Name | Data Type    | Allow Nulls | Default |
| :--- | :----------- | :---------- | :------ |
| Id   | int          | False       |         |
| ColorName | nvarchar(50) | False       |         |

### Credit Card (Test)

| Name        | Data Type     | Allow Nulls | Default |
| :---------- | :------------ | :---------- | :------ |
| Id          | int           | False       |         |
| CustomerId  | int           | False       |         |
| FullName    | nvarchar(100) | False       |         |
| CardNumber  | char(16)       | False       |            |
| CardExpMonth| tinyint       | False       |         |
| CardExpYear | tinyint       | False       |         |
| Cvv         | int   | False       |         |
| CardType         | nvarchar(50)   | False       |         |
| CardLimit         | int  | False       |         | 

### Customer

| Name        | Data Type    | Allow Nulls | Default |
| :---------- | :----------- | :---------- | :------ |
| Id          | int          | False       |         |
| UserId      | int          | False       |         |
| FindeksScoreId | int | False        |         |
| CompanyName| nvarchar(75)          | False       |         |

### FindeksScore

| Name        | Data Type    | Allow Nulls | Default |
| :---------- | :----------- | :---------- | :------ |
| Id          | int          | False       |         |
| CustomerId      | int          | False       | |
| Score      | int          | False       |          |


### OperationClaims

| Name | Data Type    | Allow Nulls | Default |
| :--- | :----------- | :---------- | :------ |
| Id   | int          | False       |         |
| Name | varchar(50) | False       |         |

### Payment

| Name | Data Type    | Allow Nulls | Default |
| :--- | :----------- | :---------- | :------ |
| Id   | int          | False       |         |
| CustomerId | int | False       |         |
| Amount | int | False       |         |

### Rental

| Name          | Data Type | Allow Nulls | Default |
| :------------ | :-------- | :---------- | :------ |
| Id            | int       | False       |         |
| CarId         | int       | False       |         |
| CustomerId    | int       | False       |         |
| RentDate      | date | False       |         |
| ReturnDate    | date  | True        |         |

### UserOperationClaims

| Name             | Data Type | Allow Nulls | Default |
| :--------------- | :-------- | :---------- | :------ |
| Id               | int       | False       |         |
| UserId           | int       | False       |         |
| OperationClaimId | int       | False       |         |

### Users

| Name         | Data Type      | Allow Nulls | Default |
| :----------- | :------------- | :---------- | :------ |
| Id           | int            | False       |         |
| FirstName    | nvarchar(50)   | False       |         |
| LastName     | nvarchar(50)   | False       |         |
| Email        | nvarchar(50)   | False       |         |
| PasswordHash | varbinary(500) | False       |         |
| PasswordSalt | varbinary(500) | False       |         |
| Status       | bit            | False       |         |


  
# Contributions

Thanks to [Engin Demiroğ](http://https://github.com/engindemirog) for his 
contributions.

## Associated Project

For frontend project (**RentACar-Frontend**)

[RentACar-Frontend](https://github.com/rifatKasikci/RentACar-Frontend)

  
## Geri Bildirim

If you have any feedback, you can send an e-mail to rifatkasikci@gmail.com with the subject title **RentACarProject**. 

  
