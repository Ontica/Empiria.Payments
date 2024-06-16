/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Information Holder                      *
*  Type     : Contract                                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a contract or a service order.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Payments.Contracts.Adapters;
using Empiria.Payments.Contracts.Data;

namespace Empiria.Payments.Contracts {

  /// <summary>Represents a contract or a service order.</summary>
  internal class Contract : BaseObject {

    private ContractFields fields;

    public Contract(ContractFields fields) {
      this.fields = fields;
    }

    public string ContractNo {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }

    public decimal Total {
      get; internal set;
    }

    protected override void OnSave() {
      ContractData.WriteContract(this);
    }

  }  // class Contract

}  // namespace Empiria.Payments.Contracts
