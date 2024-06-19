/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Data Transfer Object                    *
*  Type     : ContractDto                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Data transfer object used to return contracts information.                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

namespace Empiria.Payments.Contracts.Adapters {

  /// <summary>Data transfer object used to return contracts information.</summary>
  public class ContractDto {

    public string UID {
      get; internal set;
    }

    public string ContractNo {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }

    public DateTime SignDate {
      get; internal set;
    }

    public decimal Total {
      get; internal set;
    }

    public DateTime LastUpdatedTime {
      get; internal set;
    }

  }  // class ContractDto

}  // namespace Empiria.Payments.Contracts.Adapters
