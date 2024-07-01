Feature: ShoppingOnline

As an online store owner, my goal is to create a seamless shopping and checkout experience for customers, including applying discounts and order verification.

  Background:

    Given I am logged in to my account



Scenario Outline: Apply discount coupon to cart
	When I add an "<item>" to my cart
	And I apply the discount coupon "<coupon>"
	Then I should see a <discountPercentage>% discount applied to my cart total


	Examples: 
	
	| item       | coupon    | discountPercentage |
	| Polo       | edgewords | 10                 |
	| Hoodie     | edgewords | 15                 |
	| Sunglasses | edgewords | 15                 |
	| Cap        | edgewords | 15                 |
	| Belt       | edgewords | 15                 |
	



Scenario Outline: Purchase item and confirm order number
    When I add an "<item>" to my cart
    And I proceed to checkout
	Then The order number shown should match the order number on orders page


	Examples: 

	| item       |
	| Polo       |
	| Hoodie     |
	| Sunglasses |
	
	
	