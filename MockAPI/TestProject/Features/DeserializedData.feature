Feature: Deserialize Data

    Scenario: Deserialize Data with wrong encoding
        Given The ByteArray is encoded wrong
        Then Throw an error

    Scenario: Deserialize Data with empty dictionary
        Given The ByteArray is encoded correct
        Then Gives an empty dictionary

    Scenario: Deserialize Data with filled dictionary
        Given The ByteArray is encoded correct with data
        Then Gives an filled dictionary

    Scenario: Deserialize Data with a zero length ByteArray
        Given The ByteArray is zero
        Then Throw an error exception

