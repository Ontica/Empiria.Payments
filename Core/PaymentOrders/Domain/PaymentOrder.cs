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
using Empiria.Parties;
using Empiria.StateEnums;

using Empiria.Payments.Orders.Adapters;
using Empiria.Financial.Core;
using Empiria.Json;


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

    public PaymentOrderType PaymentOrderType {
      get; private set;
    }


    public string PaymentOrderNo {
      get; private set;
    }

   
    public Party PayTo {
      get; private set;
    }

         
    public Payable Payable {
      get; internal set;
    }


    public PaymentMethod PaymentMethod {
      get; private set;
    }


    public Currency Currency {
      get; private set;
    }


    public PaymentAccount PaymentAccount {
      get; private set;
    }

    
    public string Notes {
      get; private set;
    }


    public DateTime RequestedDate {
      get; private set;
    }


    private JsonObject ExtData {
      get; set;
    } 


    public decimal Total {
      get;
    }


    public DateTime DueTime {
      get; private set;
    }


    public string Keywords {
      get {
        return EmpiriaString.BuildKeywords(this.PayTo.Name,  this.RequestedBy.Name);
      }
    }


    public Party RequestedBy {
      get; private set;
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
          // save
    }
       

    internal void Suspend() {
      Assertion.Require(this.Status == EntityStatus.Active,
                  $"No se puede suspender una orden de pago que no este activa.");

      this.Status = EntityStatus.Suspended;
    }

    #endregion Methods

    #region Helpers

    private void Update(PaymentOrderFields fields) {

      this.PaymentOrderType = PaymentOrderType.Parse(fields.PaymentOrderTypeUID);
      this.PayTo = Party.Parse(fields.PayToUID);
      this.Payable = Payable.Parse(fields.PayableUID);
      this.PaymentMethod = PaymentMethod.Parse(fields.PaymentMethodUID);
      this.Currency = Currency.Parse(fields.CurrencyUID);
      this.PaymentAccount = PaymentAccount.Parse(fields.PaymentAccounUID);
      this.Notes = fields.Notes;
      this.RequestedDate = fields.RequestedDate;
      this.DueTime = fields.DueTime;
      this.RequestedBy = Party.Parse(fields.RequestedByUID);
      this.PostedBy = Contact.Parse(ExecutionServer.CurrentUserId);
      this.PostingTime = DateTime.Now;
      this.Status = EntityStatus.Active;

    }

    #endregion Helpers

  }  // class Contract

  
}  // namespace Empiria.Payments.Contracts
