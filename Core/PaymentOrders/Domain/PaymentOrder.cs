/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Information Holder                      *
*  Type     : PaymentOrder                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a payment order.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Contacts;
using Empiria.Json;
using Empiria.Parties;
using Empiria.StateEnums;

using Empiria.Financial.Core;

using Empiria.Payments.Orders.Adapters;

using Empiria.Payments.Orders.Data;

namespace Empiria.Payments.Orders {

  /// <summary>Represents a payment order.</summary>
  internal class PaymentOrder : BaseObject {

    #region Constructors and parsers

    private PaymentOrder() {
      // Required by Empiria Framework.
    }

    public PaymentOrder(PaymentOrderFields fields) {
      Assertion.Require(fields, nameof(fields));

      Update(fields);
    }


    static internal PaymentOrder Parse(string UID) {
      return BaseObject.ParseKey<PaymentOrder>(UID);
    }


    static internal PaymentOrder Parse(int Id) {
      return BaseObject.ParseId<PaymentOrder>(Id);
    }

    #endregion Constructors and parsers

    #region Properties

    [DataField("PYM_ORDER_TYPE_ID")]
    public PaymentOrderType PaymentOrderType {
      get; private set;
    }


    [DataField("PYM_ORDER_NO")]
    public string PaymentOrderNo {
      get; private set;
    }


    [DataField("PYM_ORDER_PAY_TO_ID")]
    public Party PayTo {
      get; private set;
    }


    //[DataField("PYM_ORDER_PAYABLE_ID")]
    //public Payable Payable {
    //  get; internal set;
    //}


    [DataField("PYM_ORDER_PAYMENT_METHOD_ID")]
    public PaymentMethod PaymentMethod {
      get; private set;
    }


    [DataField("PYM_ORDER_CURRENCY_ID")]
    public Currency Currency {
      get; private set;
    }


    //[DataField("PYM_ORDER_PAYMENT_ACCOUNT_ID")]
    //public PaymentAccount PaymentAccount {
    //  get; private set;
    //}


    [DataField("PYM_ORDER_NOTES")]
    public string Notes {
      get; private set;
    }


    [DataField("PYM_ORDER_REQUESTED_DATE")]
    public DateTime RequestedDate {
      get; private set;
    }


    [DataField("PYM_ORDER_EXT_DATA")]
    private JsonObject ExtData {
      get; set;
    }


    [DataField("PYM_ORDER_TOTAL", ConvertFrom = typeof(decimal))]
    public decimal Total {
      get; private set;
    }


    [DataField("PYM_ORDER_DUETIME")]
    public DateTime DueTime {
      get; private set;
    }


    [DataField("PYM_ORDER_REQUESTED_BY_ID")]
    public Party RequestedBy {
      get; private set;
    }


    public string Keywords {
      get {
        return EmpiriaString.BuildKeywords(this.PayTo.Name, this.RequestedBy.Name);
      }
    }

    [DataField("PYM_ORDER_POSTED_BY_ID")]
    public Contact PostedBy {
      get; private set;
    }


    [DataField("PYM_ORDER_POSTING_TIME")]
    public DateTime PostingTime {
      get; private set;
    }


    [DataField("PYM_ORDER_STATUS", Default = EntityStatus.Pending)]
    public EntityStatus Status {
      get; private set;
    }

    #endregion Properties

    #region Methods


    internal void Delete() {

      Assertion.Require(this.Status == EntityStatus.Active || this.Status == EntityStatus.Suspended,
                  $"No se puede eliminar una orden de pago que está en estado {this.Status.GetName()}.");

      this.Status = EntityStatus.Deleted;
    }


    protected override void OnSave() {
      if (base.IsNew) {
        this.PaymentOrderNo = "O-"+ EmpiriaString.BuildRandomString(10).ToUpperInvariant();
        this.PostedBy = ExecutionServer.CurrentContact;
        this.PostingTime = DateTime.Now;
      }

      PaymentOrderData.WritePaymentOrder(this, this.ExtData.ToString());
    }


    internal void Suspend() {
      Assertion.Require(this.Status == EntityStatus.Active,
                  $"No se puede suspender una orden de pago que no este activa.");

      this.Status = EntityStatus.Suspended;
    }

    #endregion Methods

    #region Helpers

    public void Update(PaymentOrderFields fields) {

      this.PaymentOrderType = PaymentOrderType.Parse(fields.PaymentOrderTypeUID);
      this.PayTo = Party.Parse(fields.PayToUID);
      //this.Payable = Payable.Parse(fields.PayableUID);
      this.PaymentMethod = PaymentMethod.Parse(fields.PaymentMethodUID);
      this.Currency = Currency.Parse(fields.CurrencyUID);
      //this.PaymentAccount = PaymentAccount.Parse(fields.PaymentAccountUID);
      this.Notes = fields.Notes;
      this.RequestedDate = fields.RequestedDate;
      this.DueTime = fields.DueTime;
      this.RequestedBy = Party.Parse(fields.RequestedByUID);
      this.PostedBy = Contact.Parse(ExecutionServer.CurrentUserId);
      this.PostingTime = DateTime.Now;
      this.Total = fields.Total;
      this.Status = EntityStatus.Active;

    }

    #endregion Helpers

  }  // class Contract


}  // namespace Empiria.Payments.Contracts
