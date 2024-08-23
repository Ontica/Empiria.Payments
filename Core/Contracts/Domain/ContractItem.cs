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
using Empiria.Contacts;
using Empiria.DataTypes;
using Empiria.Json;
using Empiria.Payments.Contracts.Adapters;
using Empiria.Payments.Contracts.Data;
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
    public int ContractId {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_PRODUCTID")]
    public int ProductId {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_DESCRIPTION")]
    public string Description {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_UNITID")]
    public int UnitMeasureId {
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
    public int ProjectId
    {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_PAYMENTPERID")]
    public int PaymentsPeriodicityId {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_BDGACCOUNTID")]
    public int BudgetAccountId {
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

    [DataField("POSTED_BY_ID")]
    internal Contact LastUpdatedById {
      get {
        return ExtData.Get<Contact>("lastUpdatedById", Contact.Empty);
      }
      set {
        ExtData.Set("lastUpdatedById", value.Id);
      }
    }

    
    [DataField("POSTING_TIME")]
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
        this.LastUpdatedById = ExecutionServer.CurrentContact;
        this.LastUpdatedTime = DateTime.Now;
      }

      LastUpdatedById = ExecutionServer.CurrentContact;
      LastUpdatedTime = DateTime.Now;

      ContractIemData.WriteContractItem(this, this.ExtData.ToString());
    }

    #endregion Methods

    #region Helpers

    private void Load(ContractItemFields fields) {
      this.ContractId = fields.ContractId;
      this.ProductId = fields.ProductId;
      this.Description = fields.Description;
      this.UnitMeasureId = fields.UnitMeasureId;
      this.FromQuantity = fields.FromQuantity;
      this.ToQuantity = fields.ToQuantity;
      this.UnitPrice = fields.UnitPrice;
      this.PaymentsPeriodicityId = fields.PaymentsPeriodicityId;
      this.BudgetAccountId = fields.BudgetAccountId;
      this.DocumentTypesListId = fields.DocumentTypesListId;
      this.SignDate = fields.SignDate;
      this.LastUpdatedById = Contact.Parse(ExecutionServer.CurrentUserId.ToString());
      this.PostingTime = DateTime.Now;
      this.Status = EntityStatus.Active;
}

    #endregion Helpers

  }  // class Contract

}  // namespace Empiria.Payments.Contracts
