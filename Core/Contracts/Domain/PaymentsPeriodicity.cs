/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Payment Periodicity Management   Component : Domain Layer                            *
*  Assembly : Empiria.Budgeting.Transactions.dll         Pattern   : Infomation Holder                       *
*  Type     : ContractPeriodicity                        License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a contract Periodicity.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Payments.Contracts {

  /// <summary>Represents a contract periodicity.</summary>
  public class PaymentsPeriodicity : GeneralObject {

    #region Constructors and parsers

    static internal PaymentsPeriodicity Parse(int id) {
      return BaseObject.ParseId<PaymentsPeriodicity>(id);
    }


    static internal PaymentsPeriodicity Parse(string uid) {
      return BaseObject.ParseKey<PaymentsPeriodicity>(uid);
    }


    static internal FixedList<PaymentsPeriodicity> GetList() {
      return BaseObject.GetList<PaymentsPeriodicity>()
                       .ToFixedList();
    }


    static internal PaymentsPeriodicity Empty => BaseObject.ParseEmpty<PaymentsPeriodicity>();

    #endregion Constructors and parsers

  }  // class ContractPeriodicity

}  // namespace Empiria.Payments.Contracts
