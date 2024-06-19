/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Mapper                                  *
*  Type     : ContractMapper                             License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data mapping services for Contract related types.                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Payments.Contracts.Adapters {

  /// <summary>Provides data mapping services for Contract related types.</summary>
  static internal class ContractMapper {

    static internal FixedList<ContractDto> Map(FixedList<Contract> contracts) {
      return contracts.Select(x => Map(x))
                      .ToFixedList();
    }


    static internal ContractDto Map(Contract contract) {
      return new ContractDto {
        UID = contract.UID,
        ContractNo = contract.ContractNo,
        Name = contract.Name,
        SignDate = contract.SignDate,
        Total = contract.Total,
        LastUpdatedTime = contract.LastUpdatedTime
      };
    }

  }  // class ContractMapper

}  // namespace Empiria.Payments.Contracts.Adapters
