/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Information Holder                      *
*  Type     : PayableItem                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents an item of a payable object. A payable can be a bill, a contract milestone,         *
*             a service order, a loan, travel expenses, a fixed fund provision, etc.                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Contacts;
using Empiria.Json;
using Empiria.StateEnums;

using Empiria.Products;

using Empiria.Financial.Core;
using Empiria.Budgeting;

using Empiria.Payments.Payables.Adapters;

namespace Empiria.Payments.Payables {

  /// <summary>Represents an item of a payable object. A payable can be a bill, a contract milestone,
  /// a service order, a loan, travel expenses, a fixed fund provision, etc.</summary>
  internal class PayableItem : BaseObject {

    #region Constructors and parsers

    protected PayableItem(PayableType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    private PayableItem() {
      // Required by Empiria Framework.
    }

    public PayableItem(Payable payable, PayableItemFields fields) {
      Assertion.Require(payable, nameof(payable));
      Assertion.Require(fields, nameof(fields));

      throw new NotImplementedException();
    }

    static public PayableItem Parse(int id) => ParseId<PayableItem>(id);

    static internal PayableItem Parse(string UID) {
      return ParseKey<PayableItem>(UID);
    }

    static public PayableItem Empty => ParseEmpty<PayableItem>();

    #endregion Constructors and parsers

    #region Properties

    public Product Product {
      get; private set;
    }

    public ProductUnit Unit {
      get; private set;
    }

   [DataField("PYM_PYB_ITEM_QTY", ConvertFrom = typeof(decimal))]
    public decimal Quantity {
      get; private set;
    }

    [DataField("PYM_PYB_ITEM_CURRENCY_ID")]
    public Currency Currency {
      get; private set;
    }

   [DataField("PYM_PYB_ITEM_EXCH_RATE", ConvertFrom = typeof(decimal))]
    public decimal ExchangeRate {
      get; private set;
    } = 1;


    [DataField("PYM_PYB_ITEM_QTY", ConvertFrom = typeof(decimal))]
    public decimal UnitPrice {
      get; private set;
    }


    public decimal Subtotal {
      get {
        return Math.Round(UnitPrice * Quantity * ExchangeRate);
      }
    }

    [DataField("PYM_PYB_ITEM_BDG_ACCT_ID")]
    public BudgetAccount BudgetAccount {
      get; private set;
    }

    [DataField("PYM_PYB_ITEM_DESCRIPTION")]
    public string Notes {
      get; private set;
    }

    [DataField("PYM_PYB_ITEM_EXT_DATA")]
    private JsonObject ExtData {
      get; set;
    }

    [DataField("PYM_PYB_ITEM_POSTED_BY_ID")]
    public Contact PostedBy {
      get; private set;
    }

    [DataField("PYM_PYB_ITEM_POSTING_TIME")]
    public DateTime PostingTime {
      get; private set;
    }

    [DataField("PYM_PYB_ITEM_STATUS", Default = EntityStatus.Pending)]
    public EntityStatus Status {
      get; private set;
    } = EntityStatus.Pending;

    #endregion Properties

    #region Methods

    internal void Delete() {
      throw new NotImplementedException();
    }

    internal void Update(PayableItemFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      throw new NotImplementedException();
    }

    #endregion Methods

  }  // class PayableItem

}  // namespace Empiria.Payments.Payables
