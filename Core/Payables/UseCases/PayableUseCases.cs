/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Use cases Layer                         *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Use case interactor class               *
*  Type     : PayablesUseCases                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Use cases for payables management.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Payments.Payables.Adapters;

namespace Empiria.Payments.Payables.UseCases {

  /// <summary>Use cases for payables management.</summary>
  public class PayableUseCases : UseCase {

    #region Constructors and parsers

    protected PayableUseCases() {
      // no-op
    }

    static public PayableUseCases UseCaseInteractor() {
      return UseCase.CreateInstance<PayableUseCases>();
    }

    #endregion Constructors and parsers

    #region Use cases

    public PayableDto CreatePayable(PayableFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      PayableType payableType = PayableType.Parse(fields.PayableTypeId);

      var payable = new Payable(payableType, fields);

      payable.Save();

      return PayableMapper.Map(payable);
    }

    #endregion Use cases

  }  // class PayableUseCases

}  // namespace Empiria.Payments.Payables.UseCases
