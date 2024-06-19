/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Query DTO                               *
*  Type     : ContractQuery                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Query data transfer object used to search contracts.                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Payments.Contracts.Adapters {

  /// <summary>Query data transfer object used to search contracts.</summary>
  public class ContractQuery {

    public string ContractNo {
      get; set;
    }

    public string Keywords {
      get; set;
    }

    public string SupplierCLABE {
      get; set;
    }

    public string[] BudgetSegments {
      get; set;
    }

    public bool HasPendingPayments {
      get; set;
    }

  }  // class ContractQuery

} // namespace Empiria.Payments.Contracts.Adapters
