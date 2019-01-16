Feature: Test WebSite Service365

Scenario: Use customer account to logon
	Given User go to Login Page
	When User input username and password
	And  User press Login
	Then User go to Home Page
	When User click LOG OFF
	Then User go to unlogon Home Page

Scenario: Customer create one Order then Cancel it
	Given User log in as customer
	And User go to Service Page
	When User search for specific service
	And User click Book Now
	Then User go to place order page
	Given User do some setup
	And User click Submit
	Then User go to Order detail page
	When User Cancel Order
	Then on order detail page, the status shows Order Cancelled
