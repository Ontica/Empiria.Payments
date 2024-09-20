/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Data Transfer Object                    *
*  Type     : PayableItemDto                             License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Data transfer objects used to return payable items.                                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/



using System;
using Empiria.StateEnums;

namespace Empiria.Payments.Payables.Adapters {

  /// <summary>Data transfer objects used to return payable items. </summary>
  public class PayableItemDto {

    public string UID {
      get; internal set;
    }


    public string Description {
      get; internal set;
    }


    public NamedEntityDto Product {
      get; internal set;
    }


    public NamedEntityDto Unit {
      get; internal set;
    }


    public decimal Quantity {
      get; private set;
    }


    public NamedEntityDto Currency {
      get; internal set;
    }


    public decimal ExchangeRate {
      get; private set;
    } = 1;


    public decimal UnitPrice {
      get; private set;
    }


    public decimal Subtotal {
      get {
        return Math.Round(UnitPrice * Quantity * ExchangeRate);
      }
    }

    
    public NamedEntityDto Status {
      get; internal set;
    }


  } // class PayableItemDto


}  // namespace Empiria.Payments.Payables.Adapters