/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Accounts Chart                             Component : Test cases                              *
*  Assembly : Empiria.FinancialAccounting.Tests.dll      Pattern   : Use cases tests                         *
*  Type     : AccountsChartUseCasesTests                 License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Test cases for retrieving accounts from the accounts chart.                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using Xunit;

using Empiria.Payments.Contracts.Adapters;
using Empiria.Payments.Contracts.UseCases;

namespace Empiria.Tests.Payments.Contracts {

  /// <summary>Test cases for retrieving accounts from the accounts chart.</summary>
  public class ContractUseCasesTests {

     #region Use cases initialization

    private readonly ContractUseCases _usecases;
    private readonly ContractItemUseCases _itemusecases;


    public ContractUseCasesTests() {
      TestsCommonMethods.Authenticate();

      _usecases = ContractUseCases.UseCaseInteractor();
      _itemusecases = ContractItemUseCases.UseCaseInteractor();
    }

    ~ContractUseCasesTests() {
      _usecases.Dispose();
      _itemusecases.Dispose();
    }

    #endregion Use cases initialization

    #region Facts

    [Fact]
    public void Should_Add_A_Contract() {
      var fields = new ContractFields {
        ContractTypeUID = TestingConstants.CONTRACT_TYPE_UID,
        ContractNo = "123-9089/A456",
        Name = "Servicios de desarrollo de software 1",
        Description = "Description",
        CurrencyUID = TestingConstants.CONTRACT_CURRENCY_ID,
        ToDate = new DateTime(2024, 12, 31),
        FromDate = new DateTime(2024, 1, 1),
        SignDate = new DateTime(2023, 12, 18),
        ManagedByOrgUnitUID = TestingConstants.MANAGED_BY_ORG_UNIT_UID,
        BudgetTypeUID = TestingConstants.CONTRACT_BUDGET_TYPE_UID,
        SupplierUID = TestingConstants.SUPPLIER_UID,
        ParentUID = "Empty",
      };

      ContractDto sut = _usecases.AddContract(fields);

      Assert.NotNull(sut);
      Assert.NotNull(sut.UID);
      Assert.Equal(fields.ContractNo, sut.ContractNo);
      Assert.Equal(fields.Name, sut.Name);
      Assert.Equal(fields.Total, sut.Total);
    }

    [Fact]
    public void Should_Add_A_Contract_Item() {

      var fields = new ContractItemFields {

        ContractUID = TestingConstants.CONTRACT_UID,
        ProductUID = TestingConstants.CONTRACT_ITEM_PRODUCT_UID,
        Description = "Prueba contract items",
        UnitMeasureUID = TestingConstants.CONTRACT_ITEM_UNIT_UID,
        ToQuantity = 5,
        FromQuantity = 2,
        UnitPrice = 20,
        BudgetAccountUID = TestingConstants.CONTRACT_BUDGET_ACCOUNT_UID,
        ProjectUID = TestingConstants.CONTRACT_ITEM_PROJECT_UID,
        PaymentPeriodicityUID = TestingConstants.CONTRACT_ITEM_PYM_PER_UID,
        SignDate = DateTime.Now,

      };

      ContractItemDto sut = _itemusecases.AddContractItem(fields);

      Assert.NotNull(sut);
      Assert.NotNull(sut.UID);
    }


    [Fact]
    public void Should_Read_A_Contract() {

      ContractDto sut = _usecases.GetContract(TestingConstants.CONTRACT_UID);

      Assert.NotNull(sut);
      Assert.NotNull(sut.UID);
      Assert.Equal(TestingConstants.CONTRACT_UID, sut.UID);
      Assert.NotNull(sut.ContractNo);
      Assert.True(sut.Total > 0);
    }


    [Fact]
    public void Should_Read_A_Contract_Unit() {

      var sut = _usecases.GetContractUnit();

      Assert.NotNull(sut);

    }


    [Fact]
    public void Should_Read_A_Contract_Cucop() {

      var sut = _usecases.GetContractCucop();

      Assert.NotNull(sut);

    }


    [Fact]
    public void Should_Search_Contracts() {

      var query = new ContractQuery {
        Keywords = "soft",
      };

      var sut = _usecases.SearchContracts(query);

      Assert.NotNull(sut);

    }


    #endregion Facts

  }  // class ContractUseCasesTests

}  // namespace Empiria.Tests.Payments.Contracts
