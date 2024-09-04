/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Mapper                                  *
*  Type     : PaymentOrderMapper                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data mapping services for search payment order.                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using System.Collections.Generic;

using Empiria.FinancialAccounting.Core;

namespace Empiria.Payments.Orders.Adapters {

  /// <summary>Provides data mapping services for search payment order.</summary>
  static internal class PaymentOrderSearcherMapper {

    #region Public methods

    static internal PaymentOrderDescriptor Map(PaymentOrdersQuery query, FixedList<PaymentOrder> paymentOrders) {
      return new PaymentOrderDescriptor {
        Query = query,
        Columns = GetDataColumns(),
        Entries = MapEntries(paymentOrders)
      };
            
    }


    #endregion Public methods

    #region Private methods


    static private FixedList<DataTableColumn> GetDataColumns() {
      List<DataTableColumn> columns = new List<DataTableColumn>();

      columns.Add(new DataTableColumn("paymentOrderNo", "No. Orden", "text-link"));
      columns.Add(new DataTableColumn("payTo", "Proveedor", "text"));
      columns.Add(new DataTableColumn("payable", "Contrato", "text"));
      columns.Add(new DataTableColumn("total", "Total", "decimal"));
      columns.Add(new DataTableColumn("currency", "Moneda", "text"));
      columns.Add(new DataTableColumn("requestedBy", "Solicitado por", "text"));
      columns.Add(new DataTableColumn("requestedDate", "Fecha de solicitud", "date"));
      columns.Add(new DataTableColumn("dueTime", "Fecha de pago", "date"));
      columns.Add(new DataTableColumn("status", "Estatus", "text-tag"));

      return columns.ToFixedList();
    }


    static private FixedList<PaymentOrderDescriptorDto>  MapEntries(FixedList<PaymentOrder> paymentOrders) {
      return paymentOrders.Select(x => Map(x))
                      .ToFixedList();
    }


    static private PaymentOrderDescriptorDto Map(PaymentOrder paymentOrder) {
      return new PaymentOrderDescriptorDto {
        UID = paymentOrder.UID,
        PaymentOrderNo = paymentOrder.PaymentOrderNo,
        PayTo = paymentOrder.PayTo.Name,
        Payable = "Objeto Payable",
        Total = paymentOrder.Total,
        Currency = paymentOrder.Currency.Name,
        RequestedBy = paymentOrder.RequestedBy.Name,
        RequestedDate = paymentOrder.RequestedTime,
        DueTime = paymentOrder.DueTime,
        Status = paymentOrder.Status
      };
    }


    #endregion Private methods


  }  // class ContractMapper

}  // namespace Empiria.Payments.Contracts.Adapters
