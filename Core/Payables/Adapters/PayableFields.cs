/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Fields DTO                              *
*  Type     : PayableFields                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Fields structure used for create and update payable objects.                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Parties;

using Empiria.Budgeting;

using Empiria.Financial.Core;

namespace Empiria.Payments.Payables.Adapters {

  /// <summary>Fields structure used for create and update payable objects.</summary>
  public class PayableFields {

    public int PayableTypeId {
      get; set;
    }

    public string OrganizationalUnitUID {
      get; set;
    }

    public string PayToUID {
      get; set;
    }

    public string CurrencyUID {
      get; set;
    }

    public int BudgetTypeId {
      get; set;
    }

    public DateTime DueTime {
      get; set;
    } = ExecutionServer.DateMinValue;


    public string Notes {
      get; set;
    } = string.Empty;


    virtual internal void EnsureValid() {
      Assertion.Require(PayableTypeId, "Necesito el tipo de pago.");
      _ = PayableType.Parse(PayableTypeId);

      Assertion.Require(OrganizationalUnitUID, "Necesito se proporcione el área.");
      _ = OrganizationalUnit.Parse(OrganizationalUnitUID);

      Assertion.Require(PayToUID, "Necesito saber a quien se le realizará el pago.");
       _ = Party.Parse(PayToUID);

      Assertion.Require(CurrencyUID, "Necesito la moneda.");
      _ = Currency.Parse(CurrencyUID);

      Assertion.Require(BudgetTypeId, "Necesito saber con qué presupuesto se hará el pago.");
      _ = BudgetType.Parse(BudgetTypeId);
    }

  }  // class PayableFields

}  // namespace Empiria.Payments.Payables.Adapters
