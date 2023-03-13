Feature: ShoppingOnline

As an online store owner, my goal is to create a seamless shopping and checkout experience for customers, including applying discounts and order verification.

  Background:

    Given I am logged in to my account


@Scenario1
Scenario: Apply discount coupon to cart
	When I add an item to my cart
	When  I apply the discount coupon edgewords
	Then I should see a 15% discount applied to my cart total
	And I should be able to logout

@Scenario2
Scenario: Purchase item and confirm order number
    When I add an item to my cart
    And I proceed to checkout
	Then The order number shown should match the order number on orders page
	And I should be able to logout