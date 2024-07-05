/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments                                   Component : Test cases                              *
*  Assembly : Empiria.FinancialAccounting.Tests.dll      Pattern   : Use cases tests                         *
*  Type     : PaymentOrderUseCasesTests                  License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Test cases for payment order use cases.                                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using Xunit;

using Empiria.Payments.Orders.Adapters;
using Empiria.Payments.Orders.UseCases;
using static Microsoft.Exchange.WebServices.Data.SearchFilter;

namespace Empiria.Tests.Payments.Orders {

  /// <summary>Test cases for payment order use cases.</summary>
  public class PaymentOrderUseCasesTests {

    #region Use cases initialization

    private readonly PaymentOrderUseCases _usecases;

    public PaymentOrderUseCasesTests() {
      TestsCommonMethods.Authenticate();

      _usecases = PaymentOrderUseCases.UseCaseInteractor();
    }

    ~PaymentOrderUseCasesTests() {
      _usecases.Dispose();
    }

    #endregion Use cases initialization

    #region Facts

    [Fact]
    public void Should_Add_Payment_Order() {
      var fields = new PaymentOrderFields {
        PayToUID = "asgfsaasgasg",
        
        RequestedByUID = "fafadf",
        Notes = "Orden de Pago especial",
        RequestedDate = new DateTime(2023, 12, 18),
        Total = 1234567.89m,
      };

      var sut = _usecases.AddPaymentOrder(fields);

      Assert.NotNull(sut);
      
    }


    [Fact]
    public void Should_Read_A_Contract() {

      //ContractDto sut = _usecases.GetContract(TestingConstants.CONTRACT_UID);

      //Assert.NotNull(sut);
      //Assert.NotNull(sut.UID);
      //Assert.Equal(TestingConstants.CONTRACT_UID, sut.UID);
      //Assert.NotNull(sut.ContractNo);
      //Assert.True(sut.Total > 0);
    }

    #endregion Facts

  }  // class PaymentOrderUseCasesTests

}  // namespace Empiria.Tests.Payments.Orders
