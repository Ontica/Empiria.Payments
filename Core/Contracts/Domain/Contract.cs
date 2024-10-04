/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Information Holder                      *
*  Type     : Contract                                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a contract or a service order.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Contacts;
using Empiria.Json;
using Empiria.Parties;
using Empiria.StateEnums;

using Empiria.Payments.Contracts.Adapters;
using Empiria.Payments.Contracts.Data;
using Empiria.Payments.Orders;
using Empiria.Financial.Core;
using Empiria.Budgeting;

namespace Empiria.Payments.Contracts {

  /// <summary>Represents a contract or a service order.</summary>
  public class Contract : BaseObject, INamedEntity {

    #region Constructors and parsers

    public Contract() {
      // Required by Empiria Framework.
    }

    //public Contract() {
      //Assertion.Require(fields, nameof(fields));
      //Load(fields);
    //}


    static internal Contract Parse(int contractId) {
      return BaseObject.ParseId<Contract>(contractId);
    } 


    static internal Contract Parse(string contractUID) {
      return BaseObject.ParseKey<Contract>(contractUID);
    }

    static internal Contract Empty => BaseObject.ParseEmpty<Contract>();


    #endregion Constructors and parsers

    #region Properties

    [DataField("CONTRACT_TYPE_ID")]
    public ContractType ContractType {
      get; private set;
    } 


    [DataField("CONTRACT_NO")]
    public string ContractNo {
      get; private set;
    }


    [DataField("CONTRACT_NAME")]
    public string Name {
      get; private set;
    }


    [DataField("CONTRACT_DESCRIPTION")]
    public string Description {
      get; private set;
    }


    [DataField("CONTRACT_CURRENCY_ID")]
    public Currency Currency {
      get; private set;
    }


    [DataField("CONTRACT_FROM_DATE")]
    public DateTime FromDate {
      get; private set;
    }


    [DataField("CONTRACT_TO_DATE")]
    public DateTime ToDate {
      get; private set;
    }


    [DataField("CONTRACT_SIGN_DATE")]
    public DateTime SignDate {
      get; private set;
    }


    [DataField("CONTRACT_MGMT_ORG_UNIT_ID")]
    public OrganizationalUnit ManagedByOrgUnit {
      get; private set;
    }


    [DataField("CONTRACT_BUDGET_TYPE_ID")]
    public BudgetType BudgetType {
      get; private set;
    }


    [DataField("CONTRACT_SUPPLIER_ID")]
    public Party Supplier {
      get; private set;
    }


    [DataField("CONTRACT_PARENT_ID", Default = -1)]
    private int ParentId {
      get; set;
    } = -1;


    public Contract Parent {
      get {
        if (this.IsEmptyInstance || this.ParentId == this.Id) {
          return this;
        }
        return Contract.Parse(this.ParentId);
      }
    }


    public bool HasParent {
      get {
        return !Parent.IsEmptyInstance && Parent.Distinct(this);
      }
    }


    [DataField("CONTRACT_EXT_DATA")]
    private JsonObject ExtData {
      get; set;
    }


    public string Keywords {
      get {
        return EmpiriaString.BuildKeywords(this.ContractNo, this.Name, this.Description,
                                           ManagedByOrgUnit.Name, ManagedByOrgUnit.Code);
      }
    }


    [DataField("CONTRACT_POSTED_BY_ID")]
    public Contact PostedBy {
      get; private set;
    }


    [DataField("CONTRACT_POSTING_TIME")]
    public DateTime PostingTime {
      get; private set;
    }


    [DataField("CONTRACT_STATUS", Default = EntityStatus.Pending)]
    public EntityStatus Status {
      get; private set;
    }


    public decimal Total {
      get; private set;
    }


    #endregion Properties

    #region Methods

    internal void Activate() {
      Assertion.Require(this.Status == EntityStatus.Suspended,
                  $"No se puede activar un contrato que no está suspendido.");

      this.Status = EntityStatus.Active;
    }


    //internal void Close(ContractCloseFields fields) {
    //  this.Status = EntityStatus.Closed;
    //}


    internal void Delete() {

      Assertion.Require(this.Status == EntityStatus.Active || this.Status == EntityStatus.Suspended,
                  $"No se puede eliminar un contrato que está en estado {this.Status.GetName()}.");

      this.Status = EntityStatus.Deleted;
    }


    protected override void OnSave() {
      if (base.IsNew) {
        this.PostedBy = ExecutionServer.CurrentContact;
        this.PostingTime = DateTime.Now;
      }

      ContractData.WriteContract(this, this.ExtData.ToString());
    }


    internal void SetDates(DateTime signDate, DateTime fromDate, DateTime toDate) {
      Assertion.Require(signDate <= fromDate,
                        "La fecha de firma del contrato no puede ser posterior a la fecha de inicio.");
      Assertion.Require(fromDate <= toDate,
                        "La fecha de inicio del contrato no puede ser posterior a la fecha de su terminación.");

      this.SignDate = signDate;
      this.FromDate = fromDate;
      this.ToDate = toDate;
    }


    internal void Suspend() {
      Assertion.Require(this.Status == EntityStatus.Active,
                  $"No se puede suspender un contrato que no está activo.");

      this.Status = EntityStatus.Suspended;
    }

    #endregion Methods

    #region Helpers

    internal void Load(ContractFields fields) {
      this.ContractType = ContractType.Parse(fields.ContractTypeUID);
      this.ContractNo = fields.ContractNo;
      this.Name = fields.Name;
      this.Description = fields.Description;
      this.Currency = Currency.Parse(fields.CurrencyUID);
      this.FromDate = fields.FromDate;
      this.ToDate = fields.ToDate;
      this.SignDate = fields.SignDate;
      this.ManagedByOrgUnit = OrganizationalUnit.Parse(fields.ManagedByOrgUnitUID);
      this.Supplier = Party.Parse(fields.SupplierUID);
      this.BudgetType = BudgetType.Parse(fields.BudgetTypeUID);
      ExtData = new JsonObject();
    }

    internal void AddItem(ContractItem contractItem) {
      throw new NotImplementedException();
    }

    internal ContractItem RemoveItem(string contractItemUID) {
      Assertion.Require("contractItemUID", nameof(contractItemUID));
       
      var contractItem = ContractItem.Parse(contractItemUID);

      // ToDo Remove from contract item list.
      contractItem.Delete();

      return contractItem;
    }

    internal ContractItem UpdateItem(string contractItemUID, ContractItemFields fields) {
      Assertion.Require("contractItemUID", nameof(contractItemUID));

      var contractItem = ContractItem.Parse(contractItemUID);

      // ToDo Update from contract item list.
      contractItem.Load(fields);

      return contractItem;
    }

    #endregion Helpers

  }  // class Contract

}  // namespace Empiria.Payments.Contracts
