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
    /// ProxyCreateTaxationItem
    /// </summary>
    [DataContract]
    public partial class ProxyCreateTaxationItem :  IEquatable<ProxyCreateTaxationItem>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyCreateTaxationItem" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ProxyCreateTaxationItem() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyCreateTaxationItem" /> class.
        /// </summary>
        /// <param name="AccountingCode"> The [Chart of Accounts](/CB_Billing/W_Billing_and_Payments_Settings/V_Configure_Accounting_Codes/D_Set_Up_Chart_of_Accounts) .</param>
        /// <param name="ExemptAmount"> The amount of taxes or VAT for which the customer has an exemption. **Character limit**: 16 **Values**: a decimal value  (required).</param>
        /// <param name="InvoiceItemId"> The ID of the specific invoice item that the taxation information applies to. **Character limit**: 32 **Values**: a valid [invoice item ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/InvoiceItem) .</param>
        /// <param name="Jurisdiction"> The jurisdiction that applies the tax or VAT. This value is typically a state, province, county, or city. **Character limit**: 32 **Values**: a string of 32 characterrs or fewer .</param>
        /// <param name="LocationCode"> The identifier for the location based on the value of the &#x60;TaxCode&#x60; field. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="Name"> The name of the tax rate, such as sales tax or GST. This name is displayed on invoices. **Character limit**: 128 **Values**: a string of 128 characters or fewer .</param>
        /// <param name="TaxAmount"> The amount of the tax applied to the charge. **Character limit**: 16 **Values**: a decimal value  (required).</param>
        /// <param name="TaxCode"> The tax code identifies which tax rules and tax rates to apply to a specific charge. **Character limit**: 32 **Values**: a string of 32 characters or fewer .</param>
        /// <param name="TaxCodeDescription"> The description for the tax code. **Character limit**: 255 **Values**: a string of 255 characters or fewer .</param>
        /// <param name="TaxDate"> The date that the tax is applied to the charge. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_and_dateTime_Format) .</param>
        /// <param name="TaxRate"> The tax rate applied to the charge. **Character limit**: 16 **Values**: a valid decimal value  (required).</param>
        /// <param name="TaxRateDescription"> The description of the tax rate. **Character limit**: 255 **Values**: a string of 255 characters or fewer .</param>
        /// <param name="TaxRateType"> The type of the tax rate applied to the charge. **Character limit**: 10 **Values**: &#x60;Percentage&#x60;, &#x60;FlatFee&#x60; .</param>
        public ProxyCreateTaxationItem(string AccountingCode = null, double? ExemptAmount = null, string InvoiceItemId = null, string Jurisdiction = null, string LocationCode = null, string Name = null, double? TaxAmount = null, string TaxCode = null, string TaxCodeDescription = null, DateTime? TaxDate = null, double? TaxRate = null, string TaxRateDescription = null, string TaxRateType = null)
        {
            // to ensure "ExemptAmount" is required (not null)
            if (ExemptAmount == null)
            {
                throw new InvalidDataException("ExemptAmount is a required property for ProxyCreateTaxationItem and cannot be null");
            }
            else
            {
                this.ExemptAmount = ExemptAmount;
            }
            // to ensure "TaxAmount" is required (not null)
            if (TaxAmount == null)
            {
                throw new InvalidDataException("TaxAmount is a required property for ProxyCreateTaxationItem and cannot be null");
            }
            else
            {
                this.TaxAmount = TaxAmount;
            }
            // to ensure "TaxRate" is required (not null)
            if (TaxRate == null)
            {
                throw new InvalidDataException("TaxRate is a required property for ProxyCreateTaxationItem and cannot be null");
            }
            else
            {
                this.TaxRate = TaxRate;
            }
            this.AccountingCode = AccountingCode;
            this.InvoiceItemId = InvoiceItemId;
            this.Jurisdiction = Jurisdiction;
            this.LocationCode = LocationCode;
            this.Name = Name;
            this.TaxCode = TaxCode;
            this.TaxCodeDescription = TaxCodeDescription;
            this.TaxDate = TaxDate;
            this.TaxRateDescription = TaxRateDescription;
            this.TaxRateType = TaxRateType;
        }
        
        /// <summary>
        ///  The [Chart of Accounts](/CB_Billing/W_Billing_and_Payments_Settings/V_Configure_Accounting_Codes/D_Set_Up_Chart_of_Accounts) 
        /// </summary>
        /// <value> The [Chart of Accounts](/CB_Billing/W_Billing_and_Payments_Settings/V_Configure_Accounting_Codes/D_Set_Up_Chart_of_Accounts) </value>
        [DataMember(Name="AccountingCode", EmitDefaultValue=false)]
        public string AccountingCode { get; set; }
        /// <summary>
        ///  The amount of taxes or VAT for which the customer has an exemption. **Character limit**: 16 **Values**: a decimal value 
        /// </summary>
        /// <value> The amount of taxes or VAT for which the customer has an exemption. **Character limit**: 16 **Values**: a decimal value </value>
        [DataMember(Name="ExemptAmount", EmitDefaultValue=false)]
        public double? ExemptAmount { get; set; }
        /// <summary>
        ///  The ID of the specific invoice item that the taxation information applies to. **Character limit**: 32 **Values**: a valid [invoice item ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/InvoiceItem) 
        /// </summary>
        /// <value> The ID of the specific invoice item that the taxation information applies to. **Character limit**: 32 **Values**: a valid [invoice item ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/InvoiceItem) </value>
        [DataMember(Name="InvoiceItemId", EmitDefaultValue=false)]
        public string InvoiceItemId { get; set; }
        /// <summary>
        ///  The jurisdiction that applies the tax or VAT. This value is typically a state, province, county, or city. **Character limit**: 32 **Values**: a string of 32 characterrs or fewer 
        /// </summary>
        /// <value> The jurisdiction that applies the tax or VAT. This value is typically a state, province, county, or city. **Character limit**: 32 **Values**: a string of 32 characterrs or fewer </value>
        [DataMember(Name="Jurisdiction", EmitDefaultValue=false)]
        public string Jurisdiction { get; set; }
        /// <summary>
        ///  The identifier for the location based on the value of the &#x60;TaxCode&#x60; field. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The identifier for the location based on the value of the &#x60;TaxCode&#x60; field. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="LocationCode", EmitDefaultValue=false)]
        public string LocationCode { get; set; }
        /// <summary>
        ///  The name of the tax rate, such as sales tax or GST. This name is displayed on invoices. **Character limit**: 128 **Values**: a string of 128 characters or fewer 
        /// </summary>
        /// <value> The name of the tax rate, such as sales tax or GST. This name is displayed on invoices. **Character limit**: 128 **Values**: a string of 128 characters or fewer </value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        ///  The amount of the tax applied to the charge. **Character limit**: 16 **Values**: a decimal value 
        /// </summary>
        /// <value> The amount of the tax applied to the charge. **Character limit**: 16 **Values**: a decimal value </value>
        [DataMember(Name="TaxAmount", EmitDefaultValue=false)]
        public double? TaxAmount { get; set; }
        /// <summary>
        ///  The tax code identifies which tax rules and tax rates to apply to a specific charge. **Character limit**: 32 **Values**: a string of 32 characters or fewer 
        /// </summary>
        /// <value> The tax code identifies which tax rules and tax rates to apply to a specific charge. **Character limit**: 32 **Values**: a string of 32 characters or fewer </value>
        [DataMember(Name="TaxCode", EmitDefaultValue=false)]
        public string TaxCode { get; set; }
        /// <summary>
        ///  The description for the tax code. **Character limit**: 255 **Values**: a string of 255 characters or fewer 
        /// </summary>
        /// <value> The description for the tax code. **Character limit**: 255 **Values**: a string of 255 characters or fewer </value>
        [DataMember(Name="TaxCodeDescription", EmitDefaultValue=false)]
        public string TaxCodeDescription { get; set; }
        /// <summary>
        ///  The date that the tax is applied to the charge. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_and_dateTime_Format) 
        /// </summary>
        /// <value> The date that the tax is applied to the charge. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_and_dateTime_Format) </value>
        [DataMember(Name="TaxDate", EmitDefaultValue=false)]
        public DateTime? TaxDate { get; set; }
        /// <summary>
        ///  The tax rate applied to the charge. **Character limit**: 16 **Values**: a valid decimal value 
        /// </summary>
        /// <value> The tax rate applied to the charge. **Character limit**: 16 **Values**: a valid decimal value </value>
        [DataMember(Name="TaxRate", EmitDefaultValue=false)]
        public double? TaxRate { get; set; }
        /// <summary>
        ///  The description of the tax rate. **Character limit**: 255 **Values**: a string of 255 characters or fewer 
        /// </summary>
        /// <value> The description of the tax rate. **Character limit**: 255 **Values**: a string of 255 characters or fewer </value>
        [DataMember(Name="TaxRateDescription", EmitDefaultValue=false)]
        public string TaxRateDescription { get; set; }
        /// <summary>
        ///  The type of the tax rate applied to the charge. **Character limit**: 10 **Values**: &#x60;Percentage&#x60;, &#x60;FlatFee&#x60; 
        /// </summary>
        /// <value> The type of the tax rate applied to the charge. **Character limit**: 10 **Values**: &#x60;Percentage&#x60;, &#x60;FlatFee&#x60; </value>
        [DataMember(Name="TaxRateType", EmitDefaultValue=false)]
        public string TaxRateType { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProxyCreateTaxationItem {\n");
            sb.Append("  AccountingCode: ").Append(AccountingCode).Append("\n");
            sb.Append("  ExemptAmount: ").Append(ExemptAmount).Append("\n");
            sb.Append("  InvoiceItemId: ").Append(InvoiceItemId).Append("\n");
            sb.Append("  Jurisdiction: ").Append(Jurisdiction).Append("\n");
            sb.Append("  LocationCode: ").Append(LocationCode).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  TaxAmount: ").Append(TaxAmount).Append("\n");
            sb.Append("  TaxCode: ").Append(TaxCode).Append("\n");
            sb.Append("  TaxCodeDescription: ").Append(TaxCodeDescription).Append("\n");
            sb.Append("  TaxDate: ").Append(TaxDate).Append("\n");
            sb.Append("  TaxRate: ").Append(TaxRate).Append("\n");
            sb.Append("  TaxRateDescription: ").Append(TaxRateDescription).Append("\n");
            sb.Append("  TaxRateType: ").Append(TaxRateType).Append("\n");
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
            return this.Equals(obj as ProxyCreateTaxationItem);
        }

        /// <summary>
        /// Returns true if ProxyCreateTaxationItem instances are equal
        /// </summary>
        /// <param name="other">Instance of ProxyCreateTaxationItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyCreateTaxationItem other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AccountingCode == other.AccountingCode ||
                    this.AccountingCode != null &&
                    this.AccountingCode.Equals(other.AccountingCode)
                ) && 
                (
                    this.ExemptAmount == other.ExemptAmount ||
                    this.ExemptAmount != null &&
                    this.ExemptAmount.Equals(other.ExemptAmount)
                ) && 
                (
                    this.InvoiceItemId == other.InvoiceItemId ||
                    this.InvoiceItemId != null &&
                    this.InvoiceItemId.Equals(other.InvoiceItemId)
                ) && 
                (
                    this.Jurisdiction == other.Jurisdiction ||
                    this.Jurisdiction != null &&
                    this.Jurisdiction.Equals(other.Jurisdiction)
                ) && 
                (
                    this.LocationCode == other.LocationCode ||
                    this.LocationCode != null &&
                    this.LocationCode.Equals(other.LocationCode)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.TaxAmount == other.TaxAmount ||
                    this.TaxAmount != null &&
                    this.TaxAmount.Equals(other.TaxAmount)
                ) && 
                (
                    this.TaxCode == other.TaxCode ||
                    this.TaxCode != null &&
                    this.TaxCode.Equals(other.TaxCode)
                ) && 
                (
                    this.TaxCodeDescription == other.TaxCodeDescription ||
                    this.TaxCodeDescription != null &&
                    this.TaxCodeDescription.Equals(other.TaxCodeDescription)
                ) && 
                (
                    this.TaxDate == other.TaxDate ||
                    this.TaxDate != null &&
                    this.TaxDate.Equals(other.TaxDate)
                ) && 
                (
                    this.TaxRate == other.TaxRate ||
                    this.TaxRate != null &&
                    this.TaxRate.Equals(other.TaxRate)
                ) && 
                (
                    this.TaxRateDescription == other.TaxRateDescription ||
                    this.TaxRateDescription != null &&
                    this.TaxRateDescription.Equals(other.TaxRateDescription)
                ) && 
                (
                    this.TaxRateType == other.TaxRateType ||
                    this.TaxRateType != null &&
                    this.TaxRateType.Equals(other.TaxRateType)
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
                if (this.AccountingCode != null)
                    hash = hash * 59 + this.AccountingCode.GetHashCode();
                if (this.ExemptAmount != null)
                    hash = hash * 59 + this.ExemptAmount.GetHashCode();
                if (this.InvoiceItemId != null)
                    hash = hash * 59 + this.InvoiceItemId.GetHashCode();
                if (this.Jurisdiction != null)
                    hash = hash * 59 + this.Jurisdiction.GetHashCode();
                if (this.LocationCode != null)
                    hash = hash * 59 + this.LocationCode.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.TaxAmount != null)
                    hash = hash * 59 + this.TaxAmount.GetHashCode();
                if (this.TaxCode != null)
                    hash = hash * 59 + this.TaxCode.GetHashCode();
                if (this.TaxCodeDescription != null)
                    hash = hash * 59 + this.TaxCodeDescription.GetHashCode();
                if (this.TaxDate != null)
                    hash = hash * 59 + this.TaxDate.GetHashCode();
                if (this.TaxRate != null)
                    hash = hash * 59 + this.TaxRate.GetHashCode();
                if (this.TaxRateDescription != null)
                    hash = hash * 59 + this.TaxRateDescription.GetHashCode();
                if (this.TaxRateType != null)
                    hash = hash * 59 + this.TaxRateType.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
