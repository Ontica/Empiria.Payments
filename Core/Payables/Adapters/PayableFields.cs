/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Fields DTO                              *
*  Type     : PayableFields                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Fields structure used for create and update payable objects.                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Financial.Core;
using Empiria.Parties;


namespace Empiria.Payments.Payables.Adapters {

  /// <summary>Fields structure used for create and update payable objects.</summary>
  public class PayableFields {

    public string PayableTypeUID {
      get; set;
    }


    public string PayToUID {
      get; set;
    }


    public Decimal Total {
      get; set;
    }
    

    public string CurrencyUID {
      get; set;
    }


    public DateTime DueTime {
      get; set;
    } = ExecutionServer.DateMinValue; 


    public string Notes {
      get; set;
    } = string.Empty;
       
    


    internal void EnsureValid() {
      Assertion.Require(PayableTypeUID, "Necesito el tipo de pago.");
      //_ = PayableType.Parse(PayableTypeUID);

      Assertion.Require(PayToUID, "Necesito saber a quien se le realizará el pago.");
       _ = Party.Parse(PayToUID);

      Assertion.Require(Total > 0, "Necesito que el importe a pagar sea mayor a cero.");

      Assertion.Require(CurrencyUID, "Necesito la moneda.");
      _ = Currency.Parse(CurrencyUID);

           
    }

  }  // class PayableFields

}  // namespace Empiria.Payments.Payables.Adapters
