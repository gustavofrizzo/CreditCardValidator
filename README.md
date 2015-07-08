# CreditCardValidator

CreditCardValidator helps you implementing validations for the most common credit card brands, verifying length, prefixes and checking the card number through the Luhn algorithm if necessary.

## Issuing network Supported 

The following issuing institutes are supported:

<table>
<tr>
<td>AmericanExpress</td> <td>MasterCard</td> <td>Maestro</td> <td>DinersClub</td> <td>Discover</td> 
</tr>
<tr>
<td>Hipercard</td> <td>Visa</td>  <td>Laser</td> <td>ChinaUnionPay</td> <td>Dankort</td> 
</tr>
<tr>
<td>Rupay</td> <td>Solo</td> <td>Switch</td> <td>JCB</td>
</tr>
</table>

## Usage

#### CreditCardDetector

```csharp
CreditCardDetector detector = new CreditCardDetector("4012 8888 8888 1881");
detector.CardNumber; // 4012888888881881
detector.IsValid(); // true
detector.IsValid(CardIssuer.Maestro); // false
detector.Brand; // CardIssuer.Visa
detector.BrandName; // Visa
detector.IssuerCategory; // Banking and financial
```

#### CreditCardFactory

Generate random credit card numbers from an specific CardIssuer.

```csharp
string visaNumber = CreditCardFactory.RandomCardNumber(CardIssuer.Visa);
string amexNumber = CreditCardFactory.RandomCardNumber(CardIssuer.AmericanExpress);
string masterCardNumber = CreditCardFactory.RandomCardNumber(CardIssuer.MasterCard);
string chinaUnionPayNumber = CreditCardFactory.RandomCardNumber(CardIssuer.ChinaUnionPay);
```

#### CreditCardStringExtension

```csharp
// TODO
```
#### Luhn

```csharp
// TODO
```
