Feature: Wallet service spec tests

A short summary of the feature


Scenario Outline: Get balance from not active user
	Given New user Id
	And Delete first user Id when based on '<remove>'
	When Get Balance status code
	Then Get Balance Status code is 'InternalServerError'
	Examples: 
	| remove |
	| true   |
	| false  |

Scenario: Get balance from active user
	Given New user Id
	And Set user status active
	When Get Balance status code
	Then Get Balance Status code is 'OK'

Scenario Outline: Get balance one transaction
	Given New user Id
	And Set user status active
	And Set charge body with <amount>
	And Charge user negative value: <negative>
	When Get Balance status code
	Then Get Balance Status code is 'OK'
	Examples: 
	| amount     | negative |
	| 0.01       | false    |
	| 0.01       | true     |
	| 9999999.99 | false    |
	| 10000000   | false    |
	
Scenario Outline: Charge not active existing user
	Given New user Id
	And Delete first user Id when based on '<remove>'
	And Set charge body with 100000000
	And Charge user negative value: false
	When Get Balance status code
	Then Get Balance Status code is 'InternalServerError'
	Examples: 
	| remove |
	| true   |
	| false  |

Scenario Outline: Charge less than balance
	Given New user Id
	And Set user status active
	And add to default balance: '<boolean>'
	And Set charge body with <amount>
	When Get Charge Status Code
	Then Get Charge Status Code is '<statusCode>'
	Examples: 
	| amount      | statusCode          | boolean |
	| -30         | InternalServerError | false  |
	| 10000000.01 | InternalServerError | false  |
	| -0.01       | InternalServerError | false  |
	| 0.001       | InternalServerError | false  |
	| 0.01        | OK                  | false  |
	| -0.01       | OK                  | true   |
	| 0           | InternalServerError | true   |
	| 0           | InternalServerError | false  |


Scenario Outline: Charge Negative Balance
	Given New user Id
	And Set user status active
	And Set charge body with 1000
	And Charge user negative value: true
	And Set charge body with <amount>
	When Get Charge Status Code
	Then Get Charge Status Code is '<statusCode>'
	Examples: 
	| amount      | statusCode          |
	| 10001000    | OK                  |
	| 10001000.01 | InternalServerError |


