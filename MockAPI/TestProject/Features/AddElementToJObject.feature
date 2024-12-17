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