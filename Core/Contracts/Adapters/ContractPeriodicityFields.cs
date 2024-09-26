/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Periodicity Fields Management    Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Fields DTO                              *
*  Type     : ContractPeriodicityFields                  License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : DTO fields structure used for update contracts information.                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

namespace Empiria.Payments.Contracts.Adapters {

  /// <summary>DTO fields structure used for update contracts document fields information.</summary>
  public class ContractPeriodicityFields {

    public string ID {
      get; set;
    }


    public string UID {
      get; set;
    }


    public string Name {
      get; set;
    }


    internal void EnsureValid() {
      // nop
    }

  }  // class ContractPeriodicityFields

}  // namespace Empiria.Payments.Contracts.Adapters
