/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Aggregate root, Partitioned type        *
*  Type     : Payable                                    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a payable object that is an aggregate root of PayableItem objects.                  *
*             A payable can be a bill, a contract milestone, a service order, a loan, travel expenses,       *
*             fixed fund provision, etc.                                                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using System.Linq;

using Empiria.Contacts;
using Empiria.Json;
using Empiria.Ontology;
using Empiria.Parties;

using Empiria.Financial.Core;

using Empiria.Budgeting;

using Empiria.Payments.Payables.Adapters;
using Empiria.Payments.Payables.Data;

namespace Empiria.Payments.Payables {

  /// <summary>Represents a payable object that is an aggregate root of PayableItem objects.
  /// A payable can be a bill, a contract milestone, a service order, a loan, travel expenses,
  /// fixed fund provision, etc.</summary>
  [PartitionedType(typeof(PayableType))]
  internal class Payable : BaseObject {

    #region Constructors and parsers

    protected Payable(PayableType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    internal protected Payable(PayableType payableType, PayableFields fields) : base(payableType) {
      Assertion.Require(fields, nameof(fields));

      Update(fields);
    }

    static public Payable Parse(int id) => ParseId<Payable>(id);

    static internal Payable Parse(string UID) {
      return ParseKey<Payable>(UID);
    }

    static public Payable Empty => ParseEmpty<Payable>();

    #endregion Constructors and parsers

    #region Properties

    public PayableType PayableType {
      get {
        return (PayableType) GetEmpiriaType();
      }
    }

    [DataField("PYM_PAYABLE_ORG_UNIT_ID")]
    public OrganizationalUnit OrganizationalUnit {
      get; private set;
    }


    [DataField("PYM_PAYABLE_PAY_TO_ID")]
    public Party PayTo {
      get; private set;
    }


    [DataField("PYM_PAYABLE_BUDGET_TYPE_ID")]
    public BudgetType BudgetType {
      get; private set;
    }


    [DataField("PYM_PAYABLE_CURRENCY_ID")]
    public Currency Currency {
      get; private set;
    }


    public decimal Total {
      get {
        return 1900m; //GetItems().Sum(x => x.Total);
      }
    }


    [DataField("PYM_PAYABLE_DUETIME")]
    public DateTime DueTime {
      get; private set;
    } = ExecutionServer.DateMaxValue;


    [DataField("PYM_PAYABLE_NOTES")]
    public string Notes {
      get; private set;
    }

    [DataField("PYM_PAYABLE_EXT_DATA")]
    protected JsonObject ExtData {
      get; set;
    } = JsonObject.Empty;


    public string Keywords {
      get {
        return EmpiriaString.BuildKeywords(this.PayTo.Name, this.PayableType.Name);
      }
    }


    [DataField("PYM_PAYABLE_POSTED_BY_ID")]
    public Contact PostedBy {
      get; private set;
    }


    [DataField("PYM_PAYABLE_POSTING_TIME")]
    public DateTime PostingTime {
      get; private set;
    }


    [DataField("PYM_PAYABLE_STATUS", Default = PayableStatus.Capture)]
    public PayableStatus Status {
      get; private set;
    } = PayableStatus.Capture;

    #endregion Properties

    #region Methods

    protected override void OnBeforeSave() {
      if (base.IsNew) {
        this.PostedBy = ExecutionServer.CurrentContact;
        this.PostingTime = DateTime.Now;
      }
    }

    protected override void OnSave() {
      PayableData.WritePayable(this, this.ExtData.ToString());
    }

    internal void Update(PayableFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      this.OrganizationalUnit = OrganizationalUnit.Parse(fields.OrganizationalUnitUID);
      this.PayTo = Party.Parse(fields.PayToUID);
      this.BudgetType = BudgetType.Parse(fields.BudgetTypeUID);
      this.Currency = Currency.Parse(fields.CurrencyUID);
      this.DueTime = fields.DueTime;
      this.Notes = fields.Notes;
    }

    #endregion Methods

    #region Aggregate root methods

    public PayableItem AddItem(PayableItemFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      return new PayableItem(this, fields);
    }


    public void DeleteItem(string uid) {
      PayableItem item = GetItem(uid);

      item.Delete();
    }


    public FixedList<PayableItem> GetItems() {
      return PayableData.GetPayableItems(this);
    }


    public PayableItem GetItem(string uid) {
      return PayableData.GetPayableItem(this, uid);
    }


    public PayableItem UpdateItem(PayableItemFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      PayableItem item = GetItem(fields.UID);

      item.Update(fields);

      return item;
    }

    #endregion Aggregate root methods

  }  // class Payable

}  // namespace Empiria.Payments.Payables
