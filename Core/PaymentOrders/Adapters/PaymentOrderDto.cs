/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Data Transfer Object                    *
*  Type     : PaymentOrderDto                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Data transfer object used to return payment order information.                                 *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using Empiria.StateEnums;

namespace Empiria.Payments.Orders.Adapters {

  /// <summary>Data transfer object used to return contracts information.</summary>
  public class PaymentOrderDto {

    public string UID {
      get; internal set;
    }

    
    public string OrderNo {
      get; internal set;
    }


    public string PayTo {
      get; internal set;
    }


    public string PayToType {
      get; internal set;
    }


    public string BussinesObjectType {
      get; internal set;
    }


    public string BussinesObject {
      get; internal set;
    }


    public string RequestedBy {
      get; internal set;
    }


    public DateTime RequestedDate {
      get; internal set;
    }


    public string Notes {
      get; internal set;
    }

    
    public decimal Total {
      get; internal set;
    }


    public EntityStatus Status {
      get; internal set;
    }



  }  // class PaymentOrderDto

}  // namespace Empiria.Payments.Orders.Adapters
