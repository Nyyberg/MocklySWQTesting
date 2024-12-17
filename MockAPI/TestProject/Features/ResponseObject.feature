Feature: Add Elements To Dictionary
    
    Scenario: Add Elements to the dictionary with valid JToken
        Given The current dictionary has 10 elements in it
        And The String parent is empty
        When I give an Valid JToken
        Then The JToken should be added to the dictionary

    Scenario: Add Elements to the dictionary with invalid JToken
        Given The current dictionary has 10 elements in it
        And The String parent is empty
        When I give an Invalid JToken
        Then It should throw an error

    Scenario: Add Elements to the dictionary with empty JToken
        Given The current dictionary has 0 elements in it
        And The String parent is filled
        When I give an Empty JToken
        Then The empty JToken should be added to the dictionary