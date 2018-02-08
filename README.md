# Openpay Client API built for Xamarin

Xamarin based Cross-Platform client API for the [Openpay](https://www.openpay.mx/) platform.

## Supported Platforms
* iOS 10+
* Android
* .NET Standard 2.0

## Setup
* Available on NuGet: https://www.nuget.org/packages/Openpay.Xamarin [![NuGet](https://img.shields.io/nuget/v/Openpay.Xamarin.svg?label=NuGet)](https://www.nuget.org/packages/Openpay.Xamarin/)
* Install into your PCL project and Client projects.

### Initialize
In your App.xaml.cs call

```csharp
private const string MerchantId = "mi93pk0cjumoraf08tqt";
private const string ApiKey = "pk_92e31f7c77424179b7cd451d21fbb771";

protected override OnStart()
{
    base.OnStart();
  
    // Initialize Openpay
    if (CrossOpenpay.IsSupported)
    {
        CrossOpenpay.Current.Initialize(MerchantId, ApiKey, false);
    }
}
```

### iOS
```
Nothing is necessary
```

### Android
In your Android MainActivity.cs call

```csharp
global::Xamarin.Forms.Init(); // Platform specific init
global::Openpay.Xamarin.OpenpayAndroidImpl.Init(this);

LoadApplication(new App());
```

## Usage
Use from your shared project.
### Creating tokens
To create a token simply call *CreateTokenFromCard*:

```csharp
if (CrossOpenpay.IsSupported)
{
    Card card = new Card
    {
        HolderName = "Francisco Pantera",
        Number = "4111111111111111",
        ExpirationMonth = "12",
        ExpirationYear = "21",
        Cvv2 = 132
    };

    var token = await CrossOpenpay.Current.CreateTokenFromCard(card);
}
```

### Fraud detection using device data
To create a token simply call *CreateDeviceSessionId*:

```csharp
if (CrossOpenpay.IsSupported)
{
    var deviceSessionId = await CrossOpenpay.Current.CreateDeviceSessionId();
}
```

## License
The MIT License (MIT) see [License file](LICENSE)

## Disclaimer
*Openpay.Xamarin* is not supported by Openpay. For official client libraries see:
* [openpay-android](https://github.com/open-pay/openpay-android)
* [openpay-ios](https://github.com/open-pay/openpay-ios)
* [openpay-swift-ios](https://github.com/open-pay/openpay-swift-ios)
* [Referencia API Openpay](https://www.openpay.mx/docs/api/)
