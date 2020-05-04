Feature: Jira Assignment

@mytag
Scenario: Login to the Jira Dashboard
	Given A JIRA tab open on the browser
	And Enter the Username "user15" and Password "anikesh"
	When I press Login
	Then Dashboard should be visible
