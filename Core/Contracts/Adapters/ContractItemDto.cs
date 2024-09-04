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

    public string UID {
      get; set;
    }


    public NamedEntityDto Contract {
      get; set;
    }


    public NamedEntityDto Product {
      get; set;
    }


    public string Description {
      get; set;
    }


    public NamedEntityDto UnitMeasure {
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


    public NamedEntityDto Project {
      get; set;
    }


    public NamedEntityDto PaymentsPeriodicity {
      get; set;
    }


    public NamedEntityDto BudgetAccount {
      get; set;
    }


    public NamedEntityDto DocumentTypesListId {
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
