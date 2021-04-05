# Integration tests

This is a demo project for Integration tests with WireMock.net. 
The complete blog post you can find here: [Using WireMock for dotnet core Integration tests](https://pcholko.com/posts/2021-04-05/wiremock-integration-test/)

## Run services locally

```sh
dotnet run --project CatalogueService/CatalogueService.csproj &
dotnet run --project InventoryService/InventoryService.csproj &
```

## Test services

Update inventory:

```sh
curl -X PUT --location "http://localhost:5000/v1/inventory" \
    -H "Content-Type: application/json" \
    -d "{
          \"ProductId\": \"yellow-wings\",
          \"Quantity\": 699
        }"
```

Get products catalogue:

```sh
curl -X GET --location "http://localhost:5010/v1/catalogue/products"
```

## Execute integration tests

```sh
dotnet test CatalogueService.Tests/CatalogueService.Tests.csproj 
```
