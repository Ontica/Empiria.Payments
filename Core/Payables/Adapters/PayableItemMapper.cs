/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Mapper                                  *
*  Type     : PayableItemMapper                          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data mapping services for payable items and related types.                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;


namespace Empiria.Payments.Payables.Adapters {

  /// <summary>Provides data mapping services for payable items and related types.</summary>
  internal class PayableItemMapper {

    #region Methods

    static internal PayableItemDto Map(PayableItem payableItem) {
      return new PayableItemDto {
        UID = payableItem.UID,
        Description = payableItem.Notes,
        Product = new NamedEntityDto("9e2ab96e-f8b7-458d-aec5-5ad429e39464", "Adquisición de software"),
        Unit = new NamedEntityDto("31af88af-bca2-47fc-80f6-0d5e439b5ce3", "pieza"),
        Quantity = 1m,
        Currency = payableItem.Currency.MapToNamedEntity(),
        ExchangeRate = 1m,
        UnitPrice = payableItem.UnitPrice,
        Subtotal = payableItem.Subtotal,
        Status = new NamedEntityDto(payableItem.Status.ToString(), "Activo")
      };
    }


    static internal FixedList<PayableItemDto> Map(FixedList<PayableItem> payableItems) {
      return payableItems.Select(x => Map(x)).ToFixedList();      
    }


    #endregion Methods

  } // class PayableItemMapper


} // namespace Empiria.Payments.Payables.Adapters