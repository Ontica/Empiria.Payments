/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Fields DTO                              *
*  Type     : ContractFields                             License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : DTO fields structure used for update contracts information.                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

namespace Empiria.Payments.Contracts.Adapters {

  /// <summary>DTO fields structure used for update contracts information.</summary>
  public class ContractFields {


    public string ID {
      get; set;
    }


    public string UID {
      get; set;
    }


    public string ContractTypeUID {
      get; set;
    }


    public string ContractNo {
      get; set;
    }


    public string Name {
      get; set;
    }


    public string Description {
      get; set;
    }


    public string Notes {
      get; set;
    }


    public DateTime FromDate {
      get; set;
    } = ExecutionServer.DateMinValue;


    public DateTime ToDate {
      get; set;
    } = ExecutionServer.DateMinValue;


    public DateTime SignDate {
      get; set;
    } = ExecutionServer.DateMinValue;


    public string ManagedByOrgUnitUID {
      get; set;
    }

    public string SupplierUID {
      get; set;
    }

    public string CurrencyUID {
      get; set;
    }


    public string BudgetTypeUID {
      get; set;
    }


    public string DocumentUID {
      get; set;
    }


    public string ContractUID {
      get; set;
    }


    public int ParentContractId {
      get; set;
    }


    public decimal Total {
      get; set;
    }


    internal void EnsureValid() {
      Assertion.Require(ContractNo, "Se requiere el número de contrato.");
      Assertion.Require(Name, "Necesito el nombre del contrato.");
      Assertion.Require(FromDate != ExecutionServer.DateMinValue,
                        "Necesito la fecha del inicio del contrato");
      Assertion.Require(ToDate != ExecutionServer.DateMinValue,
                        "Necesito la fecha del finalización del contrato");
      Assertion.Require(FromDate <= ToDate,
                  "La fecha de finalización del contrato no puede ser " +
                  "anterior a la fecha de inicio.");
      Assertion.Require(SignDate != ExecutionServer.DateMinValue,
                        "Necesito la fecha del firma del contrato");
      Assertion.Require(Total > 0, "El importe del contrato debe ser mayor a cero.");
    }

  }  // class ContractFields

}  // namespace Empiria.Payments.Contracts.Adapters
