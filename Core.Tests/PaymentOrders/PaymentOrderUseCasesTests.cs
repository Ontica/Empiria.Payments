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
using Empiria.Payments.Contracts.Adapters;

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
        PaymentOrderTypeUID = "32e1b307-676b-4488-b26f-1cbc03878875",
        PayableUID = "358626ea-3c2c-44dd-80b5-18017fe3927e",
        PayToUID = "c6278424-d1ff-492f-b5fe-410b4258292c",
        PaymentMethodUID = "b7784ef7-0d58-43df-a128-9b35e2da678e",
        CurrencyUID = "358626ea-3c2c-44dd-80b5-18017fe3927e",
        PaymentAccountUID = "-32e1b307-676b-4488-b26f-1cbc03878875",
        Notes = "Sin notas",
        Total = 1234567.89m,
        DueTime = DateTime.Today,
        RequestedByUID  = "6bebca32-c14f-4996-8300-77ac86513a59",
        RequestedDate = DateTime.Now
      
    };

      var sut = _usecases.AddPaymentOrder(fields);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Update_Payment_Order() {
      var fields = new PaymentOrderFields {
        PaymentOrderTypeUID = "32e1b307-676b-4488-b26f-1cbc03878875",
        PayableUID = "358626ea-3c2c-44dd-80b5-18017fe3927e",
        PayToUID = "c6278424-d1ff-492f-b5fe-410b4258292c",
        PaymentMethodUID = "b7784ef7-0d58-43df-a128-9b35e2da678e",
        CurrencyUID = "358626ea-3c2c-44dd-80b5-18017fe3927e",
        PaymentAccountUID = "-32e1b307-676b-4488-b26f-1cbc03878875",
        Notes = "updated by test",
        Total = 21.89m,
        DueTime = DateTime.Today,
        RequestedByUID = "6bebca32-c14f-4996-8300-77ac86513a59",
        RequestedDate = DateTime.Now

      };

      var sut = _usecases.UpdatePaymentOrder("b7a4b215-2ad8-4a5f-9349-21cce0e1a8e9", fields);

      Assert.NotNull(sut);
    }


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

    [Fact]
    public void Should_GetCurrencies() {

      var sut = _usecases.GetCurrencies();

      Assert.NotNull(sut);

    }


    #endregion Facts

  }  // class PaymentOrderUseCasesTests

}  // namespace Empiria.Tests.Payments.Orders
