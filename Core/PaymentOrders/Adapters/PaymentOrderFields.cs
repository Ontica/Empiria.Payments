/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Fields DTO                              *
*  Type     : PaymentsFields                             License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : DTO fields structure used for update payment order information.                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using Empiria.Parties;

namespace Empiria.Payments.Orders.Adapters {

  /// <summary>DTO fields structure used for update payment order information.</summary>
  public class PaymentOrderFields {

    public string PaymentOrderTypeUID {
      get; set;
    }


    public string PayableUID {
      get; set;
    }


    public string PayToUID {
      get; set;
    }


    public string PaymentMethodUID {
      get; set;
    }

       
    public string CurrencyUID {
      get; set;
    }


    public string PaymentAccounUID {
      get; set;
    }


    public string Notes {
      get;  set;
    }
        

    public Decimal Total {
      get; set;
    }


    public DateTime DueTime {
      get; set;
    }


    public string RequestedByUID {
      get; set;
    }


    public DateTime RequestedDate {
      get; set;
    } = ExecutionServer.DateMinValue;


  }  // class PaymentOrderFields

}  // namespace Empiria.Payments.Orders
