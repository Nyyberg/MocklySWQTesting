Feature: From Json

    Scenario: Valid Json
        Given The Json is structered correct
        Then It gives a dictionary

    Scenario: Valid empty Json
        Given The Json is structered correct but empty
        Then It gives an empty dictionary