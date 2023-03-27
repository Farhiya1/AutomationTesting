# E-Commerce-AutomationTesting

# Shopping Online Steps

This is a C# project for automating e-commerce testing using SpecFlow and Selenium. The project includes two end-to-end tests that cover multiple pages and scenarios to simulate a real-world shopping experience.

# Prerequisites

- Visual Studio
- SpecFlow
- Selenium WebDriver
- ChromeDriver

# NuGet Packages

The following NuGet packages are required for this project:

- Selenium.WebDriver 
- Selenium.WebDriver.ChromeDriver 
- SpecFlow.NUnit 
- NUnit3TestAdapter 
- NUnit 
- Microsoft.NET.Test.Sdk 
- FluentAssertions 
- SpecFlow.Plus.LivingDocPlugin 
- NUnitXml.TestLogger 

# Getting Started

1. Clone this repository to your local machine.
2. Open the solution file in Visual Studio.
3. Install the necessary NuGet packages.
4. Download and install the ChromeDriver.
5. Run the tests.


# Running the Tests

To run the tests, open the Test Explorer in Visual Studio and click the "Run All" button. You can also run individual tests by selecting them from the Test Explorer and clicking the "Run" button.

# Feature File

The project's feature file, ShoppingOnline.feature, includes the following scenarios:

1. Scenario: Apply discount coupon to cart

This scenario verifies that the user is able to add an item to their cart, apply a discount coupon, and see the correct discount applied to their cart total.

2. Scenario: Purchase item and confirm order number.

This scenario verifies that the user is able to add an item to their cart, proceed to the checkout page, place an order, and confirm that the order number displayed on the order confirmation page matches the order number on the user's orders page.

Each scenario is preceded by a brief description of the behavior it verifies. The scenarios are designed to test the functionality of the login page, shop page, cart page, checkout page, and order confirmation page.



# Steps

The test scenarios in the project consist of the following steps in the steps definition file, which represent the sequence of actions performed by the scenarios and the breakdown of the project's functionality:

- Given I am logged in to my account: This step logs in the user to their account.
- When I add an item to my cart: This step adds an item to the user's cart.
- When I apply the discount coupon "coupon": This step applies a discount coupon to the user's cart.
- Then I should see a verifyCouponDiscount% discount applied to my cart total: This step verifies the discount applied to the user's cart.
- When I proceed to checkout: This step proceeds the user to the checkout page.
- Then The order number shown should match the order number on orders page: This step verifies the order number on the order confirmation page with the order number on the orders page.

# POM Classes

The project includes the following POM classes:

- LoginPOM: This class represents the behavior of the login page. It contains methods for entering the user's credentials and logging in to their account.
- ShopPOM: This class represents the behavior of the shop page. It contains methods for selecting and adding items to the user's cart.
- CartPOM: This class represents the behavior of the cart page. It contains methods for applying discount coupons, navigating to the checkout page, and retrieving cart information such as the subtotal and shipping fees.
- CheckoutPOM: This class represents the behavior of the checkout page. It contains methods for entering the user's billing information and placing an order.
- OrderConfirmationPOM: This class represents the behavior of the order confirmation page. It contains methods for verifying the order number displayed on the page.
- OrdersPOM: This class represents the behavior of the orders page. It contains methods for retrieving the user's order history and verifying the order number displayed on the page.



# Contact:

Thank you for checking out this project. I hope you found it useful and informative. If you have any questions or suggestions, please feel free to contact me.

Email: farhiya.mahamud@nfocus.co.uk