# CreditCardValidator ![.NET Core](https://github.com/gustavofrizzo/CreditCardValidator/workflows/.NET%20Core/badge.svg)

CreditCardValidator helps you implementing validations for the most common credit card brands, verifying length, prefixes and checking the card number through the Luhn algorithm if necessary.

Nuget Package -> https://www.nuget.org/packages/CreditCardValidator

## Supported Card Issuers 

The following card issuers are supported:

<table>
<tr>
<td>AmericanExpress</td> <td>MasterCard</td> <td>Maestro</td> <td>DinersClub</td> <td>Discover</td> 
</tr>
<tr>
<td>Hipercard</td> <td>Visa</td>  <td>Laser</td> <td>ChinaUnionPay</td> <td>Dankort</td> 
</tr>
<tr>
<td>Rupay</td> <td>Solo (Deprecated)</td> <td>Switch</td> <td>JCB</td>
</tr>
</table>

## Usage

#### CreditCardDetector

```csharp
CreditCardDetector detector = new CreditCardDetector("4012 8888 8888 1881");
detector.CardNumber; // => 4012888888881881

detector.IsValid(); // => True
detector.IsValid(CardIssuer.Maestro); // => False

detector.Brand; // => CardIssuer.Visa
detector.BrandName; // => Visa

detector.IssuerCategory; // => Banking and financial
```

#### CreditCardFactory

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

#### CreditCardStringExtension

```csharp
"4953089013607".CreditCardBrand(); // => CardIssuer.Visa

"4953089013607".CreditCardBrandName() // => Visa

"348051773827666".ValidCreditCardBrand(CardIssuer.AmericanExpress); // => True

"495308".CreditCardBrandIgnoreLength(); // => CardIssuer.Visa

"495308".CreditCardBrandNameIgnoreLength() // => Visa
```
#### Luhn

```csharp
Luhn.CheckLuhn("4953089013607"); // => True
Luhn.CreateCheckDigit("495308901360"); // => 7
```

## Contributing

1. Fork it
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create new Pull Request
