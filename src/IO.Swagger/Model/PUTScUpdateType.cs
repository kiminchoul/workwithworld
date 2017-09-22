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
    /// PUTScUpdateType
    /// </summary>
    [DataContract]
    public partial class PUTScUpdateType :  IEquatable<PUTScUpdateType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PUTScUpdateType" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PUTScUpdateType() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PUTScUpdateType" /> class.
        /// </summary>
        /// <param name="BillingPeriodAlignment">Aligns charges within the same subscription if multiple charges begin on different dates.  Values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60;  Available for the following charge types:  * Recurring * Usage-based .</param>
        /// <param name="CustomFieldC">Any custom fields defined for this object. .</param>
        /// <param name="Description">Description of the charge. .</param>
        /// <param name="IncludedUnits">Specifies the number of units in the base set of units for this charge. Must be &gt;&#x3D;0.  Available for the following charge types for the Overage charge model:  * &#x60;Recurring&#x60; * &#x60;Usage-based&#x60; .</param>
        /// <param name="OveragePrice">Price for units over the allowed amount.   Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based .</param>
        /// <param name="Price">Price for units in the subscription rate plan.  Supports all charge types for the Flat Fee and Per Unit charge models .</param>
        /// <param name="PriceChangeOption">Applies an automatic price change when a termed subscription is renewed. The Billing Admin setting **Enable Automatic Price Change When Subscriptions are Renewed?** must be set to Yes to use this field.  See [Define Default Subscription Settings](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings) for more information on setting this option.  Values:  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60;  Available for the following charge types:  * Recurring * Usage-based  Not available for the Fixed-Amount Discount charge model. .</param>
        /// <param name="PriceIncreasePercentage">Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Required if you set the &#x60;PriceChangeOption&#x60; field to &#x60;SpecificPercentageValue&#x60;.  Decimal between &#x60;-100&#x60; and &#x60;100&#x60;.  Available for the following charge types:  * Recurring * Usage-based  Not available for the Fixed-Amount Discount charge model. .</param>
        /// <param name="Quantity">Quantity of units; must be greater than zero. .</param>
        /// <param name="RatePlanChargeId">ID of a rate-plan charge for this subscription.  (required).</param>
        /// <param name="Tiers">Container for Volume, Tiered or Tiered with Overage charge models. Supports the following charge types:  * One-time * Recurring * Usage-based .</param>
        /// <param name="TriggerDate">Specifies when to start billing the customer for the charge. Required if the &#x60;triggerEvent&#x60; field is set to USD.  &#x60;triggerDate&#x60; cannot be updated for the following using the REST update subscription call:  * One-time charge type * Discount-Fixed Amount charge model * Discount-Percentage charge model .</param>
        /// <param name="TriggerEvent">Specifies when to start billing the customer for the charge.  Values:  * &#x60;UCE&#x60; * &#x60;USA&#x60; * &#x60;UCA&#x60; * &#x60;USD&#x60;  This is the date when charge changes in the REST request become effective.  &#x60;triggerEvent&#x60; cannot be updated for the following using the REST update subscription call:  * One-time charge type * Discount-Fixed Amount charge model * Discount-Percentage charge model .</param>
        public PUTScUpdateType(string BillingPeriodAlignment = null, string CustomFieldC = null, string Description = null, string IncludedUnits = null, string OveragePrice = null, string Price = null, string PriceChangeOption = null, string PriceIncreasePercentage = null, string Quantity = null, string RatePlanChargeId = null, List<POSTTierType> Tiers = null, DateTime? TriggerDate = null, string TriggerEvent = null, string UserPrice__c = null, string EffectivePriceTotal__c = null, string UserPriceTotal__c = null)
        {
            /**
            // to ensure "RatePlanChargeId" is required (not null)
            if (RatePlanChargeId == null)
            {
                throw new InvalidDataException("RatePlanChargeId is a required property for PUTScUpdateType and cannot be null");
            }
            else
            {
                this.RatePlanChargeId = RatePlanChargeId;
            }
            */
            this.RatePlanChargeId = RatePlanChargeId;

            this.BillingPeriodAlignment = BillingPeriodAlignment;
            this.CustomFieldC = CustomFieldC;
            this.Description = Description;
            this.IncludedUnits = IncludedUnits;
            this.OveragePrice = OveragePrice;
            this.Price = Price;
            this.PriceChangeOption = PriceChangeOption;
            this.PriceIncreasePercentage = PriceIncreasePercentage;
            this.Quantity = Quantity;
            this.Tiers = Tiers;
            this.TriggerDate = TriggerDate;
            this.TriggerEvent = TriggerEvent;
            this.UserPrice__c = UserPrice__c;  //�J�X�^������
            this.EffectivePriceTotal__c = EffectivePriceTotal__c;  //�J�X�^������
            this.UserPriceTotal__c = UserPriceTotal__c;  //�J�X�^������
        }
        
        /// <summary>
        /// Aligns charges within the same subscription if multiple charges begin on different dates.  Values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60;  Available for the following charge types:  * Recurring * Usage-based 
        /// </summary>
        /// <value>Aligns charges within the same subscription if multiple charges begin on different dates.  Values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60;  Available for the following charge types:  * Recurring * Usage-based </value>
        [DataMember(Name="billingPeriodAlignment", EmitDefaultValue=false)]
        public string BillingPeriodAlignment { get; set; }
        /// <summary>
        /// Any custom fields defined for this object. 
        /// </summary>
        /// <value>Any custom fields defined for this object. </value>
        [DataMember(Name="customField__c", EmitDefaultValue=false)]
        public string CustomFieldC { get; set; }
        /// <summary>
        /// Description of the charge. 
        /// </summary>
        /// <value>Description of the charge. </value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// Specifies the number of units in the base set of units for this charge. Must be &gt;&#x3D;0.  Available for the following charge types for the Overage charge model:  * &#x60;Recurring&#x60; * &#x60;Usage-based&#x60; 
        /// </summary>
        /// <value>Specifies the number of units in the base set of units for this charge. Must be &gt;&#x3D;0.  Available for the following charge types for the Overage charge model:  * &#x60;Recurring&#x60; * &#x60;Usage-based&#x60; </value>
        [DataMember(Name="includedUnits", EmitDefaultValue=false)]
        public string IncludedUnits { get; set; }
        /// <summary>
        /// Price for units over the allowed amount.   Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based 
        /// </summary>
        /// <value>Price for units over the allowed amount.   Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based </value>
        [DataMember(Name="overagePrice", EmitDefaultValue=false)]
        public string OveragePrice { get; set; }
        /// <summary>
        /// Price for units in the subscription rate plan.  Supports all charge types for the Flat Fee and Per Unit charge models 
        /// </summary>
        /// <value>Price for units in the subscription rate plan.  Supports all charge types for the Flat Fee and Per Unit charge models </value>
        [DataMember(Name="price", EmitDefaultValue=false)]
        public string Price { get; set; }
        /// <summary>
        /// Applies an automatic price change when a termed subscription is renewed. The Billing Admin setting **Enable Automatic Price Change When Subscriptions are Renewed?** must be set to Yes to use this field.  See [Define Default Subscription Settings](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings) for more information on setting this option.  Values:  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60;  Available for the following charge types:  * Recurring * Usage-based  Not available for the Fixed-Amount Discount charge model. 
        /// </summary>
        /// <value>Applies an automatic price change when a termed subscription is renewed. The Billing Admin setting **Enable Automatic Price Change When Subscriptions are Renewed?** must be set to Yes to use this field.  See [Define Default Subscription Settings](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings) for more information on setting this option.  Values:  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60;  Available for the following charge types:  * Recurring * Usage-based  Not available for the Fixed-Amount Discount charge model. </value>
        [DataMember(Name="priceChangeOption", EmitDefaultValue=false)]
        public string PriceChangeOption { get; set; }
        /// <summary>
        /// Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Required if you set the &#x60;PriceChangeOption&#x60; field to &#x60;SpecificPercentageValue&#x60;.  Decimal between &#x60;-100&#x60; and &#x60;100&#x60;.  Available for the following charge types:  * Recurring * Usage-based  Not available for the Fixed-Amount Discount charge model. 
        /// </summary>
        /// <value>Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Required if you set the &#x60;PriceChangeOption&#x60; field to &#x60;SpecificPercentageValue&#x60;.  Decimal between &#x60;-100&#x60; and &#x60;100&#x60;.  Available for the following charge types:  * Recurring * Usage-based  Not available for the Fixed-Amount Discount charge model. </value>
        [DataMember(Name="priceIncreasePercentage", EmitDefaultValue=false)]
        public string PriceIncreasePercentage { get; set; }
        /// <summary>
        /// Quantity of units; must be greater than zero. 
        /// </summary>
        /// <value>Quantity of units; must be greater than zero. </value>
        [DataMember(Name="quantity", EmitDefaultValue=false)]
        public string Quantity { get; set; }
        /// <summary>
        /// ID of a rate-plan charge for this subscription. 
        /// </summary>
        /// <value>ID of a rate-plan charge for this subscription. </value>
        [DataMember(Name="ratePlanChargeId", EmitDefaultValue=false)]
        public string RatePlanChargeId { get; set; }
        /// <summary>
        /// Container for Volume, Tiered or Tiered with Overage charge models. Supports the following charge types:  * One-time * Recurring * Usage-based 
        /// </summary>
        /// <value>Container for Volume, Tiered or Tiered with Overage charge models. Supports the following charge types:  * One-time * Recurring * Usage-based </value>
        [DataMember(Name="tiers", EmitDefaultValue=false)]
        public List<POSTTierType> Tiers { get; set; }
        /// <summary>
        /// Specifies when to start billing the customer for the charge. Required if the &#x60;triggerEvent&#x60; field is set to USD.  &#x60;triggerDate&#x60; cannot be updated for the following using the REST update subscription call:  * One-time charge type * Discount-Fixed Amount charge model * Discount-Percentage charge model 
        /// </summary>
        /// <value>Specifies when to start billing the customer for the charge. Required if the &#x60;triggerEvent&#x60; field is set to USD.  &#x60;triggerDate&#x60; cannot be updated for the following using the REST update subscription call:  * One-time charge type * Discount-Fixed Amount charge model * Discount-Percentage charge model </value>
        [DataMember(Name="triggerDate", EmitDefaultValue=false)]
        public DateTime? TriggerDate { get; set; }
        /// <summary>
        /// Specifies when to start billing the customer for the charge.  Values:  * &#x60;UCE&#x60; * &#x60;USA&#x60; * &#x60;UCA&#x60; * &#x60;USD&#x60;  This is the date when charge changes in the REST request become effective.  &#x60;triggerEvent&#x60; cannot be updated for the following using the REST update subscription call:  * One-time charge type * Discount-Fixed Amount charge model * Discount-Percentage charge model 
        /// </summary>
        /// <value>Specifies when to start billing the customer for the charge.  Values:  * &#x60;UCE&#x60; * &#x60;USA&#x60; * &#x60;UCA&#x60; * &#x60;USD&#x60;  This is the date when charge changes in the REST request become effective.  &#x60;triggerEvent&#x60; cannot be updated for the following using the REST update subscription call:  * One-time charge type * Discount-Fixed Amount charge model * Discount-Percentage charge model </value>
        [DataMember(Name="triggerEvent", EmitDefaultValue=false)]
        public string TriggerEvent { get; set; }

        [DataMember(Name = "UserPrice__c", EmitDefaultValue = false)]
        public string UserPrice__c { get; set; }
        [DataMember(Name = "EffectivePriceTotal__c", EmitDefaultValue = false)]
        public string EffectivePriceTotal__c { get; set; }
        [DataMember(Name = "UserPriceTotal__c", EmitDefaultValue = false)]
        public string UserPriceTotal__c { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PUTScUpdateType {\n");
            sb.Append("  BillingPeriodAlignment: ").Append(BillingPeriodAlignment).Append("\n");
            sb.Append("  CustomFieldC: ").Append(CustomFieldC).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  IncludedUnits: ").Append(IncludedUnits).Append("\n");
            sb.Append("  OveragePrice: ").Append(OveragePrice).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  PriceChangeOption: ").Append(PriceChangeOption).Append("\n");
            sb.Append("  PriceIncreasePercentage: ").Append(PriceIncreasePercentage).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  RatePlanChargeId: ").Append(RatePlanChargeId).Append("\n");
            sb.Append("  Tiers: ").Append(Tiers).Append("\n");
            sb.Append("  TriggerDate: ").Append(TriggerDate).Append("\n");
            sb.Append("  TriggerEvent: ").Append(TriggerEvent).Append("\n");
            sb.Append("  UserPrice__c: ").Append(UserPrice__c).Append("\n");
            sb.Append("  EffectivePriceTotal__c: ").Append(EffectivePriceTotal__c).Append("\n");
            sb.Append("  UserPriceTotal__c: ").Append(UserPriceTotal__c).Append("\n");
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
            return this.Equals(obj as PUTScUpdateType);
        }

        /// <summary>
        /// Returns true if PUTScUpdateType instances are equal
        /// </summary>
        /// <param name="other">Instance of PUTScUpdateType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PUTScUpdateType other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.BillingPeriodAlignment == other.BillingPeriodAlignment ||
                    this.BillingPeriodAlignment != null &&
                    this.BillingPeriodAlignment.Equals(other.BillingPeriodAlignment)
                ) && 
                (
                    this.CustomFieldC == other.CustomFieldC ||
                    this.CustomFieldC != null &&
                    this.CustomFieldC.Equals(other.CustomFieldC)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.IncludedUnits == other.IncludedUnits ||
                    this.IncludedUnits != null &&
                    this.IncludedUnits.Equals(other.IncludedUnits)
                ) && 
                (
                    this.OveragePrice == other.OveragePrice ||
                    this.OveragePrice != null &&
                    this.OveragePrice.Equals(other.OveragePrice)
                ) && 
                (
                    this.Price == other.Price ||
                    this.Price != null &&
                    this.Price.Equals(other.Price)
                ) && 
                (
                    this.PriceChangeOption == other.PriceChangeOption ||
                    this.PriceChangeOption != null &&
                    this.PriceChangeOption.Equals(other.PriceChangeOption)
                ) && 
                (
                    this.PriceIncreasePercentage == other.PriceIncreasePercentage ||
                    this.PriceIncreasePercentage != null &&
                    this.PriceIncreasePercentage.Equals(other.PriceIncreasePercentage)
                ) && 
                (
                    this.Quantity == other.Quantity ||
                    this.Quantity != null &&
                    this.Quantity.Equals(other.Quantity)
                ) && 
                (
                    this.RatePlanChargeId == other.RatePlanChargeId ||
                    this.RatePlanChargeId != null &&
                    this.RatePlanChargeId.Equals(other.RatePlanChargeId)
                ) && 
                (
                    this.Tiers == other.Tiers ||
                    this.Tiers != null &&
                    this.Tiers.SequenceEqual(other.Tiers)
                ) && 
                (
                    this.TriggerDate == other.TriggerDate ||
                    this.TriggerDate != null &&
                    this.TriggerDate.Equals(other.TriggerDate)
                ) && 
                (
                    this.TriggerEvent == other.TriggerEvent ||
                    this.TriggerEvent != null &&
                    this.TriggerEvent.Equals(other.TriggerEvent)
                ) &&
                (
                    this.UserPrice__c == other.UserPrice__c ||
                    this.UserPrice__c != null &&
                    this.UserPrice__c.Equals(other.UserPrice__c)
                ) &&
                (
                    this.EffectivePriceTotal__c == other.EffectivePriceTotal__c ||
                    this.EffectivePriceTotal__c != null &&
                    this.EffectivePriceTotal__c.Equals(other.EffectivePriceTotal__c)
                ) &&
                (
                    this.UserPriceTotal__c == other.UserPriceTotal__c ||
                    this.UserPriceTotal__c != null &&
                    this.UserPriceTotal__c.Equals(other.UserPriceTotal__c)
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
                if (this.BillingPeriodAlignment != null)
                    hash = hash * 59 + this.BillingPeriodAlignment.GetHashCode();
                if (this.CustomFieldC != null)
                    hash = hash * 59 + this.CustomFieldC.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.IncludedUnits != null)
                    hash = hash * 59 + this.IncludedUnits.GetHashCode();
                if (this.OveragePrice != null)
                    hash = hash * 59 + this.OveragePrice.GetHashCode();
                if (this.Price != null)
                    hash = hash * 59 + this.Price.GetHashCode();
                if (this.PriceChangeOption != null)
                    hash = hash * 59 + this.PriceChangeOption.GetHashCode();
                if (this.PriceIncreasePercentage != null)
                    hash = hash * 59 + this.PriceIncreasePercentage.GetHashCode();
                if (this.Quantity != null)
                    hash = hash * 59 + this.Quantity.GetHashCode();
                if (this.RatePlanChargeId != null)
                    hash = hash * 59 + this.RatePlanChargeId.GetHashCode();
                if (this.Tiers != null)
                    hash = hash * 59 + this.Tiers.GetHashCode();
                if (this.TriggerDate != null)
                    hash = hash * 59 + this.TriggerDate.GetHashCode();
                if (this.TriggerEvent != null)
                    hash = hash * 59 + this.TriggerEvent.GetHashCode();
                if (this.UserPrice__c != null)
                    hash = hash * 59 + this.UserPrice__c.GetHashCode();
                if (this.EffectivePriceTotal__c != null)
                    hash = hash * 59 + this.EffectivePriceTotal__c.GetHashCode();
                if (this.UserPriceTotal__c != null)
                    hash = hash * 59 + this.UserPriceTotal__c.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}