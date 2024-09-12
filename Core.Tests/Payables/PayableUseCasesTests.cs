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
using Empiria.Budgeting;

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
        PayableTypeId = 3724,
        OrganizationalUnitUID = "d4b9aae9-cc6e-4fbc-9589-639dec5dab9f",
        PayToUID = "c6278424-d1ff-492f-b5fe-410b4258292c",
        CurrencyUID = "358626ea-3c2c-44dd-80b5-18017fe3927e",
        BudgetTypeId = 3503,
        DueTime = DateTime.Today,
        Notes = "Sin notas",
    };

      var sut = _usecases.CreatePayable(fields);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Get_Budget_Types() {

      var sut = _usecases.GetBudgetTypes();

      Assert.NotNull(sut);
    }                    


    [Fact]
    public void Should_Get_Payable_Types() {

      var sut = _usecases.GetPayableTypes();

      Assert.NotNull(sut);
    }


    #endregion Facts

  }  //  class PayableUseCasesTests

}  // namespace Empiria.Tests.Payments.Payables
