/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Unit Management                       Component : Domain Layer                            *
*  Assembly : Empiria.Budgeting.Transactions.dll         Pattern   : Infomation Holder                       *
*  Type     : ContractUnit                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a contract unit.                                                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Payments.Contracts {

  /// <summary>Represents a contract unit.</summary>
  public class ContractUnit : GeneralObject {

    #region Constructors and parsers

    static internal ContractUnit Parse(string uid) {
      return BaseObject.ParseKey<ContractUnit>(uid);
    }

    static internal FixedList<ContractUnit> GetList() {
      return BaseObject.GetList<ContractUnit>()
                       .ToFixedList();
    }

    static internal ContractUnit Empty => BaseObject.ParseEmpty<ContractUnit>();

    #endregion Constructors and parsers

  }  // class ContractUnit

}  // namespace Empiria.Payments.Contracts
