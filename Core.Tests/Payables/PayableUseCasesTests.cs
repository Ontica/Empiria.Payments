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
using Empiria.Products;


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
    public void Should_Add_PayableItem() {
      var fields = new PayableItemFields {
        ProductUID = "",
        UnitUID = "",
        Description = "Agregado desde las pruebas",
        Quantity = 3m,
        UnitPrice = 10,
        CurrencyUID = "358626ea-3c2c-44dd-80b5-18017fe3927e",
        ExchangeRate = 1m,
        BudgetAccountUID = "ebc50e45-071d-4da4-8c63-0c54c10cfe0a"
      };

      var payableUID = "713b2755-aee1-44af-9f3c-1f46caebca1c";
      var sut = _usecases.AddPayableItem(payableUID, fields);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Create_Payable() {
      var fields = new PayableFields {
        PayableTypeUID = "ObjectTypeInfo.Payable.Bill",
        Description = "Sin notas",
        OrganizationalUnitUID = "d4b9aae9-cc6e-4fbc-9589-639dec5dab9f",
        PayToUID = "c6278424-d1ff-492f-b5fe-410b4258292c",
        CurrencyUID = "358626ea-3c2c-44dd-80b5-18017fe3927e",
        BudgetTypeUID = "ObjectTypeInfo.Budget.ProgramaFinanciero",
        DueTime = DateTime.Today,
    };

      var sut = _usecases.CreatePayable(fields);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Delete_Payable() {

      _usecases.DeletePayable("79cda212-9676-429b-b242-407614eb01db");
    }


    [Fact]
    public void Should_Get_Payable() {

      var sut = _usecases.GetPayable("79cda212-9676-429b-b242-407614eb01db");

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Get_PayableItems() {

      var sut = _usecases.GetPayableItems("5b428865-0ba3-4113-afe8-4061db5b7c2e");

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Get_Payable_Types() {

      var sut = _usecases.GetPayableTypes();

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Search_Payables() {
      var query = new PayablesQuery {
        Keywords = "oracle",
        FromDate = new DateTime(2024, 01, 01),
        ToDate = new DateTime(2024, 01, 01)
      };

      var sut = _usecases.SearchPayables(query);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Update_Payable() {
      var fields = new PayableFields {
        PayableTypeUID = "ObjectTypeInfo.Payable.Bill",
        Description = "Sin notas",
        OrganizationalUnitUID = "d4b9aae9-cc6e-4fbc-9589-639dec5dab9f",
        PayToUID = "c6278424-d1ff-492f-b5fe-410b4258292c",
        CurrencyUID = "358626ea-3c2c-44dd-80b5-18017fe3927e",
        BudgetTypeUID = "ObjectTypeInfo.Budget.ProgramaFinanciero",
        DueTime = DateTime.Today,
      };

      var payableUID = "5b428865-0ba3-4113-afe8-4061db5b7c2e";
     
      var sut = _usecases.UpdatePayable(payableUID, fields);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Update_PayableItem() {
      var fields = new PayableItemFields {
        ProductUID = "",
        UnitUID = "",
        Description = "Modificado desde las pruebas ",
        Quantity = 3m,
        UnitPrice = 10,
        CurrencyUID = "358626ea-3c2c-44dd-80b5-18017fe3927e",
        ExchangeRate = 1m,
        BudgetAccountUID = "ebc50e45-071d-4da4-8c63-0c54c10cfe0a"
      };

      var payableUID = "713b2755-aee1-44af-9f3c-1f46caebca1c";
      var payableItemUID = "0785cf8e-fd06-4e41-ac1b-b2e3b09d12c2";
      var sut = _usecases.UpdatePayableItem(payableUID,payableItemUID, fields);

      Assert.NotNull(sut);
    }


    #endregion Facts

  }  //  class PayableUseCasesTests

}  // namespace Empiria.Tests.Payments.Payables
