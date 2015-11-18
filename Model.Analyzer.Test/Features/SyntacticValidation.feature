Feature: SyntacticValidation
	In analyzer to avoid syntactic error
	As a user
	I want to be check work syntactic parser

Scenario Outline: Correct expression

	Given I have standard lexical and syntactic analyzers
	When I input expression <expression>
	Then the result hasn't errors

	 Examples: 
		| expression       |
		| 1+2-8*func(1)    |
		| -2+3	           |
		| 16+41-(2*3)      |
		| 1 / 45 + (3-6)   |


Scenario Outline: Incorrect expression

	Given I have standard lexical and syntactic analyzers
	When I input expression <expression>
	Then the result has errors

	 Examples: 
		| expression       |
		| 1+2-8*func(1))   |
		| -2+3/	           |
		| 16+41)-(2*3)     |
		| 1 / 45? + (3-6)  |
