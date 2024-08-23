/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Item Management                  Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Data Transfer Object                    *
*  Type     : ContractItemDto                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Data transfer object used to return contracts item information.                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

namespace Empiria.Payments.Contracts.Adapters {

  /// <summary>Data transfer object used to return contracts information.</summary>
  public class ContractItemDto {

    public int ID {
      get; set;
    }

    public string UID {
      get; set;
    }

    public int ContractId {
      get; set;
    }

    public int ProductId {
      get; set;
    }

    public string Description {
      get; set;
    }


    public int UnitMeasureId {
      get; set;
    }


    public decimal FromQuantity {
      get; set;
    }


    public decimal ToQuantity {
      get; set;
    }


    public decimal UnitPrice {
      get; set;
    }


    public int ProjectId {
      get; set;
    }


    public int PaymentsPeriodicityId {
      get; set;
    }


    public int BudgetAccountId {
      get; set;
    }


    public int DocumentTypesListId {
      get; set;
    }


    public DateTime SignDate {
      get; set;
    }


    public decimal Total {
      get; set;
    }

  }  // class ContractItemDto

}  // namespace Empiria.Payments.ContractsItem.Adapters
