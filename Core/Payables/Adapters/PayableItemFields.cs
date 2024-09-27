/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Interface adapters                      *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Fields Input DTO                        *
*  Type     : PayableItemFields                          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Contains fields in order to create or update a PayableItem.                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/


using Empiria.Budgeting;
using Empiria.Financial.Core;


namespace Empiria.Payments.Payables.Adapters {

  /// <summary>Contains fields in order to create or update a PayableItem.</summary>
  public class PayableItemFields {

    #region Properties 

    public string UID {
      get; internal set;
    }

    public string ProductUID {
      get; internal set;
    }


    public string UnitUID {
      get; internal set;
    }


    public string Description {
      get; internal set;
    }


    public decimal Quantity {
      get; internal set;
    }

    public decimal UnitPrice {
      get; internal set;
    }

    public string CurrencyUID {
      get; internal set;
    }
    
    public decimal ExchangeRate {
      get; internal set;
    } = 1;
     
        
    public string BudgetAccountUID {
      get; internal set;
    }

    #endregion Properties

    #region Methods

    internal void EnsureValid() {
      Assertion.Require(Description, "Necesito la descripción.");
      Assertion.Require(Quantity, "Necesito la cantidad.");
      Assertion.Require(UnitPrice, "Necesito el precio unitario.");

      Assertion.Require(CurrencyUID, "Necesito la moneda.");
      _ = Currency.Parse(CurrencyUID);

      Assertion.Require(BudgetAccountUID, "Necesito se proporcione el número de cuenta del presupuesto.");
      _ = BudgetAccount.Parse(BudgetAccountUID);
    }

    #endregion Methods

  }  // class PayableItemFields

}  // namespace Empiria.Payments.Payables.Adapters
