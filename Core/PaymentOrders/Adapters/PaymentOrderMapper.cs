﻿/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Mapper                                  *
*  Type     : PaymentOrderMapper                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data mapping services for payment order and related types.                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Payments.Orders.Adapters {

  /// <summary>Provides data mapping services for payment order and related types.</summary>
  static internal class PaymentOrderMapper {

    static internal FixedList<PaymentOrderDto> Map(FixedList<PaymentOrder> paymentOrders) {
      return paymentOrders.Select(x => Map(x))
                      .ToFixedList();
    }


    static internal PaymentOrderDto Map(PaymentOrder paymentOrder) {
      return new PaymentOrderDto {
        UID = paymentOrder.UID,
        PayTo = paymentOrder.PayTo.Name,
        RequestedBy = paymentOrder.RequestedBy.Name,
        RequestedDate = paymentOrder.RequestedTime,
        Notes = paymentOrder.Notes,
        Total = paymentOrder.Total,
        Status = new NamedEntityDto(paymentOrder.Status.ToString(),
                                    paymentOrder.Status.GetName()),
      };
    }

  }  // class ContractMapper

}  // namespace Empiria.Payments.Contracts.Adapters
