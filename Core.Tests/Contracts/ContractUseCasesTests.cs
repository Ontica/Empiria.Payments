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

using Empiria.Tests;

using Empiria.Payments.Contracts.Adapters;
using Empiria.Payments.Contracts.UseCases;

namespace Empiria.Payments.Contracts.Tests {

  /// <summary>Test cases for retrieving accounts from the accounts chart.</summary>
  public class ContractUseCasesTests {

    #region Use cases initialization

    private readonly ContractUseCases _usecases;

    public ContractUseCasesTests() {
      // TestsCommonMethods.Authenticate();

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
        ContractNo = "123-9089/A456",
        Name = "Servicios de desarrollo de software",
        FromDate = new DateTime(2024, 1, 1),
        ToDate = new DateTime(2024, 12, 31),
        SignDate = DateTime.Today,
        ManagedByOrgUnitUID = Guid.NewGuid().ToString(),
        SupplierUID = Guid.NewGuid().ToString(),
        Total = 1234567.89m,
      };

      ContractDto sut = _usecases.AddContract(fields);

      Assert.NotNull(sut);
      Assert.NotNull(sut.UID);
      Assert.Equal(fields.ContractNo, sut.ContractNo);
      Assert.Equal(fields.Name, sut.Name);
      Assert.Equal(fields.Total, sut.Total);
    }

    #endregion Facts

  }  // class ContractUseCasesTests

}  // namespace Empiria.FinancialAccounting.Tests
