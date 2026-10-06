<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128585592/26.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4930)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# How to connect to a remote data service instead of using a direct database connection

In this example, we will create a WCF [IDataStore](https://docs.devexpress.com/CoreLibraries/DevExpress.Xpo.DB.IDataStore) service that will be used by our client (**Console Application**) as a data layer. Instead of the direct connection to the database, our client will connect to a remote service, which is way more secure and thus important in many enterprise scenarios as database connection settings are not exposed to the client.

## Implementation Details

1. Create a new **WCF Service Application** project and add references to the **DevExpress.Data**, **DevExpress.Xpo**, and **DevExpress.Xpo.Services** assemblies and remove files with auto-generated interfaces for the service.
2. Modify the service class as shown in the _Service1_ file. This service initializes a connection provider and stores it in the static `DataStore` property, which is then used by the base `DataStoreService` class.
3. Change some binding properties as shown in the example's _web.config_ file. At this stage, the service part is ready to work and we need to implement a client to consume data from our data store service (for demonstration purposes, we will create a Console Application).
4. Add the **Console Application** into the existing solution.
5. Add a new code file for a `Customer` class using the **DevExpress vXX.X ORM Persistent Object** item template. See a code of `Customer` class in the _ConsoleApplication\Customer_ code file.
6. Pass the address of our service into the [GetDataLayer](https://docs.devexpress.com/XPO/DevExpress.Xpo.XpoDefault.GetDataLayer.overloads) method of the [XpoDefault](https://docs.devexpress.com/XPO/DevExpress.Xpo.XpoDefault) class. For this, modify the `Main` method of the **Console Application** as shown in the _ConsoleApplication\Program_ code file. Please note that the port number in the connection string may be different. You can check it in the properties of the service project in the Solution Explorer:

<img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-connect-to-a-remote-data-service-instead-of-using-a-direct-database-connection-e4930/13.1.7+/media/3d4ab490-98e6-4cb4-acce-1cc6f70db881.png">


As a result, we will see the following output:

<img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-connect-to-a-remote-data-service-instead-of-using-a-direct-database-connection-e4930/13.1.7+/media/d85f8375-4b16-4e74-8843-301bd1cac92f.png">


### Important notes

If you are using an XAF client, then in the simplest case, you can just set the _XafApplication.ConnectionString_ to the address of your data store service (<a href="http://localhost:55777/Service1.svc">http://localhost:55777/Service1.svc</a>). Refer to the [Specify EF Core Database Provider in XAF Application](https://docs.devexpress.com/eXpressAppFramework/404290/business-model-design-orm/business-model-design-with-entity-framework-core/connect-to-different-database-providers) help article for more details.

### Troubleshooting

1. If WCF throws the "_Request Entity Too Large_" error, you can apply a standard solution from StackOverFlow: <a href="http://stackoverflow.com/questions/10122957/">http://stackoverflow.com/questions/10122957/</a>
2. If WCF throws the "_The maximum string content length quota (8192) has been exceeded while reading XML data._" error, you can extend bindings in the following manner as per <a href="http://stackoverflow.com/questions/6600057/the-maximum-string-content-length-quota-8192-has-been-exceeded-while-reading-x">http://stackoverflow.com/questions/6600057/the-maximum-string-content-length-quota-8192-has-been-exceeded-while-reading-x</a>:</p>


```xml
<bindings>
      <basicHttpBinding>
        <binding name="ServicesBinding" maxBufferPoolSize="2147483647" maxReceivedMessageSize="2147483647" maxBufferSize="2147483647" transferMode="Streamed" >
          <readerQuotas maxDepth="2147483647"
            maxArrayLength="2147483647"
            maxStringContentLength="2147483647"/>
        </binding>
      </basicHttpBinding>
</bindings>
```

## Files to Review

* [Program.cs](./CS/ConsoleApplication1/Program.cs) (VB: [Program.vb](./VB/ConsoleApplication1/Program.vb))
* [Service1.svc.cs](./CS/WcfService1/Service1.svc.cs) (VB: [Service1.svc.vb](./VB/WcfService1/Service1.svc.vb))
* [Web.config](./CS/WcfService1/Web.config) (VB: [Web.config](./VB/WcfService1/Web.config))

## Documentation

* [Transfer Data via WCF Services](https://docs.devexpress.com/XPO/10018/connect-to-a-data-store/transfer-data-via-wcf-services)

## More Examples

* [How to create a data caching service that helps improve performance in distributed applications](https://github.com/DevExpress-Examples/XPO_how-to-create-a-data-caching-service-that-helps-improve-performance-in-distributed-e4932)
* [How to implement a distributed object layer service working via WCF](https://github.com/DevExpress-Examples/XPO_how-to-implement-a-distributed-object-layer-service-working-via-wcf-e5072)
* [How to connect to remote data store and configure WCF end point programmatically](https://github.com/DevExpress-Examples/XPO_how-to-connect-to-remote-data-store-and-configure-wcf-end-point-programmatically-e5137)

<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XPO_how-to-connect-to-a-remote-data-service-instead-of-using-a-direct-database-connection-e4930&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XPO_how-to-connect-to-a-remote-data-service-instead-of-using-a-direct-database-connection-e4930&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
