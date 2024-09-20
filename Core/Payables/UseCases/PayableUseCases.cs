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
using Empiria.Budgeting;


using Empiria.Payments.Payables.Data;


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

      PayableType payableType = PayableType.Parse(fields.PayableTypeUID);

      var payable = new Payable(payableType, fields);

      payable.Save();

      return PayableMapper.Map(payable);
    }


    public FixedList<PayableItemDto> GetPayableItems(string payableUID) {
      Assertion.Require(payableUID, nameof(payableUID));

      Payable payable = Payable.Parse(payableUID);
      FixedList<PayableItem> payableItems = payable.GetItems();

      return PayableItemMapper.Map(payableItems);
    }

    public FixedList<NamedEntityDto> GetPayableTypes() {

      FixedList<PayableType> payableTypes = PayableType.GetList();

      return payableTypes.Select(x => new NamedEntityDto(x.UID, x.DisplayName))
      .ToFixedList();
    }


    public FixedList<PayableDescriptor> SearchPayables(PayablesQuery query) {
      Assertion.Require(query, nameof(query));

      query.EnsureIsValid();

      string filter = string.Empty;
      string sortBy = string.Empty;

      FixedList<Payable> payables = PayableData.GetPayables(filter, sortBy);

      return PayableMapper.MapToDescriptor(payables);
    }





    #endregion Use cases

  }  // class PayableUseCases

}  // namespace Empiria.Payments.Payables.UseCases
