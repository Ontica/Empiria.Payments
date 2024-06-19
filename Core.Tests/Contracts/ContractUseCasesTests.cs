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

    public ContractUseCasesTests() {
      TestsCommonMethods.Authenticate();

      _usecases = ContractUseCases.UseCaseInteractor();
    }

    ~ContractUseCasesTests() {
      _usecases.Dispose();
    }

    #endregion Use cases initialization

    #region Facts

    [Fact]
    public void Should_Add_A_Contract() {
      var fields = new ContractFields {
        ContractTypeUID = TestingConstants.CONTRACT_TYPE_UID,
        ContractNo = "123-9089/A456",
        Name = "Servicios de desarrollo de software",
        FromDate = new DateTime(2024, 1, 1),
        ToDate = new DateTime(2024, 12, 31),
        SignDate = new DateTime(2023, 12, 18),
        ManagedByOrgUnitUID = TestingConstants.MANAGED_BY_ORG_UNIT_ID,
        SupplierUID = TestingConstants.SUPPLIER_UID,
        Total = 1234567.89m,
      };

      ContractDto sut = _usecases.AddContract(fields);

      Assert.NotNull(sut);
      Assert.NotNull(sut.UID);
      Assert.Equal(fields.ContractNo, sut.ContractNo);
      Assert.Equal(fields.Name, sut.Name);
      Assert.Equal(fields.Total, sut.Total);
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

    #endregion Facts

  }  // class ContractUseCasesTests

}  // namespace Empiria.Tests.Payments.Contracts
