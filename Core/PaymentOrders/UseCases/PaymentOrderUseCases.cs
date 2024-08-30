/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments  Management                       Component : Use cases Layer                         *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Use case interactor class               *
*  Type     : PaymentsUseCases                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Use cases for payments management.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Aspects;
using Empiria.Financial.Core;
using Empiria.Payments.Orders.Adapters;
using Empiria.Services;



namespace Empiria.Payments.Orders.UseCases
{

    /// <summary>Use cases for payments management.</summary>
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

    public PaymentOrderDto CancelPaymentOrder(string paymentOrderUID) {
      Assertion.Require(paymentOrderUID, nameof(paymentOrderUID));

      var order = PaymentOrder.Parse(paymentOrderUID);
      order.Cancel();

      return PaymentOrderMapper.Map(order);
    }


    public PaymentOrderDto AddPaymentOrder(PaymentOrderFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      var order = new PaymentOrder(fields);

      order.Save();

      return PaymentOrderMapper.Map(order);
    }


    public PaymentOrderDto GetPaymentOrder(string paymentOrderUID) {
      Assertion.Require(paymentOrderUID, nameof(paymentOrderUID));

      var order = PaymentOrder.Parse(paymentOrderUID);

      return PaymentOrderMapper.Map(order);
    }


    public PaymentOrderDto UpdatePaymentOrder(string uid, PaymentOrderFields fields) {
      Assertion.Require(fields, "fields");

      fields.EnsureValid();

      var order = PaymentOrder.Parse(uid);

      order.Update(fields);
      order.Save();

      return PaymentOrderMapper.Map(order);
    }


    public FixedList<NamedEntityDto> GetCurrencies() {
      var currencies  = Currency.GetList();

      return currencies.MapToNamedEntityList();
    }


    public FixedList<NamedEntityDto> GetPaymentOrderTypes() {
      var paymentOrderTypes = PaymentOrderType.GetList();

      return paymentOrderTypes.MapToNamedEntityList();
    }


    public FixedList<NamedEntityDto> GetPaymentMethods() {
      var paymentMethods = PaymentMethod.GetList();

      return paymentMethods.MapToNamedEntityList();
    }


    #endregion Use cases

  }  // class PaymentOrderUseCases

}  // namespace Empiria.Payments.Orders.UseCases
