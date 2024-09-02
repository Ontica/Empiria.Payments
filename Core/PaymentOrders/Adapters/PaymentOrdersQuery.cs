/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Input Data Transfer Object              *
*  Type     : PaymentOrdersQuery                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Input DTO used to search payment orders.                                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

namespace Empiria.Payments.Orders.Adapters {

  /// <summary>Input DTO used to search payment orders.</summary>
  public class PaymentOrdersQuery {

    public string Keywords {
      get; set;
    } = string.Empty;

    public DateTime FromDate {
      get; set;
    } = new DateTime(2020, 1, 1);

    public DateTime ToDate {
      get; set;
    } = new DateTime(2049, 12, 31);


  }  // class PaymentOrdersQuery

}  // namespace Empiria.Payments.Orders.Adapters
