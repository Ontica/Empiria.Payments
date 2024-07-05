/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Information Holder                      *
*  Type     : PaymentOrder                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a payable object.                                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Contacts;
using Empiria.Parties;
using Empiria.StateEnums;

using Empiria.Payments.Orders.Adapters;
using Empiria.Financial.Core;
using Empiria.Json;


namespace Empiria.Payments.Orders {

  /// <summary>Represents a payable object.</summary>
  internal class Payable : BaseObject {

    #region Constructors and parsers

    private Payable() {
      // Required by Empiria Framework.
    }

    static public Payable Parse(int id) => ParseId<Payable>(id);

    static internal Payable Parse(string UID) {
      return BaseObject.ParseKey<Payable>(UID);
    }

    static public Payable Empty => ParseEmpty<Payable>();

    #endregion Constructors and parsers

    #region Properties

    public int PayableType {
      get; private set;
    }


    public int PayableTypeId {
      get; private set;
    }
      
      
    public string Notes {
      get; private set;
    }


    public DateTime RequestedDate {
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

    #region Methods
        


    #endregion Methods

    #region Helpers

    

    #endregion Helpers

  }  // class Payable 


}  // namespace Empiria.Payments.Orders
