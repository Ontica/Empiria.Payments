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


    public Party PayTo {
      get; private set;
    }


    public Currency Currency {
      get; private set;
    }


    public decimal Total {
      get; private set;
    }


    public DateTime DueTime {
      get; private set;
    } = ExecutionServer.DateMaxValue;


    public string Notes {
      get; private set;
    }


    private JsonObject ExtData {
      get; set;
    } = JsonObject.Empty;


    public string Keywords {
      get {
        return EmpiriaString.BuildKeywords(this.PayTo.Name, this.PayableType.Name, this.Total.ToString());
      }
    }


    public Contact PostedBy {
      get; private set;
    }


    public DateTime PostingTime {
      get; private set;
    }


    public PayableStatus Status {
      get; private set;
    }

    #endregion Properties

    #region Methods


    protected override void OnSave() {
      if (base.IsNew) {
        this.PostedBy = ExecutionServer.CurrentContact;
        this.PostingTime = DateTime.Now;
        this.Status = PayableStatus.Capture;
      }

      PayableData.WritePayable(this, this.ExtData.ToString());
    }

    internal void Update(PayableFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      this.PayTo = Party.Parse(fields.PayToUID);
      this.Total = fields.Total;
      this.Currency = Currency.Parse(fields.CurrencyUID);
      this.DueTime = fields.DueTime;
      this.Notes = fields.Notes;
    }

    #endregion Methods

  }  // class Payable

}  // namespace Empiria.Payments.Payables
