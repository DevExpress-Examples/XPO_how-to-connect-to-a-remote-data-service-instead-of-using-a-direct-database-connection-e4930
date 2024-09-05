<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128585592/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4930)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[Program.cs](./CS/ConsoleApplication1/Program.cs) (VB: [Program.vb](./VB/ConsoleApplication1/Program.vb))**
* [Service1.svc.cs](./CS/WcfService1/Service1.svc.cs) (VB: [Service1.svc.vb](./VB/WcfService1/Service1.svc.vb))
* [Web.config](./CS/WcfService1/Web.config) (VB: [Web.config](./VB/WcfService1/Web.config))
<!-- default file list end -->
# How to connect to a remote data service instead of using a direct database connection


<p><strong>Scenario</strong></p>
<p>In this example, we will create a WCF <a href="http://help.devexpress.com/#CoreLibraries/clsDevExpressXpoDBIDataStoretopic"><u>IDataStore</u></a> service that will be used by our client (<strong>Console Application</strong>) as a data layer. Instead of the direct connection to the database, our client will connect to a remote service, which is way more secure and thus important in many enterprise scenarios as database connection settings are not exposed to the client.</p>
<p><strong><br> Steps to implement</strong></p>
<p><strong>1.</strong> Create a new <strong>WCF Service Application</strong> project and add references to the <strong>DevExpress.Data</strong> and <strong>DevExpress.Xpo</strong> assemblies and remove files with auto-generated interfaces for the service.</p>
<p><strong>2.</strong> Modify the service class as shown in the <em>Service1</em> file. This service initializes a connection provider and stores it in the static <em>DataStore </em>property, which is then used by the base <em>DataStoreService </em>class.</p>
<p><strong>3.</strong> Change some binding properties as shown in the example's<em> web.config</em> file. At this stage, the service part is ready to work and we need to implement a client to consume data from our data store service (for demonstration purposes, we will create a Console Application).</p>
<p><strong>4.</strong> Add the <strong>Console Application</strong> into the existing solution.</p>
<p><strong>5.</strong> Add a new code file for a <strong>Customer</strong> class using the <strong>DevExpress v1X.X ORM Persistent Object </strong>item template. See a code of <strong>Customer</strong> class in the <em>ConsoleApplication\Customer</em> code file.</p>
<p><strong>6.</strong> Pass the address of our service into the <a href="http://documentation.devexpress.com/#XPO/DevExpressXpoXpoDefault_GetDataLayertopic"><u>GetDataLayer</u></a> method of the <a href="http://documentation.devexpress.com/#XPO/clsDevExpressXpoXpoDefaulttopic"><u>XpoDefault</u></a> class. For this, modify the <strong>Main</strong> method of the <strong>Console Application</strong> as shown in the <em>ConsoleApplication\Program</em> code file. Please note that the port number in the connection string may be different. You can check it in the properties of the service project in the Solution Explorer:</p>
<p><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-connect-to-a-remote-data-service-instead-of-using-a-direct-database-connection-e4930/13.1.7+/media/3d4ab490-98e6-4cb4-acce-1cc6f70db881.png"></p>
<br>
<p>As a result, we will see the following output:</p>
<p><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-connect-to-a-remote-data-service-instead-of-using-a-direct-database-connection-e4930/13.1.7+/media/d85f8375-4b16-4e74-8843-301bd1cac92f.png"></p>
<p><strong>Important notes</strong><br> If you are using an XAF client, then in the simplest case, you can just set the <em>XafApplication.ConnectionString</em> to the address of your data store service (<a href="http://localhost:55777/Service1.svc">http://localhost:55777/Service1.svc</a>). Refer to the <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3155"><u>Connect an XAF Application to a Database Provider</u></a> help article for more details.<br><br></p>
<p><strong>Troubleshooting</strong><br>1. If WCF throws the "<em>Request Entity Too Large</em>" error, you can apply a standard solution from StackOverFlow: <a href="http://stackoverflow.com/questions/10122957/">http://stackoverflow.com/questions/10122957/</a><br><br>2. If WCF throws the "<em>The maximum string content length quota (8192) has been exceeded while reading XML data.</em>" error, you can extend bindings in the following manner as per <a href="http://stackoverflow.com/questions/6600057/the-maximum-string-content-length-quota-8192-has-been-exceeded-while-reading-x">http://stackoverflow.com/questions/6600057/the-maximum-string-content-length-quota-8192-has-been-exceeded-while-reading-x</a>:</p>


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


<p> </p>
<p><strong>See Also:<br> </strong><a href="https://www.devexpress.com/Support/Center/p/AK3911">How to use XPO with a Web Service</a><u><br> </u><a href="http://documentation.devexpress.com/#XPO/CustomDocument10018"><u>Transferring Data via WCF Services</u></a><u><br> </u><a href="https://www.devexpress.com/Support/Center/p/E4993">How to connect to a remote data service from a Silverlight application</a></p>
<p><a href="https://www.devexpress.com/Support/Center/p/E4932">How to create a data caching service that helps improve performance in distributed applications</a></p>
<p><a href="https://www.devexpress.com/Support/Center/p/E5072">How to implement a distributed object layer service working via WCF</a></p>
<p><a href="https://www.devexpress.com/Support/Center/p/E5137">How to connect to remote data store and configure WCF end point programmatically</a></p>
<p><a href="https://www.devexpress.com/Support/Center/p/E4932"> </a></p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XPO_how-to-connect-to-a-remote-data-service-instead-of-using-a-direct-database-connection-e4930&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XPO_how-to-connect-to-a-remote-data-service-instead-of-using-a-direct-database-connection-e4930&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
