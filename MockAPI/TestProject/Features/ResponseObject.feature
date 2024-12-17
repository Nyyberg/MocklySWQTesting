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
        When I give an Valid JToken
        Then The dictionary should be empty

Feature: Get Typed Value
    
    Scenario: Get a strings type from a value
        Given The value is of a string
        Then It should return String as a type

    Scenario: Get a Object User type from a value
        Given The value is of a User
        Then It should return User as a type

    Scenario: Get a Int type from a value
        Given The value is of a Int
        Then It should return Int as a type

Feature: Add Element to JObject
    
    Scenario: Add an Int to an empty JObject with no path
        Given The JObject is empty
        And The Path is empty
        When I give a int ObjectValue
        Then It should do nothing

    Scenario: Add an Null to an Nested JObject with no path
        Given The JObject is empty
        And The Path is empty
        When I give a Null ObjectValue
        Then It should add null to JObject

    Scenario: Add an String to an Nested JObject with a path
        Given The JObject is nested
        And The Path is not empty
        When I give a string ObjectValue
        Then It should add string to JObject

Feature: Deserialize Data
    
    Scenario: Deserialize Data with wrong encoding
        Given The ByteArray is encoded wrong
        And The dictionary is empty
        Then Throw an error

    Scenario: Deserialize Data with empty dictionary
        Given The ByteArray is encoded correct
        And The dictionary is empty
        Then Gives an empty dictionary

    Scenario: Deserialize Data with filled dictionary
        Given The ByteArray is encoded correct
        And The dictionary is not empty
        Then Gives an filled dictionary

    Scenario: Deserialize Data with a zero length ByteArray
        Given The ByteArray is encoded correct
        And The dictionary is not empty
        Then Throw an error

Feature: From Json
    
    Scenario: Valid Json
        Given The Json is structered correct
        Then It gives a dictionary

    Scenario: Invalid Json
        Given The Json is not structered correct
        Then Throw an error

    Scenario: Valid empty Json
        Given The Json is structered correct
        Then It gives an empty dictionary

Feature: Convert Dictionary To JObject
    
    Scenario: Dictionary with no elements
        Given The Dictionary is empty
        Then Gives a empty JObject

    Scenario: Dictionary with elements
        Given The Dictionary is filled
        Then Gives a filled JObject