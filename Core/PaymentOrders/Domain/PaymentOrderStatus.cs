/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Enumeration Type                        *
*  Type     : PaymentOrderStatus                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Enumerates the status of a payment order.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Payments.Orders {

  /// <summary>Enumerates the status of a payment order.</summary>
  public enum PaymentOrderStatus {

    Pending = 'P',

    Received = 'R',

    Suspended = 'S',

    Deleted = 'X',

  }  // enum PaymentOrderStatus



  /// <summary>Extension methods for PaymentOrderStatus enumeration.</summary>
  static public class PaymentOrderStatusExtensions {

    static public string GetName(this PaymentOrderStatus status) {
      switch (status) {
        case PaymentOrderStatus.Pending:
          return "Pendiente";
        case PaymentOrderStatus.Received:
          return "Received";
        case PaymentOrderStatus.Suspended:
          return "Suspended";
        case PaymentOrderStatus.Deleted:
          return "Eliminada";
        default:
          throw Assertion.EnsureNoReachThisCode($"Unhandled payment order status {status}.");
      }
    }

  }  // class PaymentOrderStatusExtensions

}  // namespace Empiria.Payments.Orders
