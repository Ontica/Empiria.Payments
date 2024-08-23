/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Mapper                                  *
*  Type     : ContractMapper                             License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data mapping services for Contract related types.                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using Empiria.Contacts;
using Empiria.StateEnums;
using System.Net.NetworkInformation;

namespace Empiria.Payments.Contracts.Adapters {

  /// <summary>Provides data mapping services for Contract related types.</summary>
  static internal class ContractItemMapper {

    static internal FixedList<ContractItemDto> Map(FixedList<ContractItem> contractsItem) {
      return contractsItem.Select(x => Map(x))
                      .ToFixedList();
    }


    static internal ContractItemDto Map(ContractItem contractItem) {
      return new ContractItemDto {
        ID = contractItem.Id,
        UID = contractItem.UID,
        ContractId = contractItem.ContractId,
        ProductId = contractItem.ProductId, 
        Description = contractItem.Description,
        UnitMeasureId = contractItem.UnitMeasureId,
        FromQuantity = contractItem.FromQuantity,
        ToQuantity = contractItem.ToQuantity,
        UnitPrice = contractItem.UnitPrice,
        ProjectId = contractItem.ProjectId,
        PaymentsPeriodicityId = contractItem.PaymentsPeriodicityId,
        BudgetAccountId = contractItem.BudgetAccountId,
        DocumentTypesListId = contractItem.DocumentTypesListId,
        SignDate = contractItem.SignDate,
        Total = contractItem.Total
      };

    }
  
  }  // class ContractMapper

}  // namespace Empiria.Payments.Contracts.Adapters
