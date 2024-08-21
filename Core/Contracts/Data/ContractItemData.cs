﻿/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts ItemManagement                   Component : Data Layer                              *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Data service                            *
*  Type     : ContractItemData                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data read and write methods for contract item instances.                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Data;

namespace Empiria.Payments.Contracts.Data {

  /// <summary>Provides data read and write methods for contract item instances.</summary>
  static public class ContractIemData {

    static public void WriteContractItem(ContractItem o, string extensionData) {
      var op = DataOperation.Parse("write_Contract_Item",
                     o.Id, o.UID, o.ContractUID, o.ProductUID, o.Description,
                     o.UnitMeasureUID, o.FromQuantity, o.ToQuantity,
                     o.UnitPrice, o.ProjectUID, o.PaymentsPeriodicityUID,
                     o.BudgetAccountUID, o.DocumentTypesListUID, o.SignDate,
                     extensionData, o.Keywords, o.LastUpdatedByUID, o.LastUpdatedTime,
                     (char) o.Status);


      DataWriter.Execute(op);
    }

  }  // class ContractData

}  // namespace Empiria.Payments.Contracts.Data