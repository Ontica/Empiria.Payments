/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Use cases Layer                         *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Use case interactor class               *
*  Type     : CataloguesUseCases                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Use cases used to retrieve payments management system's catalogues.                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Financial.Core;

namespace Empiria.Payments.Orders.UseCases {

  /// <summary>Use cases used to retrieve payments management system's catalogues.</summary>
  public class CataloguesUseCases : UseCase {

    #region Constructors and parsers

    protected CataloguesUseCases() {
      // no-op
    }

    static public CataloguesUseCases UseCaseInteractor() {
      return UseCase.CreateInstance<CataloguesUseCases>();
    }

    #endregion Constructors and parsers

    #region Use cases

    public FixedList<NamedEntityDto> GetCurrencies() {
      var currencies = Currency.GetList();

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

  }  // class CataloguesUseCases

}  // namespace Empiria.Payments.Orders.UseCases
