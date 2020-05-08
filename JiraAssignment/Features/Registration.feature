Feature: Registration


@mytag
Scenario: Registering Email on JIRA
	Given Jira tab opend for registration
	And fill the form with registration details
	| FName | LName | Company | Email                  |
	| test  | test  | test    | test.anikesh@gmail.com |
	When I press submit
	Then User should recieve a mail
	| Email                  | Password       |
	| test.anikesh@gmail.com | qwertyanikesh |

Scenario: Login to new Account
	Given Fetch the login link from gmain using following credentials
	| Email                  | Password       |
	| test.anikesh@gmail.com | qwertyanikesh |
	And open the link
	When I Enter the new passwor "password_ani"
	And Click Reset
	Then login page should be visible
	When I Enter username and password "password_ani"
	Then dashboard should be visible 
	When I click on create project from projects menue
	Then Create project frame should visible
	When I select any project and fill the details
	Then new project should be created 
	When I click on create button
	And I select User story and fill the details and press submit
         | Summary											|
         | As a user I should be able to pay using Upi		|
	Then A user story must be created in backlog



	


