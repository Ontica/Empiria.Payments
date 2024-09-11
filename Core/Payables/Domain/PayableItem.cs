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

    public decimal Quantity {
      get; private set;
    }

    public Currency Currency {
      get; private set;
    }


    public decimal ExchangeRate {
      get; private set;
    } = 1;


    public decimal UnitPrice {
      get; private set;
    }


    public decimal Subtotal {
      get {
        return Math.Round(UnitPrice * Quantity * ExchangeRate);
      }
    }


    public decimal Taxes {
      get; private set;
    }


    public decimal Total {
      get {
        return Math.Round(Subtotal + Taxes);
      }
    }

    public BudgetAccount BudgetAccount {
      get; private set;
    }

    public string Notes {
      get; private set;
    }

    private JsonObject ExtData {
      get; set;
    }

    public Contact PostedBy {
      get; private set;
    }

    public DateTime PostingTime {
      get; private set;
    }

    public EntityStatus Status {
      get; private set;
    }

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
