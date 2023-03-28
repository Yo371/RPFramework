Feature: Widgets

@Widgets
Scenario Outline: Verify adding widgets
	Given Report portal page is opened
	And User is logged in Report portal
	And Project 'testproject' is chosen
	Then All Dashboards page is opened
	And Choose 'DEMO DASHBOARD' dashboard
	And Create new widget with < TypeOfWidget > type and 'DEMO_FILTER' filter
	Then The new widget is created with < TypeOfWidget > type on All Dashboards page
	
	Examples:
	| TypeOfWidget            |
	| Launch statistics chart |
	| Overall statistics      |
	| Launches duration chart |