# MemberManagementSystem

We need to save and manage information about our
members (name and address). Each member can have one or more accounts where he or she can collect
points (e.g.: for one international flight with Lufthansa the user gets 150 points) or redeem points from
(e.g.: 100 points from his/her account in exchange for a free coffee). Points are stored as a balance on
each account. Each account has a name identifying the company from which the points were collected
and status telling if the account is active or inactive. Points cannot be redeemed from an inactive or empty
account.

## Prerequisites

Visual Studio 2019 16.4 or later with the ASP.NET and web development workload

.NET Core 3.1 SDK or later

## Database

Application is using in-memory database provided by ASP.net core.

**_Note:_** System automatically loads some initial dummy data on application startup.

## Source Code

Application source code is available at following GitHub repository.

[https://github.com/dshubhangid/MemberManagementSystem](https://github.com/dshubhangid/MemberManagementSystem)

[https://github.com/dshubhangid/MemberManagementSystem.git](https://github.com/dshubhangid/MemberManagementSystem.git)

GitHub other projects: [https://github.com/dshubhangid?tab=repositories](https://github.com/dshubhangid?tab=repositories)

## Swagger GUI

Application is integrated with Swagger GUI.

Swaager can be accessed with following URL.

https://localhost:{port}/swagger/index.html

## Usecases

Following usecases are covered by the system.

1. User can initially import existing members in a JSON format (example is attached)
2. User creates a new member
3. User creates a new account for a defined member
4. Member collects points to an existing account
5. Member redeems points from an existing account
6. User can export all members based on filter criteria (e.g.: export all members that have at least 20
   points on an inactive account)

## WebApi Details

### 1. Initial Import

User can initially import existing members in a JSON format (example is attached)

**_Note_**: System also automatically loads some initial dummy data on application startup.

##### Endpoint

```
 URL: /api/members/importmembers

 METHOD: POST

 JSON Body:

[
  {
    "name": "string",
    "address": "string",
    "accounts": [
      {
        "name": "string",
        "balance": 0,
        "status": "string"
      }
    ]
  }
]
```

### 2. User creates a new member

##### Endpoint

```
URL: /api/members

METHOD: POST

JSON Body:

{
  "name": "string",
  "address": "string",
  "accounts": [
    {
      "name": "string",
      "balance": 0,
      "status": "string"
    }
  ]
}
```

### 3. User creates a new account for a defined member

##### Endpoint

```
URL: /api/members/{memberId}/accounts

METHOD: POST

JSON Body:

{
  "name": "string",
  "balance": 0,
  "status": "string"
}
```

### 4. Member collects points to an existing account

##### Endpoint

```
URL: /api/members/{memberId}/accounts/collectpoints/{accountId}/{points}

METHOD: PATCH

Route Paramerters:

1. memberId - Int (existing memberID)
2. accountId - Int (existing accountID)
3. points - Int
```

### 5. Member redeems points from an existing account

##### Endpoint

```
URL: /api/members/{memberId}/accounts/redeempoints/{accountId}/{points}

METHOD: PATCH

Route Paramerters:

1. memberId - Int (existing memberID)
2. accountId - Int (existing accountID)
3. points - Int
```

### 6. User can export all members based on filter criteria

(e.g.: export all members that have at least 20
points on an inactive account)

User can filter the memebers by "points" and "status" fields.

A) Status can be "ACTIVE" OR "INACTIVE".

B) Points needs additional parameter "condition" which can be "GreaterThan" or "LessThan" or "EqualTo".
Default Value for "condiion" is "EqualTo"

##### Endpoint

```
URL: /api/members/exportMembersByFilter?Points=100&Condition=GreaterThan&Status=ACTIVE

METHOD: GET

Query Strings:

Points: 100
condition=GreaterThan  (Available values : EqualTo, GreaterThan, LessThan) Default: "EqualTo"
Status=ACTIVE (Available values : ACTIVE, INACTIVE)

```

## Additional Helper Endpoints

### 1. Get all accounts for defined member

##### Endpoint

```
URL: /api/members/{memberId}/accounts

METHOD: GET

Response:

[
  {
    "id": 0,
    "memberId": 0,
    "name": "string",
    "balance": 0,
    "status": "string"
  }
]
```

### 2. Get specific account for defined member

##### Endpoint

```
URL: /api/members/{memberId}/accounts/{accountId}

METHOD: GET

Response:

{
  "id": 0,
  "memberId": 0,
  "name": "string",
  "balance": 0,
  "status": "string"
}
```

### 3. Get all members

##### Endpoint

```
URL: /api/members

METHOD: GET

Response:

[
  {
    "id": 0,
    "name": "string",
    "address": "string"
  }
]
```

### 4. Get all members

##### Endpoint

```
URL: /api/members/{id}

METHOD: GET

Response:

{
  "id": 0,
  "name": "string",
  "address": "string"
}
```
