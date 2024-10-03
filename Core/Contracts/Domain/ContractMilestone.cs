﻿/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts milestone Management             Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Contracts.dll             Pattern   : Infomation Holder                       *
*  Type     : ContractMilestone                          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a contract milestone.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Payments.Contracts {

  /// <summary>Represents a contract milesto.</summary>
  public class ContractMilestone : GeneralObject {

    #region Constructors and parsers

    static internal ContractMilestone Parse(int id) {
      return BaseObject.ParseId<ContractMilestone>(id);
    }

    static internal ContractMilestone Parse(string uid) {
      return BaseObject.ParseKey<ContractMilestone>(uid);
    }

    static internal FixedList<ContractMilestone> GetList() {
      return BaseObject.GetList<ContractMilestone>()
                       .ToFixedList();
    }

    static internal ContractMilestone Empty => BaseObject.ParseEmpty<ContractMilestone>();

    #endregion Constructors and parsers

  }  // class ContractMilestone

}  // namespace Empiria.Payments.Contracts
