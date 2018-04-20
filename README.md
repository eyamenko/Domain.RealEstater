## Domain.RealEstater

### Description

This application consists of three parts: an API, a web client and a service.

In real life it can take a while to match properties, therefore we need to use asynchronous processing.
This application has a silly queue system that serves this purpose.

### API

Here is a sample API request:

`POST http://localhost:5000/api/advertising/properties`

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Property>
	<Address>4 McDonald Street, Potts Point NSW</Address>
	<AgencyCode>LRE</AgencyCode>
	<Name>Luxurious Apartments</Name>
	<Latitude>-33.8677394</Latitude>
	<Longitude>151.2229558</Longitude>
</Property>
```

### Service

Property Worker is the main component that dequeues messages every 2 seconds and performs correspondent matching logic.

### Web client

Web client displays all advertised properties.

### Prerequisites

* Node.js >= 8.0.0
* .NET Core SDK >= 2.0.0
