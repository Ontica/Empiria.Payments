/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Information Holder                      *
*  Type     : PaymentOrder                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a payment order search.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using Empiria.Payments.Orders.Adapters;
using Empiria.Payments.Orders.Data;

namespace Empiria.Payments.Orders {

  /// <summary>Represents a payment order.</summary>
  internal class PaymentOrderSearcher {

    #region Constructors and parsers


    public PaymentOrderSearcher() {
      // Required by Empiria Framework.
    }


    #endregion Constructors and parsers

    #region Properties


    public FixedList<PaymentOrder> GetOrders(PaymentOrdersQuery query) {
      var paymentOrders = PaymentOrderData.GetPaymentOrders(query);

      return paymentOrders;
    }


    #endregion Properties

    #region Methods

    #endregion Methods
  } // class PaymentOrderSearcher


} // namespace Empiria.Payments.Orders
