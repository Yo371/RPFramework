Feature: Launches


	@Launches
	Scenario Outline: Verify Launches data
		Given Report portal page is opened
		And User is logged in Report portal
		And Launches page of project 'testproject' is opened
		Then Launch with name 'Demo Api Tests' number 2 consists data
		| Title          | Total | Passed | Failed | Skipped | ProductBug | AutoBug | SystemIssue | ToInvestigate |
		| Demo Api Tests | 15    | 5      | 9      | 1       | 1          | 5       | 4           | 8             |
		
