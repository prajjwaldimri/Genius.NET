# Account

Account information includes general contact information and Genius-specific details about the authenticated user.

## Getting the account information

``` C#
var accountInfo = geniusClient.AccountsClient.GetAccountInfo(TextFormat.Dom);
```