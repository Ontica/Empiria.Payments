/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Data Transfer Object                    *
*  Type     : PayableDto                                 License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Data transfer objects used to return payable objects.                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/



using System;

namespace Empiria.Payments.Payables.Adapters {

  /// <summary>Data transfer objects used to return payable objects.</summary>
  public class PayableDto {

    public string UID {
      get; internal set;
    }

    
    public NamedEntityDto PayTo {
      get; internal set;
    }


    public decimal Total {
      get; internal set;
    }


    public string Currency {
      get; internal set;
    }


    public DateTime DueTime {
      get; internal set;
    }


    public string Notes {
      get; internal set;
    }
        

    public NamedEntityDto Status {
      get; internal set;
    }


  } // class PayableDto


}  // namespace Empiria.Payments.Payables.Adapters