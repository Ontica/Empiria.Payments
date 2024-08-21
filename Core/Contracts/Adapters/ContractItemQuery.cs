/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Item Management                  Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Query DTO                               *
*  Type     : ContractItemQuery                          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Query data transfer object used to search contracts item.                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Payments.Contracts.Adapters {

  /// <summary>Query data transfer object used to search contracts item.</summary>
  public class ContractItemQuery {

    public string ProductUID {
      get; set;
    }

    public string Keywords {
      get; set;
    }

    public string[] BudgetSegmentsItem {
      get; set;
    }


  }  // class ContractItemQuery

} // namespace Empiria.Payments.ContractsItem.Adapters
