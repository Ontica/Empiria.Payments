/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Managem ent                       Component : Data Layer                              *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Data service                            *
*  Type     : PaymentOrderData                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data read and write methods for payments instances.                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Data;
using Empiria.Payments.Orders.Adapters;

namespace Empiria.Payments.Orders.Data {

  /// <summary>Provides data read and write methods for contract instances.</summary>
  static internal class PaymentOrderData {

    #region Methods


    static internal FixedList<PaymentOrder> GetPaymentOrders(PaymentOrdersQuery query) {

      string keywordsFilter = string.Empty;
      var toDate = query.ToDate.ToString("dd-MM-yyyy");
      var fromDate = query.FromDate.ToString("dd-MM-yyyy");

      char status = 'A';

      if (query.Keywords != string.Empty) {
        keywordsFilter = $" {SearchExpression.ParseAndLikeKeywords("PYM_ORDER_KEYWORDS", query.Keywords)} AND ";
      }

      var sql = $"SELECT * FROM PYM_ORDERS WHERE {keywordsFilter} (PYM_ORDER_DUETIME >={DataCommonMethods.FormatSqlDbDateTime(query.FromDate)}) AND " +
        $" (PYM_ORDER_DUETIME < {DataCommonMethods.FormatSqlDbDateTime(query.ToDate.AddDays(1))} ) AND " +
        $" (PYM_ORDER_STATUS = '{status}') ";

      var dataOperation = DataOperation.Parse(sql);

      return DataReader.GetFixedList<PaymentOrder>(dataOperation);
    }


    static internal void WritePaymentOrder(PaymentOrder o, string extensionData) {
      var op = DataOperation.Parse("write_PYM_Order",
                     o.Id, o.UID, o.PaymentOrderType.Id, o.PaymentOrderNo, o.PayTo.Id,
                     -1, o.PaymentMethod.Id, o.Currency.Id, -1, o.Notes,o.RequestedDate,
                     extensionData, o.Total, o.DueTime, o.Keywords,
                     o.RequestedBy.Id, o.PostedBy.Id, o.PostingTime, (char) o.Status);

      DataWriter.Execute(op);
    }


    #endregion Methods

  }  // class ContractData

}  // namespace Empiria.Payments.Contracts.Data
