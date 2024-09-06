/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Information Holder                      *
*  Type     : Payable                                    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a payable object. A payable can be a bill, a contract milestone, a service order,   *
*             a loan, travel expenses, a fixed fund provision, etc.                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Contacts;
using Empiria.StateEnums;

using Empiria.Json;
using Empiria.Ontology;

namespace Empiria.Payments.Payables {

  /// <summary>Represents a payable object. A payable can be a bill, a contract milestone, a service order,
  /// a loan, travel expenses, a fixed fund provision, etc.</summary>
  [PartitionedType(typeof(PayableType))]
  internal class Payable : BaseObject {

    #region Constructors and parsers

    protected Payable(PayableType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    static public Payable Parse(int id) => ParseId<Payable>(id);

    static internal Payable Parse(string UID) {
      return ParseKey<Payable>(UID);
    }

    static public Payable Empty => ParseEmpty<Payable>();

    #endregion Constructors and parsers

    #region Properties

    public PayableType PayableType {
      get {
        return (PayableType) GetEmpiriaType();
      }
    }

    public string Notes {
      get; private set;
    }

    private JsonObject ExtData {
      get; set;
    }

    public decimal Total {
      get;
    }

    public DateTime DueTime {
      get; private set;
    }

    public Contact PostedBy {
      get; private set;
    }

    public DateTime PostingTime {
      get; private set;
    }


    public EntityStatus Status {
      get; private set;
    }

    #endregion Properties

  }  // class Payable

}  // namespace Empiria.Payments.Payables
