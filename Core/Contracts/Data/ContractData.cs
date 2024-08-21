   /* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Data Layer                              *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Data service                            *
*  Type     : ContractData                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data read and write methods for contract instances.                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Data;

namespace Empiria.Payments.Contracts.Data {

  /// <summary>Provides data read and write methods for contract instances.</summary>
  static internal class ContractData {

    static internal void WriteContract(Contract o, string extensionData) {
      var op = DataOperation.Parse("write_PYM_Contract",
                     o.Id, o.UID, o.ContractTypeUID, o.ContractNo, o.Name,
                     o.Description, o.FromDate, o.ToDate, o.SignDate,
                     o.ManagedByOrgUnit.Id, o.SupplierUID, o.Total,
                     extensionData, o.Keywords,
                     o.PostedBy.Id, o.PostingTime, (char) o.Status);

      DataWriter.Execute(op);
    }

  }  // class ContractData

}  // namespace Empiria.Payments.Contracts.Data
