using System;
using System.Linq;
using System.Reflection;
using AAngelov.Utilities.Test.Validators.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AAngelov.Utilities.Test.Validators
{
    /// <summary>
    /// Generic object validator.
    /// </summary>
    /// <typeparam name="K"> The new Validator type.</typeparam>
    /// <typeparam name="T"> Every object with public properties.</typeparam>
    public class PropertiesValidator<K, T> where T : new() where K : new()
    {
       private static K instance;

       /// <summary>
       /// Gets the instance.
       /// </summary>
       /// <value>
       /// The instance.
       /// </value>
        public static K Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new K();
                }
                return instance;
            }
        }

        /// <summary>
        /// Validates the specified expected object.
        /// </summary>
        /// <param name="expectedObject"> The expected object. </param>
        /// <param name="realObject"> The real object. </param>
        /// <param name="propertiesNotToCompare"> The properties not to compare.</param>
        public void Validate(T expectedObject, T realObject, params string[] propertiesNotToCompare)
        {
            PropertyInfo [] properties = realObject.GetType().GetProperties();
            foreach ( PropertyInfo currentRealProperty in properties)
            {
                if (!propertiesNotToCompare.Contains(currentRealProperty.Name))
                {
                    PropertyInfo currentExpectedProperty = expectedObject.GetType().GetProperty(currentRealProperty.Name);
                    string exceptionMessage =
                        string.Format( "The property {0} of class {1} was not as expected.", currentRealProperty.Name, currentRealProperty.DeclaringType.Name);

                    if (currentRealProperty.PropertyType != typeof( DateTime) && currentRealProperty.PropertyType != typeof (DateTime ?))
                    {
                        Assert .AreEqual(currentExpectedProperty.GetValue(expectedObject, null), currentRealProperty.GetValue(realObject, null ), exceptionMessage);
                    }
                    else
                    {
                           DateTimeAssert.Validate(
                            currentExpectedProperty.GetValue(expectedObject, null)  as DateTime?,
                            currentRealProperty.GetValue(realObject, null) as DateTime ?,
                            DateTimeDeltaType .Minutes,
                            5);
                    }
                }
            }
        }
    }
}



////using System;
////using Microsoft.VisualStudio.TestTools.UnitTesting;
////using Telerik.Website.DataSetup.Core.Invoices.DataContracts;
////using WebDivision.Tests.Core.Utilities;

////namespace WebDivision.UITests.Licensing.Core.ShoppingCart.Validators
////{
////    /// <summary>
////    /// Contains methods that validate invoice client entities.
////    /// </summary>
////    public class InvoiceClientValidator : EntitiesValidator <InvoiceClientValidator , InvoiceClient >
////    {
////        /// <summary>
////        /// Validates the specified expected invoice.
////        /// </summary>
////        /// <param name="expectedInvoiceClient"> The expected invoice client.</param>
////        /// <param name="realInvoiceClient"> The real invoice client. </param>
////        public void Validate( InvoiceClient expectedInvoiceClient, InvoiceClientrealInvoiceClient)
////        {
////            //// TODO: Anton(09.05.2014): Should be enabled when the required method in TDES is created.
////            base.Validate(expectedInvoiceClient, realInvoiceClient, "CountryId" ,"InvoiceClientId" );
////            Assert.IsNotNull(realInvoiceClient.CountryId);
////            Assert.IsNotNull(realInvoiceClient.InvoiceClientId);        
////        }
////    }

}
