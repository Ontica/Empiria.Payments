/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payables Management                        Component : Data Layer                              *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Data service                            *
*  Type     : PayableData                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data read and write methods for payable instances.                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Data;


namespace Empiria.Payments.Payables.Data {

  /// <summary>Provides data read and write methods for payable instances.</summary>
  static internal class PayableData {

    #region Methods


    static internal void WritePayable(Payable o, string extensionData) {
      var op = DataOperation.Parse("write_PYM_Payable",
                     o.Id, o.UID, o.PayableType.Id, o.PayTo.Id, o.Total, o.Currency.Id,
                     o.DueTime, o.Notes, extensionData, o.Keywords, o.PostedBy.Id, 
                     o.PostingTime, (char) o.Status);

      DataWriter.Execute(op);
    }


    #endregion Methods

  }  // class PayablesData

}  // namespace Empiria.Payments.Payables.Data 
