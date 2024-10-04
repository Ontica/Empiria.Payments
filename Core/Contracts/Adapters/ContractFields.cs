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

    public string UID {
      get; set;
    } = "Empty";


    public string ContractTypeUID {
      get; set;
    } = "Empty";


    public string ContractNo {
      get; set;
    } = "Empty";


    public string Name {
      get; set;
    } = "Empty";


    public string Description {
      get; set;
    } = "Empty";


    public string  CurrencyUID { 
      get; set;
    } = "Empty";


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


    public string BudgetTypeUID {
      get; set;
    } = "Empty";


    public string SupplierUID {
      get; set;
    } = "Empty";


    public string ParentUID {
      get; set;
    } = "Empty";


    public string ExtData {
      get; set;
    } = "Empty";


    public string KeyWords {
      get; set;
    } = "Empty";


    public string PostedByUID {
      get; set;
    } = "Empty";


    public string PostingTime {
      get; set;
    }


    public string Status {
      get; set;
    } = "P";


    public decimal Total {
      get; set;
    } = 0;


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
      //Assertion.Require(Total > 0, "El importe del contrato debe ser mayor a cero.");
    }

  }  // class ContractFields

}  // namespace Empiria.Payments.Contracts.Adapters
