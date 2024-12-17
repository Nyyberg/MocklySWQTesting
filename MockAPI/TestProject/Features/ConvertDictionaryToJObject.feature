Feature: Convert Dictionary To JObject
    
    Scenario: Dictionary with no elements
        Given The Dictionary is empty
        Then Gives a empty JObject

    Scenario: Dictionary with elements
        Given The Dictionary is filled
        Then Gives a filled JObject