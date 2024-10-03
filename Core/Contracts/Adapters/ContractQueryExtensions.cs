﻿/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Query DTO                               *
*  Type     : ContractQueryExtensions                    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Query data transfer object used to search contracts.                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using Empiria.Budgeting;
using Empiria.Parties;
using Empiria.StateEnums;

namespace Empiria.Payments.Contracts.Adapters {

  /// <summary>Query data transfer object used to search contracts.</summary>
  static internal class ContractQueryExtensions {

    #region Extension Methods
    static internal void EnsureIsValid(this ContractQuery query) {
      // no - op
    }

    static internal string MapToFilterString(this ContractQuery query) {

      string statusFilter = BuildContractStatusFilter(query.Status);

      string contractNoFilter = BuildContractNoFilter(query.ContractNo);

      string keywordFilter = BuildkeywordFilter(query.Keywords);

      string supplierUIDFilter = BuildSupplierFilter(query.SupplierUID);

      string budgetTypeUIDFilter = BuildBudgetTypeFilter(query.BudgetTypeUID);

      string managedByOrgUnitFilter = BuildManagedByOrgUnitFilter(query.ManagedByOrgUnitUID);

      var filter = new Filter(statusFilter);

      filter.AppendAnd(contractNoFilter);

      filter.AppendAnd(keywordFilter);

      filter.AppendAnd(supplierUIDFilter);

      filter.AppendAnd(budgetTypeUIDFilter);

      filter.AppendAnd(managedByOrgUnitFilter);

      return filter.ToString();

    }

    internal static string MapToSortString(this ContractQuery query) {

      if (query.OrderBy.Length != 0) {
        return query.OrderBy;
      }

      return "CONTRACT_NO";

    }

    #endregion Extension Methods


    #region Helpers

    private static string BuildBudgetTypeFilter(string budgetTypeUID) {
      if (budgetTypeUID == string.Empty) {
        return string.Empty;
      }

      var budgetType = BudgetType.Parse(budgetTypeUID);

      return $"CONTRACT_BUDGET_TYPE_ID = {budgetType.Id}";
    }

    private static string BuildSupplierFilter(string supplierUID) {
      if (supplierUID == string.Empty) {
        return string.Empty;
      }

      var supplier = ContractSuppliers.Parse(supplierUID);

      return $"CONTRACT_SUPPLIER_ID = '{supplier.Id}'";
    }

    private static string BuildkeywordFilter(string keywords) {
      if (keywords == string.Empty) {
        return string.Empty;
      }

      return SearchExpression.ParseAndLike("CONTRACT_KEYWORDS", keywords);
    }

    private static string BuildContractNoFilter(string contratNo) {
      if (contratNo == string.Empty) {
        return string.Empty;
      }

      return $"CONTRACT_NO = '{contratNo}'";
    }

    private static string BuildContractStatusFilter(EntityStatus status) {
      if (status == EntityStatus.All) {
        return "CONTRACT_STATUS <> 'X' ";
      }

      return $"CONTRACT_STATUS = '{(char) status}'";
    }

    private static string BuildManagedByOrgUnitFilter(string managedByOrgUnitUID) {
      if (managedByOrgUnitUID == string.Empty) {
        return string.Empty;
      }

      var managedByOrgUnit = OrganizationalUnit.Parse(managedByOrgUnitUID);

      return $"CONTRACT_MGMT_ORG_UNIT_ID = {managedByOrgUnit.Id}";
    }

    #endregion Helpers

  }  // class ContractQueryExtensions

} // namespace Empiria.Payments.Contracts.Adapters
