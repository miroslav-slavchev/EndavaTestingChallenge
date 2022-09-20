﻿Feature: SwagLabsScenariosV1
	Test Scenarios for https://www.saucedemo.com/
	
Background:
	Given Log in with the standard user

Scenario: Scenario 1 - Use the standard user and password (they are prone to change, think how to obtain them)
	When Add the first and the last items in the cart
	When Go to checkout
	Then Verify the correct items are added
	When Remove the first item from cart
	And Go to all items
	And Add the previous to the last item in the cart
	And Go to checkout
	Then Verify the correct items are added
	When Proceed to checkout
	And Enter billing details
		| First Name | Last Name | Zip/Postal Code |
		| Test FN    | Test LN   | 1000            |
	And Finish the order
	Then Verify order is placed
	When Go to checkout
	Then Verify cart is empty

Scenario: Scenario 2 - Sorting
	Then Verify when for sorting it is selected "Price (high to low)"
	And The items are sorted in the correct manner
	And Logout from the system




