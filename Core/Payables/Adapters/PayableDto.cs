﻿/* Empiria Financial *****************************************************************************************
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


  /// <summary>Output DTO used to return minimal payables objects data for use in lists.</summary>
  public class PayableDescriptor {

    public string UID {
      get; internal set;
    }

    public string PayableNo {
      get; internal set;
    }

    public string PayableTypeName {
      get; internal set;
    }


    public string BudgetTypeName {
      get; internal set;
    }


    public string ContractNo {
      get; internal set;
    }


    public string PayTo {
      get; internal set;
    }


    public decimal Total {
      get; internal set;
    }


    public string CurrencyCode {
      get; internal set;
    }


    public DateTime DueTime {
      get; internal set;
    }

    public DateTime RequestedTime {
      get; internal set;
    }

    public string RequestedBy {
      get; internal set;
    }


    public string StatusName {
      get; internal set;
    }


  } // class PayableDescriptor

}  // namespace Empiria.Payments.Payables.Adapters