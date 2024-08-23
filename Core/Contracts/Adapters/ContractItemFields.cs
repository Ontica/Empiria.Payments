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


    public int ID {
      get; set;
    }


    public string UID {
      get; set;
    }


    public int ContractId {
      get; set;
    }


    public int ProductId {
      get; set;
    }


    public string Description {
      get; set;
    }


    public int UnitMeasureId {
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


    public int ProjectId {
      get; set;
    }


    public int PaymentsPeriodicityId {
      get; set;
    }


    public int BudgetAccountId {
      get; set;
    }


    public int DocumentTypesListId {
      get; set;
    }


    public DateTime SignDate {
      get; set;
    }

     
    public decimal Total {
      get; set;
    }


    internal void EnsureValid() {
      Assertion.Require(ContractId, "Se requiere el número de contrato.");
      Assertion.Require(ProductId, "Se requiere el UID número de contrato.");
      Assertion.Require(Description, "Necesito el nombre del contrato.");
      Assertion.Require(UnitMeasureId, "Necesito la unidad de medida.");
      Assertion.Require(UnitPrice, "Necesito el precio unitario.");
      Assertion.Require(FromQuantity, "Necesito la cantidad de medida inicial.");
      Assertion.Require(ToQuantity, "Necesito la cantidad de medida final.");

    }

  }  // class ContractItemFields

}  // namespace Empiria.Payments.Contracts.Adapters
