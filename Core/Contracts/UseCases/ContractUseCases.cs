/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Use cases Layer                         *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Use case interactor class               *
*  Type     : ContractUseCases                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Use cases for contract management.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

using Empiria.Services;

using Empiria.Payments.Contracts.Adapters;

namespace Empiria.Payments.Contracts.UseCases {

    /// <summary>Use cases for contract management.</summary>
    public class ContractUseCases : UseCase {

    #region Constructors and parsers

    protected ContractUseCases() {
      // no-op
    }

    static public ContractUseCases UseCaseInteractor() {
      return UseCase.CreateInstance<ContractUseCases>();
    }

    #endregion Constructors and parsers

    #region Use cases

    public ContractDto AddContract(ContractFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      var contract = new Contract(fields);

      contract.Save();

      ContractDto dto = new ContractDto();

      dto.UID = contract.UID;
      dto.ContractNo = contract.ContractNo;
      dto.Name = contract.Name;
      dto.Total = contract.Total;

      return dto;
    }

    #endregion Use cases

  }  // class ContractUseCases

}  // namespace Empiria.Payments.Contracts.UseCases
