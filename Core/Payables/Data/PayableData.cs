﻿/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payables Management                        Component : Data Layer                              *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Data service                            *
*  Type     : PayableData                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data read and write methods for Payable instances.                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using Empiria.Data;

namespace Empiria.Payments.Payables.Data {

  /// <summary>Provides data read and write methods for Payable instances.</summary>
  static internal class PayableData {

    #region Methods

    static internal PayableItem GetPayableItem(Payable payable, string payableItemUID) {
      Assertion.Require(payable, nameof(payable));
      Assertion.Require(payableItemUID, nameof(payableItemUID));

      throw new NotImplementedException();
    }


    static internal FixedList<PayableItem> GetPayableItems(Payable payable) {
      Assertion.Require(payable, nameof(payable));

      throw new NotImplementedException();
    }


    static internal void WritePayable(Payable o, string extensionData) {
      var op = DataOperation.Parse("write_PYM_Payable",
                     o.Id, o.UID, o.PayableType.Id, o.OrganizationalUnit.Id,
                     o.PayTo.Id, Contracts.Contract.Empty.Id,
                     o.Currency.Id, o.BudgetType.Id, o.DueTime, o.Notes,
                     extensionData, o.Keywords, o.PostedBy.Id,
                     o.PostingTime, (char) o.Status);

      DataWriter.Execute(op);
    }

    static internal void WriteContractMilestone(ContractMilestone o, string extensionData) {
      var op = DataOperation.Parse("write_PYM_Payable",
                     o.Id, o.UID, o.PayableType.Id, o.OrganizationalUnit.Id,
                     o.PayTo.Id, o.Contract.Id,
                     o.Currency.Id, o.BudgetType.Id, o.DueTime, o.Notes,
                     extensionData, o.Keywords, o.PostedBy.Id,
                     o.PostingTime, (char) o.Status);

      DataWriter.Execute(op);
    }


    #endregion Methods

  }  // class PayableData

}  // namespace Empiria.Payments.Payables.Data
