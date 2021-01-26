Feature: GET Car Information

Scenario: Validate 200 response - GET for Saloon Cars
	Given When I call the GET endpoint with "Saloon"
	Then The expected output as below
	| Make     | Model | Year | Type   | ZeroToSixty | Price |
	| BMW      | 3.25i | 2013 | Saloon | 9.5         | 15000 |
	| Audi     | S4    | 2015 | Saloon | 8.3         | 17500 |
	| Mercedes | C200  | 2018 | Saloon | 8           | 25000 |

Scenario: Validate 200 response - GET for Hatchback Cars
	Given When I call the GET endpoint with "Hatchback"
	Then The expected output as below
	| Make       | Model  | Year | Type      | ZeroToSixty | Price |
	| Ford       | Fiesta | 2012 | Hatchback | 23          | 3000  |
	| Volkswagen | Golf   | 2015 | Hatchback | 12          | 12000 |

Scenario: Validate 200 response - GET for SUV Cars
	Given When I call the GET endpoint with "SUV"
	Then The expected output as below
	| Make   | Model        | Year | Type | ZeroToSixty | Price |
	| Toyota | Land Cruiser | 2018 | Suv  | 12          | 45000 |

Scenario: Validate 404 response 
	Given When I call the GET endpoint with "Tesla"
	Then I should see the response status code as "NotFound"


@manual
Scenario: Validate 401 response
	Given When I call the GET endpoint with "Saloon"
	And I dont pass an authentication token
	Then I should see the response status code as "401"

@manual
Scenario: Validate 500 response
	Given When I call the GET endpoint with "Saloon"
	And The Server encountered an unexpected condition
	Then I should see the response status code as "500"

@manual
Scenario: Validate 503 response
	Given When I call the GET endpoint with "Saloon"
	And The Server is not available
	Then I should see the response status code as "500"