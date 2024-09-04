/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Test cases                              *
*  Assembly : Empiria.Payments.Core.Tests.dll            Pattern   : Use cases tests                         *
*  Type     : CataloguesUseCasesTests                    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Test cases for payment orders catalogues use cases.                                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using Xunit;

using Empiria.Payments.Orders.UseCases;

namespace Empiria.Tests.Payments.Orders {

  /// <summary>Test cases for payment orders catalogues use cases.</summary>
  public class CataloguesUseCasesTests {

    #region Use cases initialization

    private readonly CataloguesUseCases _usecases;

    public CataloguesUseCasesTests() {
      TestsCommonMethods.Authenticate();

      _usecases = CataloguesUseCases.UseCaseInteractor();
    }

    ~CataloguesUseCasesTests() {
      _usecases.Dispose();
    }

    #endregion Use cases initialization

    #region Facts

    [Fact]
    public void Should_GetPaymentMethods() {

      var sut = _usecases.GetPaymentMethods();

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_GetPaymentOrderTypes() {

      var sut = _usecases.GetPaymentOrderTypes();

      Assert.NotNull(sut);
    }

    #endregion Facts

  }  // class CataloguesUseCasesTests

}  // namespace Empiria.Tests.Payments.Orders
