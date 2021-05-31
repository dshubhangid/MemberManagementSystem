# MemberManagementSystem 

We need to save and manage information about our
members (name and address). Each member can have one or more accounts where he or she can collect
points (e.g.: for one international flight with Lufthansa the user gets 150 points) or redeem points from
(e.g.: 100 points from his/her account in exchange for a free coffee). Points are stored as a balance on
each account. Each account has a name identifying the company from which the points were collected
and status telling if the account is active or inactive. Points cannot be redeemed from an inactive or empty
account.

## Source Code

Application is using in-memory database provided by ASP.net core.

Application is available at following GitHub repository.

[https://github.com/dshubhangid/EmployeeDetailsWebApi.git](url)

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

***Note***: System also automatically loads some initial dummy data on application startup.

##### Dummy existing Member json for import
```
[
	{
		"Name": "Anakin Skywalker",
		"Address": "Landsberger Straﬂe 110",
		"Accounts": 
		[
			{
				"Name": "Burger King",
				"Balance": 10,
				"Status": "ACTIVE"
			},
			{
				"Balance": 150,
				"Status": "INACTIVE",
				"Name": "Fitness First"
			}
		]
	},
	{
		"Name": "Darth Vader",
		"Address": "Landsberger Straﬂe 112",
		"Accounts": 
		[
			{
				"Balance": 10,
				"Status": "ACTIVE",
				"Name": "Lufthansa"
			}
		]
	},
	{
		"Name": "Obi-Wan Kenobi",
		"Address": "Landsberger Straﬂe 114",
		"Accounts": 
		[
			{
				"Balance": 0,
				"Status": "ACTIVE",
				"Name": "Lufthansa"
			},
			{
				"Balance": 17,
				"Status": "ACTIVE",
				"Name": "Fitness First"
			},
			{
				"Name": "Burger King",
				"Balance": 20,
				"Status": "ACTIVE"
			}
		]
	},
	{
		"Name": "Yoda",
		"Address": "Landsberger Straﬂe 114",
		"Accounts": 
		[
			{
				"Balance": 10,
				"Status": "ACTIVE",
				"Name": "Lufthansa"
			}
		]
	}
]
```

##### Endpoint

```
 URL: https://localhost:44339/api/members/uploadmembers
 METHOD: GET

```
