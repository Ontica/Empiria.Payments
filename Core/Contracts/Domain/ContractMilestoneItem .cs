/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts milestone Management             Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Contracts.dll             Pattern   : Infomation Holder                       *
*  Type     : ContractMilestoneItem                      License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a contract milestone Item.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Payments.Contracts {

  /// <summary>Represents a contract suppliers.</summary>
  public class ContractMilestoneItem : GeneralObject {

    #region Constructors and parsers

    static internal ContractMilestoneItem Parse(int id) {
      return BaseObject.ParseId<ContractMilestoneItem>(id);
    }

    static internal ContractMilestoneItem Parse(string uid) {
      return BaseObject.ParseKey<ContractMilestoneItem>(uid);
    }

    static internal FixedList<ContractMilestoneItem> GetList() {
      return BaseObject.GetList<ContractMilestoneItem>()
                       .ToFixedList();
    }

    static internal ContractMilestoneItem Empty => BaseObject.ParseEmpty<ContractMilestoneItem>();

    #endregion Constructors and parsers

  }  // class ContractMilestone

}  // namespace Empiria.Payments.Contracts
