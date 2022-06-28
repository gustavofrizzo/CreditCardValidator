# CreditCardValidator [![Build & Tests](https://github.com/gustavofrizzo/CreditCardValidator/actions/workflows/dotnet-build-and-tests.yml/badge.svg)](https://github.com/gustavofrizzo/CreditCardValidator/actions/workflows/dotnet-build-and-tests.yml)

CreditCardValidator helps you validate credit card numbers, identify its issuer (Visa, Mastercard, etc), verify length, prefixes and check it through the Luhn algorithm.

It can also generate random credit card numbers for testing purposes.

Nuget Package -> https://www.nuget.org/packages/CreditCardValidator

## Supported Card Issuers 

The following card issuers are supported:


||||||
|-|-|-|-|-|
|AmericanExpress|MasterCard|Maestro|DinersClub|Discover|
|Hipercard|Visa|Laser|ChinaUnionPay|Dankort|
|Rupay|Solo (Deprecated)|Switch|JCB|-|


## Usage

### CreditCardDetector

```csharp
CreditCardDetector detector = new CreditCardDetector("4012 8888 8888 1881");
detector.CardNumber; // => 4012888888881881

detector.IsValid(); // => True
detector.IsValid(CardIssuer.Maestro); // => False

detector.Brand; // => CardIssuer.Visa
detector.BrandName; // => Visa

detector.IssuerCategory; // => Banking and financial
```

### CreditCardFactory

Generates random credit card numbers of a specific CardIssuer.

```csharp
string visaNumber = CreditCardFactory.RandomCardNumber(CardIssuer.Visa);
// => 4953089013607
string amexNumber = CreditCardFactory.RandomCardNumber(CardIssuer.AmericanExpress);
// => 373485467448025
string masterCardNumber = CreditCardFactory.RandomCardNumber(CardIssuer.MasterCard);
// => 5201294442453002
string chinaUnionPayNumber = CreditCardFactory.RandomCardNumber(CardIssuer.ChinaUnionPay);
// => 6280209982074556
```

Generates random credit card numbers of a specific CardIssuer with any valid card length.

```csharp
string visaNumber = CreditCardFactory.RandomCardNumber(CardIssuer.Visa, 16);
// => 4556672647860978
```

### CreditCardStringExtension

```csharp
"4953089013607".CreditCardBrand(); // => CardIssuer.Visa

"4953089013607".CreditCardBrandName() // => Visa

"348051773827666".ValidCreditCardBrand(CardIssuer.AmericanExpress); // => True

"495308".CreditCardBrandIgnoreLength(); // => CardIssuer.Visa

"495308".CreditCardBrandNameIgnoreLength() // => Visa
```
### Luhn

```csharp
Luhn.CheckLuhn("4953089013607"); // => True
Luhn.CreateCheckDigit("495308901360"); // => 7
```
