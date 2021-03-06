/* 
 * Zuora API Reference
 *
 *  # Introduction  Welcome to the reference for the Zuora REST API!  <a href=\"http://en.wikipedia.org/wiki/REST_API\" target=\"_blank\">REST</a> is a web-service protocol that lends itself to rapid development by using everyday HTTP and JSON technology.  The Zuora REST API provides a broad set of operations and resources that:  * Enable Web Storefront integration between your websites. * Support self-service subscriber sign-ups and account management. * Process revenue schedules through custom revenue rule models.  ## Endpoints  The Zuora REST services are provided via the following endpoints.  | Service                 | Base URL for REST Endpoints                                                                                                                                         | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Production REST service | https://rest.zuora.com/v1                                                                                                                                           | | Sandbox REST service    | https://rest.apisandbox.zuora.com/v1                                                                                                                                |  The production service provides access to your live user data. The sandbox environment is a good place to test your code without affecting real-world data. To use it, you must be provisioned with a sandbox tenant - your Zuora representative can help with this if needed.  ## Accessing the API  If you have a Zuora tenant, you already have access the the API.  If you don't have a Zuora tenant, go to <a href=\"https://www.zuora.com/resource/zuora-test-drive\" target=\"_blank\">https://www.zuora.com/resource/zuora-test-drive</a> and sign up for a trial tenant. The tenant comes with seed data, such as a sample product catalog.   We recommend that you <a href=\"https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users/Create_an_API_User\" target=\"_blank\">create an API user</a> specifically for making API calls. Don't log in to the Zuora UI with this account. Logging in to the UI enables a security feature that periodically expires the account's password, which may eventually cause authentication failures with the API. Note that a user role does not have write access to Zuora REST services unless it has the API Write Access permission as described in those instructions.   # Authentication  There are three ways to authenticate:  * Use an authorization cookie. The cookie authorizes the user to make calls to the REST API for the duration specified in  **Administration > Security Policies > Session timeout**. The cookie expiration time is reset with this duration after every call to the REST API. To obtain a cookie, call the REST  `connections` resource with the following API user information:     *   ID     *   password     *   entity Id or entity name (Only for [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity \"Multi-entity\"). See \"Entity Id and Entity Name\" below for more information.)  *   Include the following parameters in the request header, which re-authenticates the user with each request:     *   `apiAccessKeyId`     *   `apiSecretAccessKey`     *   `entityId` or `entityName` (Only for [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity \"Multi-entity\"). See \"Entity Id and Entity Name\" below for more information.) *   For CORS-enabled APIs only: Include a 'single-use' token in the request header, which re-authenticates the user with each request. See below for more details.   ## Entity Id and Entity Name  The `entityId` and `entityName`  parameters are only used for  [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity).  The  `entityId` parameter specifies the Id of the entity that you want to access. The `entityName` parameter specifies the [name of the entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/B_Introduction_to_Entity_and_Entity_Hierarchy#Name_and_Display_Name \"Introduction to Entity and Entity Hierarchy\") that you want to access. Note that you must have permission to access the entity. You can get the entity Id and entity name through the REST GET Entities call.  You can specify either the  `entityId` or `entityName` parameter in the authentication to access and view an entity.  *   If both `entityId` and `entityName` are specified in the authentication, an error occurs.  *   If neither  `entityId` nor  `entityName` is specified in the authentication, you will log in to the entity in which your user account is created.   See [API User Authentication](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/A_Overview_of_Multi-entity#API_User_Authentication \"Zuora Multi-entity\") for more information.  ## Token Authentication for CORS-Enabled APIs  The CORS mechanism enables REST API calls to Zuora to be made directly from your customer's browser, with all credit card and security information transmitted directly to Zuora. This minimizes your PCI compliance burden, allows you to implement advanced validation on your payment forms, and makes your payment forms look just like any other part of your website.  For security reasons, instead of using cookies, an API request via CORS uses **tokens** for authentication.  The token method of authentication is only designed for use with requests that must originate from your customer's browser; **it should not be considered a replacement to the existing cookie authentication** mechanism.  See [Zuora CORS REST ](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics/G_CORS_REST \"Zuora CORS REST\")for details on how CORS works and how you can begin to implement customer calls to the Zuora REST APIs. See  [HMAC Signatures](/BC_Developers/REST_API/B_REST_API_reference/HMAC_Signatures \"HMAC Signatures\") for details on the HMAC method that returns the authentication token.    # Requests and Responses   ## Request IDs  As a general rule, when asked to supply a \"key\" for an account or subscription (accountKey, account-key, subscriptionKey, subscription-key), you can provide either the actual ID or the number of the entity.  ## HTTP Request Body  Most of the parameters and data accompanying your requests will be contained in the body of the HTTP request.  The Zuora REST API accepts JSON in the HTTP request body.  No other data format (e.g., XML) is supported.   ## Testing a Request  Use a third party client, such as Postman or Advanced REST Client, to test the Zuora REST API.  You can test the Zuora REST API from the Zuora sandbox or  production service. If connecting to the production service, bear in mind that you are working with your live production data, not sample data or test data.  ## Testing with Credit Cards  Sooner or later it will probably be necessary to test some transactions that involve credit cards. For suggestions on how to handle this, see [Going Live With Your Payment Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards \"C_Zuora_User_Guides/A_Billing_and_Payments/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards\").       ## Error Handling  Responses and error codes are detailed in [Responses and errors](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics/3_Responses_and_errors \"Responses and errors\").    # Pagination  When retrieving information (using GET methods), the optional `pageSize` query parameter sets the maximum number of rows to return in a response. The maximum is `40`; larger values are treated as `40`. If this value is empty or invalid, `pageSize` typically defaults to `10`.  The default value for the maximum number of rows retrieved can be overridden at the method level.  If more rows are available, the response will include a `nextPage` element, which contains a URL for requesting the next page.  If this value is not provided, no more rows are available. No \"previous page\" element is explicitly provided; to support backward paging, use the previous call.  ## Array Size  For data items that are not paginated, the REST API supports arrays of up to 300 rows.  Thus, for instance, repeated pagination can retrieve thousands of customer accounts, but within any account an array of no more than 300 rate plans is returned.   # API Versions  The Zuora REST API is in version control. Versioning ensures that Zuora REST API changes are backward compatible. Zuora uses a major and minor version nomenclature to manage changes. By specifying a version in a REST request, you can get expected responses regardless of future changes to the API.   ## Major Version  The major version number of the REST API appears in the REST URL. Currently, Zuora only supports the **v1** major version. For example,  `POST https://rest.zuora.com/v1/subscriptions` .   ## Minor Version  Zuora uses minor versions for the REST API to control small changes. For example, a field in a REST method is deprecated and a new field is used to replace it.   Some fields in the REST methods are supported as of minor versions. If a field is not noted with a minor version, this field is available for all minor versions. If a field is noted with a minor version, this field is in version control. You must specify the supported minor version in the request header to process without an error.   If a field is in version control, it is either with a minimum minor version or a maximum minor version, or both of them. You can only use this field with the minor version between the minimum and the maximum minor versions. For example, the  `invoiceCollect` field in the POST Subscription method is in version control and its maximum minor version is 189.0. You can only use this field with the minor version 189.0 or earlier.  The supported minor versions are not serial, see [Zuora REST API Minor Version History](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics/Zuora_REST_API_Minor_Version_History \"Zuora REST API Minor Version History\") for the fields and their supported minor versions. In our REST API documentation, if a field or feature requires a minor version number, we note that in the field description.  You only need to specify the version number when you use the fields require a minor version. To specify the minor version, set the `zuora-version` parameter to the minor version number in the request header for the request call. For example, the `collect` field is in 196.0 minor version. If you want to use this field for the POST Subscription method, set the  `zuora-version` parameter to `196.0` in the request header. The `zuora-version` parameter is case sensitive.   For all the REST API fields, by default, if the minor version is not specified in the request header, Zuora will use the minimum minor version of the REST API to avoid breaking your integration.     # Zuora Object Model The following diagram presents a high-level view of the key Zuora objects. Click the image to open it in a new tab to resize it.  <a href=\"https://www.zuora.com/wp-content/uploads/2016/10/ZuoraERD-compressor-1.jpeg\" target=\"_blank\"><img src=\"https://www.zuora.com/wp-content/uploads/2016/10/ZuoraERD-compressor-1.jpeg\" alt=\"Zuora Object Model Diagram\"></a> 
 *
 * OpenAPI spec version: 0.0.1
 * Contact: docs@zuora.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace IO.Swagger.Model
{
    /// <summary>
    /// POSTSubscriptionPreviewType
    /// </summary>
    [DataContract]
    public partial class POSTSubscriptionPreviewType :  IEquatable<POSTSubscriptionPreviewType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSTSubscriptionPreviewType" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected POSTSubscriptionPreviewType() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="POSTSubscriptionPreviewType" /> class.
        /// </summary>
        /// <param name="OpportunityCloseDateQT">The closing date of the Opportunity. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. .</param>
        /// <param name="OpportunityNameQT">The unique identifier of the Opportunity. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. .</param>
        /// <param name="QuoteBusinessTypeQT">The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal, or Churn. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. .</param>
        /// <param name="QuoteNumberQT">The unique identifier of the Quote. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. .</param>
        /// <param name="QuoteTypeQT">The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. .</param>
        /// <param name="AccountKey"> Customer account number or ID.  You must specify the account information either in this field or in the &#x60;previewAccountInfo&#x60; field with the following conditions:           * If you already have a customer account, specify the account number or ID in this field. * If you do not have a customer account, provide account information in the &#x60;previewAccountInfo&#x60; field. .</param>
        /// <param name="ContractEffectiveDate">Effective contract date for this subscription, as yyyy-mm-dd.  (required).</param>
        /// <param name="CustomerAcceptanceDate">The date on which the services or products within a subscription have been accepted by the customer, as yyyy-mm-dd.  Default value is dependent on the value of other fields. See **Notes** section for more details. .</param>
        /// <param name="IncludeExistingDraftInvoiceItems">Specifies whether to include draft invoice items in subscription previews.  Values:   * &#x60;true&#x60; (default). Includes draft invoice items in amendment previews.  * &#x60;false&#x60;. Excludes draft invoice items in amendment previews. .</param>
        /// <param name="InitialTerm">Duration of the first term of the subscription, in whole months. Default is &#x60;0&#x60;. If &#x60;termType&#x60; is &#x60;TERMED&#x60;, then this field is required, and the value must be greater than &#x60;0&#x60;. If &#x60;termType&#x60; is &#x60;EVERGREEN&#x60;, this field is ignored. .</param>
        /// <param name="InitialTermPeriodType">The period type of the initial term.   Supported values are:  * &#x60;Month&#x60; * &#x60;Year&#x60; * &#x60;Day&#x60; * &#x60;Week&#x60; .</param>
        /// <param name="InvoiceOwnerAccountKey">Invoice owner account number or ID.  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). .</param>
        /// <param name="InvoiceTargetDate">Date through which to calculate charges if an invoice is generated, as yyyy-mm-dd. Default is current date. .</param>
        /// <param name="Notes">String of up to 500 characters..</param>
        /// <param name="PreviewAccountInfo">PreviewAccountInfo.</param>
        /// <param name="PreviewType">The type of preview you will receive. The possible values are &#x60;invoiceItem&#x60;, &#x60;chargeMetrics&#x60;, or &#x60;InvoiceItemChargeMetrics&#x60;. The default is &#x60;invoiceItem&#x60;. .</param>
        /// <param name="ServiceActivationDate">The date on which the services or products within a subscription have been activated and access has been provided to the customer, as yyyy-mm-dd.  Default value is dependent on the value of other fields. See **Notes** section for more details. .</param>
        /// <param name="SubscribeToRatePlans">Container for one or more rate plans for this subscription.  (required).</param>
        /// <param name="TermStartDate">The date on which the subscription term begins, as yyyy-mm-dd. If this is a renewal subscription, this date is different from the subscription start date. .</param>
        /// <param name="TermType">Possible values are: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60;.  (required).</param>
        public POSTSubscriptionPreviewType(string OpportunityCloseDateQT = null, string OpportunityNameQT = null, string QuoteBusinessTypeQT = null, string QuoteNumberQT = null, string QuoteTypeQT = null, string AccountKey = null, DateTime? ContractEffectiveDate = null, DateTime? CustomerAcceptanceDate = null, bool? IncludeExistingDraftInvoiceItems = null, long? InitialTerm = null, string InitialTermPeriodType = null, string InvoiceOwnerAccountKey = null, DateTime? InvoiceTargetDate = null, string Notes = null, POSTSubscriptionPreviewTypePreviewAccountInfo PreviewAccountInfo = null, string PreviewType = null, DateTime? ServiceActivationDate = null, List<POSTSrpCreateType> SubscribeToRatePlans = null, DateTime? TermStartDate = null, string TermType = null)
        {
            // to ensure "ContractEffectiveDate" is required (not null)
            if (ContractEffectiveDate == null)
            {
                throw new InvalidDataException("ContractEffectiveDate is a required property for POSTSubscriptionPreviewType and cannot be null");
            }
            else
            {
                this.ContractEffectiveDate = ContractEffectiveDate;
            }
            // to ensure "SubscribeToRatePlans" is required (not null)
            if (SubscribeToRatePlans == null)
            {
                throw new InvalidDataException("SubscribeToRatePlans is a required property for POSTSubscriptionPreviewType and cannot be null");
            }
            else
            {
                this.SubscribeToRatePlans = SubscribeToRatePlans;
            }
            // to ensure "TermType" is required (not null)
            if (TermType == null)
            {
                throw new InvalidDataException("TermType is a required property for POSTSubscriptionPreviewType and cannot be null");
            }
            else
            {
                this.TermType = TermType;
            }
            this.OpportunityCloseDateQT = OpportunityCloseDateQT;
            this.OpportunityNameQT = OpportunityNameQT;
            this.QuoteBusinessTypeQT = QuoteBusinessTypeQT;
            this.QuoteNumberQT = QuoteNumberQT;
            this.QuoteTypeQT = QuoteTypeQT;
            this.AccountKey = AccountKey;
            this.CustomerAcceptanceDate = CustomerAcceptanceDate;
            this.IncludeExistingDraftInvoiceItems = IncludeExistingDraftInvoiceItems;
            this.InitialTerm = InitialTerm;
            this.InitialTermPeriodType = InitialTermPeriodType;
            this.InvoiceOwnerAccountKey = InvoiceOwnerAccountKey;
            this.InvoiceTargetDate = InvoiceTargetDate;
            this.Notes = Notes;
            this.PreviewAccountInfo = PreviewAccountInfo;
            this.PreviewType = PreviewType;
            this.ServiceActivationDate = ServiceActivationDate;
            this.TermStartDate = TermStartDate;
        }
        
        /// <summary>
        /// The closing date of the Opportunity. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. 
        /// </summary>
        /// <value>The closing date of the Opportunity. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. </value>
        [DataMember(Name="OpportunityCloseDate_QT", EmitDefaultValue=false)]
        public string OpportunityCloseDateQT { get; set; }
        /// <summary>
        /// The unique identifier of the Opportunity. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. 
        /// </summary>
        /// <value>The unique identifier of the Opportunity. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. </value>
        [DataMember(Name="OpportunityName_QT", EmitDefaultValue=false)]
        public string OpportunityNameQT { get; set; }
        /// <summary>
        /// The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal, or Churn. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. 
        /// </summary>
        /// <value>The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal, or Churn. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. </value>
        [DataMember(Name="QuoteBusinessType_QT", EmitDefaultValue=false)]
        public string QuoteBusinessTypeQT { get; set; }
        /// <summary>
        /// The unique identifier of the Quote. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. 
        /// </summary>
        /// <value>The unique identifier of the Quote. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. </value>
        [DataMember(Name="QuoteNumber_QT", EmitDefaultValue=false)]
        public string QuoteNumberQT { get; set; }
        /// <summary>
        /// The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. 
        /// </summary>
        /// <value>The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel. This field is populated when the subscription originates from Zuora Quotes.  This field is used only for reporting subscription metrics.   See [Subscription Data Source](https://knowledgecenter.zuora.com/CD_Reporting/Data_Exports/Z_Data_Source_Reference/Subscription_Data_Source) for more information. </value>
        [DataMember(Name="QuoteType_QT", EmitDefaultValue=false)]
        public string QuoteTypeQT { get; set; }
        /// <summary>
        ///  Customer account number or ID.  You must specify the account information either in this field or in the &#x60;previewAccountInfo&#x60; field with the following conditions:           * If you already have a customer account, specify the account number or ID in this field. * If you do not have a customer account, provide account information in the &#x60;previewAccountInfo&#x60; field. 
        /// </summary>
        /// <value> Customer account number or ID.  You must specify the account information either in this field or in the &#x60;previewAccountInfo&#x60; field with the following conditions:           * If you already have a customer account, specify the account number or ID in this field. * If you do not have a customer account, provide account information in the &#x60;previewAccountInfo&#x60; field. </value>
        [DataMember(Name="accountKey", EmitDefaultValue=false)]
        public string AccountKey { get; set; }
        /// <summary>
        /// Effective contract date for this subscription, as yyyy-mm-dd. 
        /// </summary>
        /// <value>Effective contract date for this subscription, as yyyy-mm-dd. </value>
        [DataMember(Name="contractEffectiveDate", EmitDefaultValue=false)]
        public DateTime? ContractEffectiveDate { get; set; }
        /// <summary>
        /// The date on which the services or products within a subscription have been accepted by the customer, as yyyy-mm-dd.  Default value is dependent on the value of other fields. See **Notes** section for more details. 
        /// </summary>
        /// <value>The date on which the services or products within a subscription have been accepted by the customer, as yyyy-mm-dd.  Default value is dependent on the value of other fields. See **Notes** section for more details. </value>
        [DataMember(Name="customerAcceptanceDate", EmitDefaultValue=false)]
        public DateTime? CustomerAcceptanceDate { get; set; }
        /// <summary>
        /// Specifies whether to include draft invoice items in subscription previews.  Values:   * &#x60;true&#x60; (default). Includes draft invoice items in amendment previews.  * &#x60;false&#x60;. Excludes draft invoice items in amendment previews. 
        /// </summary>
        /// <value>Specifies whether to include draft invoice items in subscription previews.  Values:   * &#x60;true&#x60; (default). Includes draft invoice items in amendment previews.  * &#x60;false&#x60;. Excludes draft invoice items in amendment previews. </value>
        [DataMember(Name="includeExistingDraftInvoiceItems", EmitDefaultValue=false)]
        public bool? IncludeExistingDraftInvoiceItems { get; set; }
        /// <summary>
        /// Duration of the first term of the subscription, in whole months. Default is &#x60;0&#x60;. If &#x60;termType&#x60; is &#x60;TERMED&#x60;, then this field is required, and the value must be greater than &#x60;0&#x60;. If &#x60;termType&#x60; is &#x60;EVERGREEN&#x60;, this field is ignored. 
        /// </summary>
        /// <value>Duration of the first term of the subscription, in whole months. Default is &#x60;0&#x60;. If &#x60;termType&#x60; is &#x60;TERMED&#x60;, then this field is required, and the value must be greater than &#x60;0&#x60;. If &#x60;termType&#x60; is &#x60;EVERGREEN&#x60;, this field is ignored. </value>
        [DataMember(Name="initialTerm", EmitDefaultValue=false)]
        public long? InitialTerm { get; set; }
        /// <summary>
        /// The period type of the initial term.   Supported values are:  * &#x60;Month&#x60; * &#x60;Year&#x60; * &#x60;Day&#x60; * &#x60;Week&#x60; 
        /// </summary>
        /// <value>The period type of the initial term.   Supported values are:  * &#x60;Month&#x60; * &#x60;Year&#x60; * &#x60;Day&#x60; * &#x60;Week&#x60; </value>
        [DataMember(Name="initialTermPeriodType", EmitDefaultValue=false)]
        public string InitialTermPeriodType { get; set; }
        /// <summary>
        /// Invoice owner account number or ID.  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). 
        /// </summary>
        /// <value>Invoice owner account number or ID.  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). </value>
        [DataMember(Name="invoiceOwnerAccountKey", EmitDefaultValue=false)]
        public string InvoiceOwnerAccountKey { get; set; }
        /// <summary>
        /// Date through which to calculate charges if an invoice is generated, as yyyy-mm-dd. Default is current date. 
        /// </summary>
        /// <value>Date through which to calculate charges if an invoice is generated, as yyyy-mm-dd. Default is current date. </value>
        [DataMember(Name="invoiceTargetDate", EmitDefaultValue=false)]
        public DateTime? InvoiceTargetDate { get; set; }
        /// <summary>
        /// String of up to 500 characters.
        /// </summary>
        /// <value>String of up to 500 characters.</value>
        [DataMember(Name="notes", EmitDefaultValue=false)]
        public string Notes { get; set; }
        /// <summary>
        /// Gets or Sets PreviewAccountInfo
        /// </summary>
        [DataMember(Name="previewAccountInfo", EmitDefaultValue=false)]
        public POSTSubscriptionPreviewTypePreviewAccountInfo PreviewAccountInfo { get; set; }
        /// <summary>
        /// The type of preview you will receive. The possible values are &#x60;invoiceItem&#x60;, &#x60;chargeMetrics&#x60;, or &#x60;InvoiceItemChargeMetrics&#x60;. The default is &#x60;invoiceItem&#x60;. 
        /// </summary>
        /// <value>The type of preview you will receive. The possible values are &#x60;invoiceItem&#x60;, &#x60;chargeMetrics&#x60;, or &#x60;InvoiceItemChargeMetrics&#x60;. The default is &#x60;invoiceItem&#x60;. </value>
        [DataMember(Name="previewType", EmitDefaultValue=false)]
        public string PreviewType { get; set; }
        /// <summary>
        /// The date on which the services or products within a subscription have been activated and access has been provided to the customer, as yyyy-mm-dd.  Default value is dependent on the value of other fields. See **Notes** section for more details. 
        /// </summary>
        /// <value>The date on which the services or products within a subscription have been activated and access has been provided to the customer, as yyyy-mm-dd.  Default value is dependent on the value of other fields. See **Notes** section for more details. </value>
        [DataMember(Name="serviceActivationDate", EmitDefaultValue=false)]
        public DateTime? ServiceActivationDate { get; set; }
        /// <summary>
        /// Container for one or more rate plans for this subscription. 
        /// </summary>
        /// <value>Container for one or more rate plans for this subscription. </value>
        [DataMember(Name="subscribeToRatePlans", EmitDefaultValue=false)]
        public List<POSTSrpCreateType> SubscribeToRatePlans { get; set; }
        /// <summary>
        /// The date on which the subscription term begins, as yyyy-mm-dd. If this is a renewal subscription, this date is different from the subscription start date. 
        /// </summary>
        /// <value>The date on which the subscription term begins, as yyyy-mm-dd. If this is a renewal subscription, this date is different from the subscription start date. </value>
        [DataMember(Name="termStartDate", EmitDefaultValue=false)]
        public DateTime? TermStartDate { get; set; }
        /// <summary>
        /// Possible values are: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60;. 
        /// </summary>
        /// <value>Possible values are: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60;. </value>
        [DataMember(Name="termType", EmitDefaultValue=false)]
        public string TermType { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class POSTSubscriptionPreviewType {\n");
            sb.Append("  OpportunityCloseDateQT: ").Append(OpportunityCloseDateQT).Append("\n");
            sb.Append("  OpportunityNameQT: ").Append(OpportunityNameQT).Append("\n");
            sb.Append("  QuoteBusinessTypeQT: ").Append(QuoteBusinessTypeQT).Append("\n");
            sb.Append("  QuoteNumberQT: ").Append(QuoteNumberQT).Append("\n");
            sb.Append("  QuoteTypeQT: ").Append(QuoteTypeQT).Append("\n");
            sb.Append("  AccountKey: ").Append(AccountKey).Append("\n");
            sb.Append("  ContractEffectiveDate: ").Append(ContractEffectiveDate).Append("\n");
            sb.Append("  CustomerAcceptanceDate: ").Append(CustomerAcceptanceDate).Append("\n");
            sb.Append("  IncludeExistingDraftInvoiceItems: ").Append(IncludeExistingDraftInvoiceItems).Append("\n");
            sb.Append("  InitialTerm: ").Append(InitialTerm).Append("\n");
            sb.Append("  InitialTermPeriodType: ").Append(InitialTermPeriodType).Append("\n");
            sb.Append("  InvoiceOwnerAccountKey: ").Append(InvoiceOwnerAccountKey).Append("\n");
            sb.Append("  InvoiceTargetDate: ").Append(InvoiceTargetDate).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  PreviewAccountInfo: ").Append(PreviewAccountInfo).Append("\n");
            sb.Append("  PreviewType: ").Append(PreviewType).Append("\n");
            sb.Append("  ServiceActivationDate: ").Append(ServiceActivationDate).Append("\n");
            sb.Append("  SubscribeToRatePlans: ").Append(SubscribeToRatePlans).Append("\n");
            sb.Append("  TermStartDate: ").Append(TermStartDate).Append("\n");
            sb.Append("  TermType: ").Append(TermType).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as POSTSubscriptionPreviewType);
        }

        /// <summary>
        /// Returns true if POSTSubscriptionPreviewType instances are equal
        /// </summary>
        /// <param name="other">Instance of POSTSubscriptionPreviewType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(POSTSubscriptionPreviewType other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.OpportunityCloseDateQT == other.OpportunityCloseDateQT ||
                    this.OpportunityCloseDateQT != null &&
                    this.OpportunityCloseDateQT.Equals(other.OpportunityCloseDateQT)
                ) && 
                (
                    this.OpportunityNameQT == other.OpportunityNameQT ||
                    this.OpportunityNameQT != null &&
                    this.OpportunityNameQT.Equals(other.OpportunityNameQT)
                ) && 
                (
                    this.QuoteBusinessTypeQT == other.QuoteBusinessTypeQT ||
                    this.QuoteBusinessTypeQT != null &&
                    this.QuoteBusinessTypeQT.Equals(other.QuoteBusinessTypeQT)
                ) && 
                (
                    this.QuoteNumberQT == other.QuoteNumberQT ||
                    this.QuoteNumberQT != null &&
                    this.QuoteNumberQT.Equals(other.QuoteNumberQT)
                ) && 
                (
                    this.QuoteTypeQT == other.QuoteTypeQT ||
                    this.QuoteTypeQT != null &&
                    this.QuoteTypeQT.Equals(other.QuoteTypeQT)
                ) && 
                (
                    this.AccountKey == other.AccountKey ||
                    this.AccountKey != null &&
                    this.AccountKey.Equals(other.AccountKey)
                ) && 
                (
                    this.ContractEffectiveDate == other.ContractEffectiveDate ||
                    this.ContractEffectiveDate != null &&
                    this.ContractEffectiveDate.Equals(other.ContractEffectiveDate)
                ) && 
                (
                    this.CustomerAcceptanceDate == other.CustomerAcceptanceDate ||
                    this.CustomerAcceptanceDate != null &&
                    this.CustomerAcceptanceDate.Equals(other.CustomerAcceptanceDate)
                ) && 
                (
                    this.IncludeExistingDraftInvoiceItems == other.IncludeExistingDraftInvoiceItems ||
                    this.IncludeExistingDraftInvoiceItems != null &&
                    this.IncludeExistingDraftInvoiceItems.Equals(other.IncludeExistingDraftInvoiceItems)
                ) && 
                (
                    this.InitialTerm == other.InitialTerm ||
                    this.InitialTerm != null &&
                    this.InitialTerm.Equals(other.InitialTerm)
                ) && 
                (
                    this.InitialTermPeriodType == other.InitialTermPeriodType ||
                    this.InitialTermPeriodType != null &&
                    this.InitialTermPeriodType.Equals(other.InitialTermPeriodType)
                ) && 
                (
                    this.InvoiceOwnerAccountKey == other.InvoiceOwnerAccountKey ||
                    this.InvoiceOwnerAccountKey != null &&
                    this.InvoiceOwnerAccountKey.Equals(other.InvoiceOwnerAccountKey)
                ) && 
                (
                    this.InvoiceTargetDate == other.InvoiceTargetDate ||
                    this.InvoiceTargetDate != null &&
                    this.InvoiceTargetDate.Equals(other.InvoiceTargetDate)
                ) && 
                (
                    this.Notes == other.Notes ||
                    this.Notes != null &&
                    this.Notes.Equals(other.Notes)
                ) && 
                (
                    this.PreviewAccountInfo == other.PreviewAccountInfo ||
                    this.PreviewAccountInfo != null &&
                    this.PreviewAccountInfo.Equals(other.PreviewAccountInfo)
                ) && 
                (
                    this.PreviewType == other.PreviewType ||
                    this.PreviewType != null &&
                    this.PreviewType.Equals(other.PreviewType)
                ) && 
                (
                    this.ServiceActivationDate == other.ServiceActivationDate ||
                    this.ServiceActivationDate != null &&
                    this.ServiceActivationDate.Equals(other.ServiceActivationDate)
                ) && 
                (
                    this.SubscribeToRatePlans == other.SubscribeToRatePlans ||
                    this.SubscribeToRatePlans != null &&
                    this.SubscribeToRatePlans.SequenceEqual(other.SubscribeToRatePlans)
                ) && 
                (
                    this.TermStartDate == other.TermStartDate ||
                    this.TermStartDate != null &&
                    this.TermStartDate.Equals(other.TermStartDate)
                ) && 
                (
                    this.TermType == other.TermType ||
                    this.TermType != null &&
                    this.TermType.Equals(other.TermType)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.OpportunityCloseDateQT != null)
                    hash = hash * 59 + this.OpportunityCloseDateQT.GetHashCode();
                if (this.OpportunityNameQT != null)
                    hash = hash * 59 + this.OpportunityNameQT.GetHashCode();
                if (this.QuoteBusinessTypeQT != null)
                    hash = hash * 59 + this.QuoteBusinessTypeQT.GetHashCode();
                if (this.QuoteNumberQT != null)
                    hash = hash * 59 + this.QuoteNumberQT.GetHashCode();
                if (this.QuoteTypeQT != null)
                    hash = hash * 59 + this.QuoteTypeQT.GetHashCode();
                if (this.AccountKey != null)
                    hash = hash * 59 + this.AccountKey.GetHashCode();
                if (this.ContractEffectiveDate != null)
                    hash = hash * 59 + this.ContractEffectiveDate.GetHashCode();
                if (this.CustomerAcceptanceDate != null)
                    hash = hash * 59 + this.CustomerAcceptanceDate.GetHashCode();
                if (this.IncludeExistingDraftInvoiceItems != null)
                    hash = hash * 59 + this.IncludeExistingDraftInvoiceItems.GetHashCode();
                if (this.InitialTerm != null)
                    hash = hash * 59 + this.InitialTerm.GetHashCode();
                if (this.InitialTermPeriodType != null)
                    hash = hash * 59 + this.InitialTermPeriodType.GetHashCode();
                if (this.InvoiceOwnerAccountKey != null)
                    hash = hash * 59 + this.InvoiceOwnerAccountKey.GetHashCode();
                if (this.InvoiceTargetDate != null)
                    hash = hash * 59 + this.InvoiceTargetDate.GetHashCode();
                if (this.Notes != null)
                    hash = hash * 59 + this.Notes.GetHashCode();
                if (this.PreviewAccountInfo != null)
                    hash = hash * 59 + this.PreviewAccountInfo.GetHashCode();
                if (this.PreviewType != null)
                    hash = hash * 59 + this.PreviewType.GetHashCode();
                if (this.ServiceActivationDate != null)
                    hash = hash * 59 + this.ServiceActivationDate.GetHashCode();
                if (this.SubscribeToRatePlans != null)
                    hash = hash * 59 + this.SubscribeToRatePlans.GetHashCode();
                if (this.TermStartDate != null)
                    hash = hash * 59 + this.TermStartDate.GetHashCode();
                if (this.TermType != null)
                    hash = hash * 59 + this.TermType.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
