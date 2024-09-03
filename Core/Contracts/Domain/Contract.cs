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

namespace Empiria.Payments.Contracts {

  /// <summary>Represents a contract or a service order.</summary>
  public class Contract : BaseObject, INamedEntity {

    #region Constructors and parsers

    private Contract() {
      // Required by Empiria Framework.
    }

    public Contract(ContractFields fields) {
      Assertion.Require(fields, nameof(fields));

      Load(fields);
    }


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
    public string ContractTypeUID {
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

    [DataField("FROM_DATE")]
    public DateTime FromDate {
      get; private set;
    }


    [DataField("TO_DATE")]
    public DateTime ToDate {
      get; private set;
    }


    [DataField("SIGN_DATE")]
    public DateTime SignDate {
      get; private set;
    }


    [DataField("MANAGED_BY_ORG_UNIT_ID")]
    public OrganizationalUnit ManagedByOrgUnit {
      get; private set;
    }


    [DataField("SUPPLIER_UID")]
    public string SupplierUID {
      get; private set;
    }


    [DataField("CONTRACT_EXT_DATA")]
    private JsonObject ExtData {
      get; set;
    }


    internal decimal FromTotal {
      get {
        return ExtData.Get<decimal>("fromTotal", 0);
      } set {
        ExtData.SetIf("fromTotal", value, value != 0);
      }
    }

    internal Contact LastUpdatedBy {
      get {
        return ExtData.Get<Contact>("lastUpdatedById", Contact.Empty);
      }
      set {
        ExtData.Set("lastUpdatedById", value.Id);
      }
    }

   
    internal DateTime LastUpdatedTime {
      get {
        return ExtData.Get<DateTime>("lastUpdatedTime", this.PostingTime);
      }
      set {
        ExtData.Set("lastUpdatedTime", value);
      }
    }

    [DataField("CONTRACT_TOTAL", ConvertFrom = typeof(decimal))]
    public decimal Total {
      get; private set;
    }


    public string Keywords {
      get {
        return EmpiriaString.BuildKeywords(this.ContractNo, this.Name, this.Description,
                                           ManagedByOrgUnit.Name, ManagedByOrgUnit.Code);
      }
    }


    [DataField("POSTED_BY_ID")]
    public Contact PostedBy {
      get; private set;
    }


    [DataField("POSTING_TIME")]
    public DateTime PostingTime {
      get; private set;
    }


    [DataField("CONTRACT_STATUS", Default = EntityStatus.Pending)]
    public EntityStatus Status {
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

      LastUpdatedBy = ExecutionServer.CurrentContact;
      LastUpdatedTime = DateTime.Now;

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

    private void Load(ContractFields fields) {
      ContractTypeUID = fields.ContractTypeUID;
      ContractNo = fields.ContractNo;
      Name = fields.Name;
      Description = string.Empty;
      FromDate = fields.FromDate;
      ToDate = fields.ToDate;
      SignDate = fields.SignDate;
      Total = fields.Total;
      ManagedByOrgUnit = OrganizationalUnit.Parse(fields.ManagedByOrgUnitUID);
      SupplierUID = fields.SupplierUID;
      ExtData = new JsonObject();
    }

    #endregion Helpers

  }  // class Contract

}  // namespace Empiria.Payments.Contracts
