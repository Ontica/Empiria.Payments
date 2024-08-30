/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Use cases Layer                         *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Use case interactor class               *
*  Type     : PaymentOrderUseCases                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Use cases for payment orders management.                                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Payments.Orders.Adapters;

namespace Empiria.Payments.Orders.UseCases {

  /// <summary>Use cases for payment orders management.</summary>
  public class PaymentOrderUseCases : UseCase {

    #region Constructors and parsers

    protected PaymentOrderUseCases() {
      // no-op
    }

    static public PaymentOrderUseCases UseCaseInteractor() {
      return UseCase.CreateInstance<PaymentOrderUseCases>();
    }

    #endregion Constructors and parsers

    #region Use cases

    public PaymentOrderDto CreatePaymentOrder(PaymentOrderFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      var order = new PaymentOrder(fields);

      order.Save();

      return PaymentOrderMapper.Map(order);
    }


    public void DeletePaymentOrder(string paymentOrderUID) {
      Assertion.Require(paymentOrderUID, nameof(paymentOrderUID));

      var order = PaymentOrder.Parse(paymentOrderUID);

      order.Delete();

      order.Save();
    }


    public PaymentOrderDto GetPaymentOrder(string paymentOrderUID) {
      Assertion.Require(paymentOrderUID, nameof(paymentOrderUID));

      var order = PaymentOrder.Parse(paymentOrderUID);

      return PaymentOrderMapper.Map(order);
    }


    public FixedList<PaymentOrderDescriptor> GetPaymentOrders(PaymentOrdersQuery query) {
      throw new System.NotImplementedException();
    }


    public PaymentOrderDto UpdatePaymentOrder(string uid, PaymentOrderFields fields) {
      Assertion.Require(fields, "fields");

      fields.EnsureValid();

      var order = PaymentOrder.Parse(uid);

      order.Update(fields);
      order.Save();

      return PaymentOrderMapper.Map(order);
    }

    #endregion Use cases

  }  // class PaymentOrderUseCases

}  // namespace Empiria.Payments.Orders.UseCases
