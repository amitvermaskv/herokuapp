# The Internet - HeroKuApp   [![build and test](https://github.com/amitvermaskv/herokuapp/actions/workflows/build-test.yml/badge.svg)](https://github.com/amitvermaskv/herokuapp/actions/workflows/build-test.yml)
## _Add/Remove Elements UI Test_

This repository contains UI test for
- Navigating to The Internet (https://the-internet.herokuapp.com/add_remove_elements/)
- Adding (n) number of elements on the page
- Assert that (n) number of elements exists on the page

 **Test Framework Components**
 - **Selenium WebDriver** for interacting with browser page
 - **XUnit** for writing C# unit tests
 - **Extent Report** for generating detailed test execution HTML report
 
## _How to execute tests_

Tests can be executed from Visual Studio Tests Explorer. There is a conditional check, when the tests are executed loccally they are executed in Chrome UI mode, but when the tests are executed in GitHub Actions, they are executed in Chrome Headless mode.

When the test execution is completed, a detailed HTML test report is created in _**bin/[build_config]/ExtentReport/index.html**_
