/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Item Management                  Component : Use cases Layer                         *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Use case interactor class               *
*  Type     : ContractItemUseCases                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Use cases for contract item management.                                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Payments.Contracts.Adapters;

namespace Empiria.Payments.Contracts.UseCases
{

    /// <summary>Use cases for contract management.</summary>
    public class ContractItemUseCases : UseCase {

    #region Constructors and parsers

    protected ContractItemUseCases() {
      // no-op
    }

    static public ContractItemUseCases UseCaseInteractor() {
      return UseCase.CreateInstance<ContractItemUseCases>();
    }

    #endregion Constructors and parsers

    #region Use cases

    public ContractItemDto AddContractItem(string ContractUID, ContractItemFields fields) {
      Assertion.Require(ContractUID, nameof(ContractUID));
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      var contract = Contract.Parse(ContractUID);  

      var contractItem = new ContractItem(fields);

      contract.AddItem(contractItem);

      contractItem.Save();

      return ContractItemMapper.Map(contractItem);
    }


    public void RemoveContractItem(string ContractUID, string ContractItemUID) {
      Assertion.Require(ContractUID, nameof(ContractUID));
      Assertion.Require(ContractItemUID, nameof(ContractItemUID));

      var contract = Contract.Parse(ContractUID);
      var contractItem = contract.RemoveItem(ContractItemUID);

      contractItem.Save();
    }

    public ContractItemDto UpdateContractItem(string ContractUID, string ContractItemUID, ContractItemFields fields) {
      Assertion.Require(ContractUID, nameof(ContractUID));
      Assertion.Require(ContractItemUID, nameof(ContractItemUID));
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();
      
      var contract = Contract.Parse(ContractUID);

      var contractItem = contract.UpdateItem(ContractItemUID, fields);

      contractItem.Save();

      return ContractItemMapper.Map(contractItem);
    }


    public ContractItemDto GetContractItem(string contractItemUID) {
      Assertion.Require(contractItemUID, nameof(contractItemUID));

      var contractItem = ContractItem.Parse(contractItemUID);

      return ContractItemMapper.Map(contractItem);
    }


    #endregion Use cases

  }  // class ContractUseCases

}  // namespace Empiria.Payments.Contracts.UseCases
