/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Cucop Management                 Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Contracts.dll             Pattern   : Infomation Holder                       *
*  Type     : ContractDocument                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a contract document.                                                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Payments.Contracts {

  /// <summary>Represents a contract suppliers.</summary>
  public class ContractDocument : GeneralObject {

    #region Constructors and parsers

    static internal ContractDocument Parse(int id) {
      return BaseObject.ParseId<ContractDocument>(id);
    }

    static internal ContractDocument Parse(string uid) {
      return BaseObject.ParseKey<ContractDocument>(uid);
    }

    static internal FixedList<ContractDocument> GetList() {
      return BaseObject.GetList<ContractDocument>()
                       .ToFixedList();
    }

    static internal ContractDocument Empty => BaseObject.ParseEmpty<ContractDocument>();

    #endregion Constructors and parsers

  }  // class ContractDocument

}  // namespace Empiria.Payments.Contracts
