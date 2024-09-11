/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Interface adapters                      *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Fields Input DTO                        *
*  Type     : PayableItemFields                          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Contains fields in order to create or update a PayableItem.                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

namespace Empiria.Payments.Payables.Adapters {

  /// <summary>Contains fields in order to create or update a PayableItem.</summary>
  public class PayableItemFields {

    public string UID {
      get; set;
    }

    internal void EnsureValid() {
      throw new NotImplementedException();
    }

  }  // class PayableItemFields

}  // namespace Empiria.Payments.Payables.Adapters
