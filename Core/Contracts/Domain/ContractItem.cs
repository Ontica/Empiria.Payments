/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts item Management                  Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Information Holder                      *
*  Type     : ContractItem                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a contract item or a service order.                                                 *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using System.Security.Cryptography;
using Empiria.Budgeting;
using Empiria.Contacts;
using Empiria.DataTypes;
using Empiria.Json;
using Empiria.Payments.Contracts.Adapters;
using Empiria.Payments.Contracts.Data;
using Empiria.Projects;
using Empiria.StateEnums;
using Newtonsoft.Json.Linq;

namespace Empiria.Payments.Contracts {

  /// <summary>Represents a contract or a service order.</summary>
  public class ContractItem : BaseObject {

    #region Constructors and parsers

    private ContractItem() {
      // Required by Empiria Framework.
    }

    public ContractItem(ContractItemFields fields) {
      Assertion.Require(fields, nameof(fields));

      Load(fields);
    }


    static internal ContractItem Parse(string contractItemUID) {
      return BaseObject.ParseKey<ContractItem>(contractItemUID);
    }

    #endregion Constructors and parsers

    #region Properties


    [DataField("CONTRACT_ID")]
    public Contract Contract {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_PRODUCTID")]
    public ContractCucop Product {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_DESCRIPTION")]
    public string Description {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_UNITID")]
    public ContractUnit UnitMeasure {
      get; private set;
    }

    [DataField("CONTRACT_ITEM_FROMQUANTITY")]
    public decimal FromQuantity {
      get; private set;
    }

    [DataField("CONTRACT_ITEM_TOQUANTITY")]
    public decimal ToQuantity {
      get; private set;
    }

    [DataField("CONTRACT_ITEM_UNITPRICE")]
    public decimal UnitPrice {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_PROJECTID")]
    public Project Project
    {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_PAYMENTPERID")]
    public Payments.Contracts.Contract PaymentsPeriodicity {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_BDGACCOUNTID")]
    public BudgetAccount BudgetAccount {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_DOCTYPESLISTID")]
    public int DocumentTypesListId {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_SIGNDATE")]
    public DateTime SignDate {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_EXTDATA")]
    private JsonObject ExtData {
      get; set;
    }

    [DataField("CONTRACT_ITEM_POSTED_BY_ID")]
    internal Contact LastUpdatedBy {
      get {
        return ExtData.Get<Contact>("lastUpdatedBy", Contact.Empty);
      }
      set {
        ExtData.Set("lastUpdatedBy", value.Id);
      }
    }

    
    [DataField("CONTRACT_ITEM_POSTING_TIME")]
    internal DateTime LastUpdatedTime {
      get {
        return ExtData.Get<DateTime>("lastUpdatedTime", this.PostingTime);
      }
      set {
        ExtData.Set("lastUpdatedTime", value);
      }
    }

    
    [DataField("CONTRACT_ITEM_TOTAL", ConvertFrom = typeof(decimal))]
    public decimal Total {
      get; private set;
    }


    public string Keywords {
      get {
        return EmpiriaString.BuildKeywords(this.Description);
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


    [DataField("CONTRACT_ITEM_STATUS", Default = EntityStatus.Active)]
    public EntityStatus Status {
      get; private set;
    }

    #endregion Properties

    #region Methods

    internal void Delete() {

      this.Status = EntityStatus.Deleted;
    }


    protected override void OnSave() {
      if (base.IsNew) {
        this.LastUpdatedBy = ExecutionServer.CurrentContact;
        this.LastUpdatedTime = DateTime.Now;
      }

      LastUpdatedBy = ExecutionServer.CurrentContact;
      LastUpdatedTime = DateTime.Now;

      ContractIemData.WriteContractItem(this, this.ExtData.ToString());
    }

    #endregion Methods

    #region Helpers

    private void Load(ContractItemFields fields) {
      this.Contract = Contract.Parse(fields.ContractUID);
      this.Product = ContractCucop.Parse(fields.ProductUID);
      this.Description = fields.Description;
      this.UnitMeasure = ContractUnit.Parse(fields.UnitMeasureUID);
      this.FromQuantity = fields.FromQuantity;
      this.ToQuantity = fields.ToQuantity;
      this.UnitPrice = fields.UnitPrice;
      this.PaymentsPeriodicity = Contract.Parse(fields.PaymentsPeriodicityUID);
      this.BudgetAccount = BudgetAccount.Parse(fields.BudgetAccountUID);
      this.DocumentTypesListId = fields.DocumentTypesListID;
      this.SignDate = fields.SignDate;
      this.LastUpdatedBy = Contact.Parse(ExecutionServer.CurrentUserId);
      this.PostingTime = DateTime.Now;
      this.Status = EntityStatus.Active;
}

    #endregion Helpers

  }  // class Contract

}  // namespace Empiria.Payments.Contracts
