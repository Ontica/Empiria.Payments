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


    [DataField("CONTRACT_UID")]
    public string ContractUID {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_PRODUCTUID")]
    public string ProductUID {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_DESCRIPTION")]
    public string Description {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_UNITUID")]
    public string UnitMeasureUID {
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


    [DataField("CONTRACT_ITEM_PROJECTUID")]
    public string ProjectUID {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_PAYMENTPERID")]
    public string PaymentsPeriodicityUID {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_BDGACCOUNTUID")]
    public string BudgetAccountUID {
      get; private set;
    }


    [DataField("CONTRACT_ITEM_DOCTYPESLISTUID")]
    public string DocumentTypesListUID {
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

    [DataField("POSTED_BY_UID")]
    internal Contact LastUpdatedByUID {
      get {
        return ExtData.Get<Contact>("lastUpdatedByUID", Contact.Empty);
      }
      set {
        ExtData.Set("lastUpdatedByUID", value.UID);
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
        this.LastUpdatedByUID = ExecutionServer.CurrentContact;
        this.LastUpdatedTime = DateTime.Now;
      }

      LastUpdatedByUID = ExecutionServer.CurrentContact;
      LastUpdatedTime = DateTime.Now;

      ContractIemData.WriteContractItem(this, this.ExtData.ToString());
    }

    #endregion Methods

    #region Helpers

    private void Load(ContractItemFields fields) {
      this.ProductUID = fields.ProductUID;
      this.ContractUID = fields.ContractUID;
      this.Description = fields.Description;
      this.ContractUID = fields.ContractUID;
      this.UnitMeasureUID = fields.UnitMeasureUID;
      this.FromQuantity = fields.FromQuantity;
      this.ToQuantity = fields.ToQuantity;
      this.UnitPrice = fields.UnitPrice;
      this.PaymentsPeriodicityUID = fields.PaymentsPeriodicityUID;
      this.BudgetAccountUID = fields.BudgetAccountUID;
      this.DocumentTypesListUID = fields.DocumentTypesListUID;
      this.SignDate = fields.SignDate;
      this.LastUpdatedByUID = Contact.Parse(ExecutionServer.CurrentUserId.ToString());
      this.PostingTime = DateTime.Now;
      this.Status = EntityStatus.Active;
}

    #endregion Helpers

  }  // class Contract

}  // namespace Empiria.Payments.Contracts
