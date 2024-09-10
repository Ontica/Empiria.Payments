/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Partitioned type                        *
*  Type     : ContractMilestone                          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a contract milestone that is a payable object.                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Payments.Contracts;

using Empiria.Payments.Payables.Adapters;

namespace Empiria.Payments.Payables {

  /// <summary>Represents a contract milestone that is a payable object.</summary>
  internal class ContractMilestone : Payable {

    #region Constructors and parsers

    private ContractMilestone(PayableType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    public ContractMilestone(ContractMilestoneFields fields) : base(PayableType.ContractMilestone, fields) {

      Update(fields);
    }

    static public new ContractMilestone Parse(int id) => ParseId<ContractMilestone>(id);

    static internal new ContractMilestone Parse(string UID) {
      return ParseKey<ContractMilestone>(UID);
    }

    static public new ContractMilestone Empty => ParseEmpty<ContractMilestone>();

    #endregion Constructors and parsers

    #region Properties

    public Contract Contract {
      get; private set;
    }

    #endregion Properties

    #region Methods

    internal void Update(ContractMilestoneFields fields) {
      base.Update(fields);

      this.Contract = Contract.Parse(fields.ContractUID);
    }

    #endregion Methods

  }  // class ContractMilestone

}  // namespace Empiria.Payments.Payables
