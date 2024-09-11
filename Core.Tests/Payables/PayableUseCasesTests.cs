/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Test cases                              *
*  Assembly : Empiria.Payments.Core.Tests.dll            Pattern   : Use cases tests                         *
*  Type     : PayableUseCasesTests                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Test cases for payable objects use cases.                                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using Xunit;

using Empiria.Payments.Payables.UseCases;
using Empiria.Payments.Payables.Adapters;

namespace Empiria.Tests.Payments.Payables {

  /// <summary>Test cases for payable objects use cases.</summary>
  public class PayableUseCasesTests {

    #region Use cases initialization

    private readonly PayableUseCases _usecases;

    public PayableUseCasesTests() {
      TestsCommonMethods.Authenticate();

      _usecases = PayableUseCases.UseCaseInteractor();
    }

    ~PayableUseCasesTests() {
      _usecases.Dispose();
    }

    #endregion Use cases initialization

    #region Facts

    [Fact]
    public void Should_Create_Payable() {
      var fields = new PayableFields {
        PayableTypeUID = "32e1b307-676b-4488-b26f-1cbc03878875",
        PayToUID = "c6278424-d1ff-492f-b5fe-410b4258292c",
        CurrencyUID = "358626ea-3c2c-44dd-80b5-18017fe3927e",
        DueTime = DateTime.Today,
        Notes = "Sin notas",
    };

      var sut = _usecases.CreatePayable(fields);

      Assert.NotNull(sut);
    }


    #endregion Facts

  }  //  class PayableUseCasesTests

}  // namespace Empiria.Tests.Payments.Payables
