﻿Feature: Appointments

***************************************************************************************************************************************************************************************************
  ------------------------------------------------ Simple example to use specflow need to use a test database or generate datbase every test----------------------------------------------------
***************************************************************************************************************************************************************************************************


Scenario: Appointments number
	Given get all the appointments
	Then check if appointments number is bigger of 2 and the status fo the response is 200