/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                       Component : Domain Layer                            *
*  Assembly : Empiria.Budgeting.Transactions.dll         Pattern   : Infomation Holder                       *
*  Type     : ContractType                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a contract type.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Payments.Contracts {

  /// <summary>Represents a contract type.</summary>
  public class ContractType : GeneralObject {

    #region Constructors and parsers

    static internal ContractType Parse(string uid) {
      return BaseObject.ParseKey<ContractType>(uid);
    }

    static internal FixedList<ContractType> GetList() {
      return BaseObject.GetList<ContractType>()
                       .ToFixedList();
    }

    static internal ContractType Empty => BaseObject.ParseEmpty<ContractType>();

    #endregion Constructors and parsers

  }  // class ContractType

}  // namespace Empiria.Payments.Contracts
