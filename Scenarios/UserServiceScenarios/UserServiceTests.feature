Feature: User service spec tests

A short summary of the feature


Scenario Outline: Register new user with null values
	Given New user response body with '<firstName>' '<lastName>'	
	When Get response from register user
	Then Status code from register user response is '<StatusCode>'	
	
	Examples: 
	| firstName | lastName | StatusCode          |
	| null      | null     | InternalServerError |
	| ""        | null     | InternalServerError |

Scenario Outline: Register User names with different lengths
	Given New user response body with '<length>' 
	When Get response from register user
	Then Status code from register user response is '<StatusCode>'
	Examples: 
	| length | StatusCode |
	| 0      | OK         |
	| 1      | OK         |
	| 100    | OK         |
	| 500    | OK         |
	
Scenario Outline: Register User Increases ID
	Given New user Id
	And Delete first user Id when based on '<boolean>'
	When Get Id for second user
	Then Second Id is greater than first Id
	Examples: 
	| boolean |
	| false   |
	| true    |



Scenario: Delete and get a not active user
	Given New user Id
	Given Get Status from new user
	When Get StatusCode from deleting user
	Then User status is 'false' and Delete StatusCode is 'OK'


Scenario: Delete not existing user
	Given New user Id
	And Delete first user Id when based on 'true'
	When Get StatusCode from deleting user
	Then Status code from delete is 'InternalServerError'

Scenario: Set status of not existing user
	Given New user Id
	And Delete first user Id when based on 'true'
	When Get StatusCode from set status
	Then Status code from set is 'InternalServerError'

	Scenario: Get status of not existing user
	Given New user Id
	And Delete first user Id when based on 'true'
	When Get StatusCode from Get status
	Then Body from get status is 'Sequence contains no elements'
	

