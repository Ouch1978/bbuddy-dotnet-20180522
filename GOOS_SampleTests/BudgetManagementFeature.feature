@web
Feature: BudgetManagement

Scenario: Add new budget from scratch
	When Add a budget with YearMonth "2018-05" and Amount 500 
	Then the following budget will be added
	| YearMonth | Amount |
	| 2018-05   | 500    |
