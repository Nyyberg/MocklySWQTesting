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