/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Use cases Layer                         *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Use case interactor class               *
*  Type     : ContractUseCases                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Use cases for contract management.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Payments.Contracts.Adapters;

namespace Empiria.Payments.Contracts.UseCases
{

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

      contract.SetDates(fields.SignDate, contract.FromDate, fields.ToDate);

      contract.Save();

      return ContractMapper.Map(contract);
    }


    public ContractDto GetContract(string contractUID) {
      Assertion.Require(contractUID, nameof(contractUID));

      var contract = Contract.Parse(contractUID);

      return ContractMapper.Map(contract);
    }


    public FixedList<NamedEntityDto> GetContractTypes() {
      var contractTypes = ContractType.GetList();

      return contractTypes.MapToNamedEntityList();
    }


    public FixedList<NamedEntityDto> GetContractUnit() {
      var contractUnit = ContractUnit.GetList();

      return contractUnit.MapToNamedEntityList();
    }


    public FixedList<NamedEntityDto> GetContractCucop() {
      var contractCucop = ContractCucop.GetList();

      return contractCucop.MapToNamedEntityList();
    }


    public FixedList<ContractDto> SearchContracts(ContractQuery query) {
      Assertion.Require(query, nameof(query));

      //string condition = query.GetConditionClause();
      //string orderBy = query.GetOrderByClause();

      //FixedList<Contract> contracts = ContractData.SearchContracts(condition, orderBy);

      var contracts = new FixedList<Contract>();

      return ContractMapper.Map(contracts);
    }

    #endregion Use cases

  }  // class ContractUseCases

}  // namespace Empiria.Payments.Contracts.UseCases
