/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Suppliers Management                 Component : Domain Layer                        *
*  Assembly : Empiria.Payments.Contracts.dll             Pattern   : Infomation Holder                       *
*  Type     : ContractSuppliers                          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a contract suppliers.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Payments.Contracts {

  /// <summary>Represents a contract suppliers.</summary>
  public class ContractSuppliers : GeneralObject {

    #region Constructors and parsers

    static internal ContractSuppliers Parse(int id) {
      return BaseObject.ParseId<ContractSuppliers>(id);
    }

    static internal ContractSuppliers Parse(string uid) {
      return BaseObject.ParseKey<ContractSuppliers>(uid);
    }

    static internal FixedList<ContractSuppliers> GetList() {
      return BaseObject.GetList<ContractSuppliers>()
                       .ToFixedList();
    }

    static internal ContractSuppliers Empty => BaseObject.ParseEmpty<ContractSuppliers>();

    #endregion Constructors and parsers

  }  // class ContractSuppliers

}  // namespace Empiria.Payments.Contracts
