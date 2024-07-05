/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Use cases Layer                         *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Use case interactor class               *
*  Type     : ContractUseCases                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Use cases for contract management.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Payments.Orders.Adapters;
using Empiria.Services;



namespace Empiria.Payments.Orders.UseCases
{

    /// <summary>Use cases for contract management.</summary>
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
      order.Delete();

      return PaymentOrderMapper.Map(order);
    }


    public PaymentOrderDto AddPaymentOrder(PaymentOrderFields fields) {
      Assertion.Require(fields, nameof(fields));

      //fields.EnsureValid();

      var order = new PaymentOrder(fields);

      order.Save();

      return PaymentOrderMapper.Map(order);
    }


    public PaymentOrderDto GetPaymentOrder(string paymentOrderUID) {
      Assertion.Require(paymentOrderUID, nameof(paymentOrderUID));

      var order = PaymentOrder.Parse(paymentOrderUID);

      return PaymentOrderMapper.Map(order);
    }


    public FixedList<NamedEntityDto> GetPaymentOrderTypes() {
      var paymentOrderTypes = PaymentOrderType.GetList();

      return paymentOrderTypes.MapToNamedEntityList();
    }


    
    


    //public FixedList<ContractDto> SearchContracts(ContractQuery query) {
    //  Assertion.Require(query, nameof(query));

    //  string condition = query.GetConditionClause();
    //  string orderBy = query.GetOrderByClause();

    //  FixedList<Contract> contracts = ContractData.SearchContracts(condition, orderBy);

    //  var contracts = new FixedList<PaymentOrder>();

    //  return ContractMapper.Map(contracts);
    //}

    #endregion Use cases

  }  // class ContractUseCases

}  // namespace Empiria.Payments.Contracts.UseCases
