/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Item Management                  Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Fields DTO                              *
*  Type     : ContractItemFields                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : DTO fields structure used for update contracts information.                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

namespace Empiria.Payments.Contracts.Adapters {

  /// <summary>DTO fields structure used for update contracts item information.</summary>
  public class ContractItemFields {

    public string ContractUID {
      get; set;
    }


    public string ProductUID {
      get; set;
    }


    public string Description {
      get; set;
    }


    public string UnitMeasureUID {
      get; set;
    }


    public decimal FromQuantity {
      get; set;
    }


    public decimal ToQuantity {
      get; set;
    }


    public decimal UnitPrice {
      get; set;
    }


     public string ProjectUID {
      get; set;
    }


    public string PaymentPeriodicityUID {
      get; set;
    }


    public string BudgetAccountUID {
      get; set;
    }


    public string DocumentTypeUID {
      get; set;
    }


    public DateTime SignDate {
      get; set;
    }


    public string ExtData {
      get; set;
    }


    public string KeyWords {
      get; set;
    }


    public string PostedByUID {
      get; set;
    }


    public string PostingTime {
      get; set;
    }


    public decimal Total {
      get; set;
    }


    internal void EnsureValid() {
      Assertion.Require(ContractUID, "Se requiere el número de contrato.");
      Assertion.Require(ProductUID, "Se requiere el ID del número de contrato.");
      Assertion.Require(Description, "Necesito el nombre del contrato.");
      Assertion.Require(UnitMeasureUID, "Necesito la unidad de medida.");
      Assertion.Require(UnitPrice > 0, "Necesito el precio unitario.");
      Assertion.Require(FromQuantity > 0, "Necesito la cantidad de medida inicial.");
      Assertion.Require(ToQuantity > 0, "Necesito la cantidad de medida final.");

    }

  }  // class ContractItemFields

}  // namespace Empiria.Payments.Contracts.Adapters
