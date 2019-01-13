Feature: Test WebSite Service365

Scenario: Use customer account to logon
	Given User go to Login Page
	When User input username and password
	And  User press Login
	Then User go to Home Page
	When User click LOG OFF
	Then User go to unlogon Home Page

