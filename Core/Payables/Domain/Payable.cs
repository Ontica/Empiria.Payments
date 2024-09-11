/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Partitioned type                        *
*  Type     : Payable                                    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a payable object. A payable can be a bill, a contract milestone,                    *
*             a service order, a loan, travel expenses, a fixed fund provision, etc.                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Contacts;
using Empiria.Json;
using Empiria.Ontology;
using Empiria.Parties;

using Empiria.Financial.Core;

using Empiria.Budgeting;

using Empiria.Payments.Payables.Adapters;
using Empiria.Payments.Payables.Data;

namespace Empiria.Payments.Payables {

  /// <summary>Represents a payable object. A payable can be a bill, a contract milestone,
  /// a service order, a loan, travel expenses, a fixed fund provision, etc.</summary>
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

    [DataField("PYM_BUDGET_TYPE_ID")]
    public BudgetType BudgetType {
      get; private set;
    }

    [DataField("PYM_PAYABLE_CURRENCY_ID")]
    public Currency Currency {
      get; private set;
    }


    public decimal Total {
      get {
        return 1000;
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

  }  // class Payable

}  // namespace Empiria.Payments.Payables
