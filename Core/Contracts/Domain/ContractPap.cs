/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts payment periodicity Management   Component : Domain Layer                            *
*  Assembly : Empiria.Budgeting.Transactions.dll         Pattern   : Infomation Holder                       *
*  Type     : ContractPap                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a contract pap.                                                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Payments.Contracts {

  /// <summary>Represents a contract pap.</summary>
  public class ContractPap : GeneralObject {

    #region Constructors and parsers

    static internal ContractPap Parse(string uid) {
      return BaseObject.ParseKey<ContractPap>(uid);
    }

    static internal FixedList<ContractPap> GetList() {
      return BaseObject.GetList<ContractPap>()
                       .ToFixedList();
    }

    static internal ContractPap Empty => BaseObject.ParseEmpty<ContractPap>();

    #endregion Constructors and parsers

  }  // class ContractPap

}  // namespace Empiria.Payments.Contracts
