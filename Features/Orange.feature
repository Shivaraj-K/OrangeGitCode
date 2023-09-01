Feature: Login to OrangeHRM

Scenario: Successful Login and Adding Employee
	Given User on the OrangeHRM login page
	When User login with valid Credential
	And User Select Item name as "PIM" in main-menu
	And Add the employee 
	Then Verify Addeed employee present inthe Employee List
