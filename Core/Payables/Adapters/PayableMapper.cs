/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Mapper                                  *
*  Type     : PayableMapper                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data mapping services for payable objects and related types.                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;


namespace Empiria.Payments.Payables.Adapters {

  /// <summary>Provides data mapping services for payable objects and related types.</summary>
  internal class PayableMapper {


    internal static PayableDto Map(Payable payable) {
      return new PayableDto {
        UID = payable.UID,
        PayTo = payable.PayTo.MapToNamedEntity(),
        Total = payable.Total,
        Currency = payable.Currency.Name,
        DueTime = payable.DueTime,
        Notes = payable.Notes,
        Status = new NamedEntityDto(payable.Status.ToString(), payable.Status.GetName())
      };

      throw new NotImplementedException();
    }


  } // class PayableMapper


} // namespace Empiria.Payments.Payables.Adapters