Feature: ShoppingOnline

 As a business owner, I want customers to be able to search for, add, and purchase items online with ease. 

  Background:
    Given I am logged in to my account




Scenario: Apply discount coupon to cart
	When I add an item to my cart
	When  I apply the discount coupon edgewords
	Then I should see a 15% discount applied to my cart total
	And I should be able to logout

	Scenario: Purchase item and check order number
    When I add an item to my cart
    And I proceed to checkout
	Then I should see my order number on the confirmation page
	And I should be able to logout